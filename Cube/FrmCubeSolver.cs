using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * TODO
 * - Highlight the seleted cube?
 * - Allow coloring of your own cube to setup as one in hand?
 * - Cube size 6 - special upper colors are not rotating as the other sizes.  Why just 6?  Others?
 * - Rotation efforts
 * - Auto-Solve
 * - Additional algorithm buttons for bigger cubes
 */

namespace CubeSolver
{
    public partial class FrmCubeSolver : Form
    {
        private Cube cube;
        private Bitmap primaryImage;
        private Bitmap maskImage;
        private List<RadioButton> drawTypes = new List<RadioButton>();
        private bool beenRotated = false;
        private FrmQuickPicks frmQuickPicks = new FrmQuickPicks();
        private frmDebug frmDebug = new frmDebug();
        private Bitmap selectedPieceImage;

        public int SelectedPieceZ { get; set; }
        public int SelectedPieceX { get; set; }
        public int SelectedPieceY { get; set; }

        public int Delay
        {
            get { return (int)numDelay.Value; }
        }

        public FrmCubeSolver()
        {
            InitializeComponent();

            txtLog.Clear();
            txtLog.AppendText("CubeSolver by Matt J. Parks" + Environment.NewLine);
            txtLog.AppendText("**********************************" + Environment.NewLine);

            // little image of selected piece
            selectedPieceImage = new Bitmap(picSelected.Width, picSelected.Height);
            SelectedPieceZ = -1;
            SelectedPieceX = -1;
            SelectedPieceY = -1;

            // when opening the color picker, display the fancy color wheel
            dlgColor.FullOpen = true;

            // setup the Direstion list (default to Clockwise)
            cmbDirection.DisplayMember = "Text";
            cmbDirection.ValueMember = "Value";
            var directionItems = new[] { new { Text = Direction.Clockwise.ToString(), Value = Direction.Clockwise }, new { Text = Direction.Counterclockwise.ToString(), Value = Direction.Counterclockwise }};
            cmbDirection.DataSource = directionItems;
            cmbDirection.SelectedIndex = 0;

            // setup the Plane list (default to Horizontal)
            cmbPlane.DisplayMember = "Text";
            cmbPlane.ValueMember = "Value";
            var planeItems = new[] { new { Text = Plane.Horizontal.GetDescription(), Value = Plane.Horizontal }, new { Text = Plane.VerticalDepth.GetDescription(), Value = Plane.VerticalDepth }, new { Text = Plane.VerticalWidth.GetDescription(), Value = Plane.VerticalWidth } };
            cmbPlane.DataSource = planeItems;
            cmbPlane.SelectedIndex = cmbPlane.FindString(Plane.Horizontal.ToString());

            // borrow Tag for storing draw type (yay Tag!)
            radDraw3D.Tag = (int)DrawType.ThreeD;
            radDrawGrid.Tag = (int)DrawType.Grid;
            radDrawSplitStack.Tag = (int)DrawType.SplitStack;
            radDrawUnfold.Tag = (int)DrawType.Unfold;
            // then store as list to easy find out which is selected later
            drawTypes.AddRange(new List<RadioButton> { radDraw3D, radDrawGrid, radDrawSplitStack, radDrawUnfold });
        }

        private void FrmCubeSolver_Load(object sender, EventArgs e)
        {
            frmQuickPicks.Owner = this;
            frmQuickPicks.MainForm = this;  // having to do this since I will be setting some things on the quickpick form before Loaded
            frmQuickPicks.Left = Left + (int)(Width / 2);
            frmQuickPicks.Top = Top;

            frmDebug.Owner = this;
            frmDebug.Left = frmQuickPicks.Left + frmQuickPicks.Width;
            frmDebug.Top = Top;

            // might as well start with a standard cube already created
            Create_Click(this, null);
        }

        public void Log(string category)
        {
            Log(category, "");
        }

        public void Log(string category, string logEntry)
        {
            txtLog.AppendText(String.Format("{0} -- <<{1}>>{2}{3}{4}", System.DateTime.Now, category, (String.IsNullOrEmpty(logEntry) ? "" : " -- "), logEntry, Environment.NewLine));
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            // in case did some solving working manually and accidentally clicked Create
            if (beenRotated)
            {
                bool quickPicksVisible = frmQuickPicks.Visible;
                bool debugVisible = frmDebug.Visible;

                // hide the stay-on-top forms since they even cover the messagebox
                frmQuickPicks.Hide();
                frmDebug.Hide();
                DialogResult dr = MessageBox.Show("You have performed manual rotation operations!\r\n\nAre you sure you want to re-Create?", "Create Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // put back whatever stay-on-tops were hidden
                if (quickPicksVisible) frmQuickPicks.Show();
                if (debugVisible) frmDebug.Show();

                if (dr == DialogResult.No)
                    return;
            }

            Log("Create", String.Format("Cube Size:{0}, Piece Size:{1}, Upper Color:{2}, Right Color:{3}, Down Color:{4}, Left Color:{5}, Front Color:{6}, Back Color:{7}, Outline Color:{8}, Highlight Color:{9}", (int)numCubeSize.Value, (int)numPieceSize.Value, btnUpper.BackColor, btnRight.BackColor, btnDown.BackColor, btnLeft.BackColor, btnFront.BackColor, btnBack.BackColor, btnOutline.BackColor, btnHighlight.BackColor));
            cube = new Cube((int)numCubeSize.Value, (int)numPieceSize.Value, btnUpper.BackColor, btnRight.BackColor, btnDown.BackColor, btnLeft.BackColor, btnFront.BackColor, btnBack.BackColor, btnOutline.BackColor, btnHighlight.BackColor);

            // if our select doesnt fit in the new cube size, clear it
            if (cube != null && (SelectedPieceZ > cube.Size - 1 || SelectedPieceX > cube.Size - 1 || SelectedPieceY > cube.Size - 1))
                ClearSelectedPiece();

            cube.SelectedPieceZ = SelectedPieceZ;
            cube.SelectedPieceX = SelectedPieceX;
            cube.SelectedPieceY = SelectedPieceY;

            ReDrawCube();

            // fresh cube, so flag to allow scramble, create, and close without a user warning
            beenRotated = false;

            // cube size might have changed so update the mins for dimension choices
            numZ.Maximum = cube.Size - 1;
            numX.Maximum = cube.Size - 1;
            numY.Maximum = cube.Size - 1;

            frmDebug.Cube = cube;
            frmQuickPicks.Cube = cube;
            frmQuickPicks.SetButtonAvailability();
        }

        private void btnScramble_Click(object sender, EventArgs e)
        {
            if (cube != null)
            {
                // in case did some solving working manually and accidentally clicked Scramble
                if (beenRotated)
                {
                    bool quickPicksVisible = frmQuickPicks.Visible;
                    bool debugVisible = frmDebug.Visible;

                    // hide the stay-on-top forms since they even cover the messagebox
                    frmQuickPicks.Hide();
                    frmDebug.Hide();
                    DialogResult dr = MessageBox.Show("You have performed manual rotation operations!\r\n\nAre you sure you want to re-Scramble?", "Scramble Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    // put back whatever stay-on-tops were hidden
                    if (quickPicksVisible) frmQuickPicks.Show();
                    if (debugVisible) frmDebug.Show();

                    if (dr == DialogResult.No)
                        return;
                }

                Log("Scramble");
                cube.Scramble();
                ReDrawCube();
                
                beenRotated = false;
            }
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (cube != null)
            {
                beenRotated = true;

                Plane plane = (Plane)cmbPlane.SelectedValue;
                Direction direction = (Direction)cmbDirection.SelectedValue;

                // the down faces rotate what seems opposite of the upper's direction
                // the left faces rotate what seems opposite of the right's direction
                // the back faces rotate what seems opposite of the front's direction
                bool invertDirection = false; 
                if (plane == Plane.Horizontal)
                    invertDirection = (SelectedPieceZ >= (cube.Size / 2) + (cube.Size % 2));
                else if (plane == Plane.VerticalDepth)
                    invertDirection = (SelectedPieceX < (cube.Size / 2));
                else
                    invertDirection = (SelectedPieceY < (cube.Size / 2));

                Log("Manual Rotate", String.Format("Z-Axis:{0}, X-Axis:{1}, Y-Axis:{2}, Plane:{3}, Direction:{4}", (int)numZ.Value, (int)numX.Value, (int)numY.Value, plane.GetDescription(), direction.GetDescription()));

                if (invertDirection)
                    if (direction == Direction.Clockwise)
                        direction = Direction.Counterclockwise;
                    else
                        direction = Direction.Clockwise;

                cube.Rotate((int)numZ.Value, (int)numX.Value, (int)numY.Value, plane, direction);
                ReDrawCube(checkIfSolved:true);
            }
        }

        public void ReDrawCube(bool checkIfSolved = false)
        {
            if (cube != null)
            {
                try
                {
                    cube.Draw(ref primaryImage, ref maskImage, (DrawType)drawTypes.First(r => r.Checked).Tag, (int)numPieceSize.Value);
                    picCanvas.Refresh();

                    if (frmDebug.Visible)
                        frmDebug.RefreshTree();

                    DrawSelectedPiece();

                    if (checkIfSolved)
                    {
                        beenRotated = true; // going to assume the caller did an action that manually modified the cube (otherwise a bug with the places that set checkIfSolved)
                        CheckIfSolved();
                    }
                }
                catch (Exception e)
                {
                    frmQuickPicks.Hide();
                    frmDebug.Hide();
                    MessageBox.Show("There was a problem while allocating memory for the image using the current configuration.  Please try reducing the dimension or slowing down your dang clicking.  You may have to restart the application.\r\n\r\nException: " + e.Message, "Rendering Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void numPieceSize_ValueChanged(object sender, EventArgs e)
        {
            if (cube != null)
            {
                //cube.PieceSize = (int)numPieceSize.Value;
                ReDrawCube();
            }
        }

        private void CheckIfSolved()
        {
            if (cube != null && cube.IsSolved())
            {
                Log("Solved");
                MessageBox.Show("Congratulations!", "Solved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                beenRotated = false;

                // if was on counterclockwise when you finished, trick it to toggle back to default of clockwise
                if (!frmQuickPicks.DoClockwise)
                {
                    frmQuickPicks.DoClockwise = false;
                    frmQuickPicks.ToggleDirection();
                }
            }
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            // the Paint event fires early, even before we can build a bitmap, so skip in that case
            if (primaryImage != null)
            {
                // the bitmap could always be changing size per user choice so adjust the parent panel in prep for draw (will cause the panel to add scrollbars automatially if to large for visible view)
                picCanvas.Width = primaryImage.Width;
                picCanvas.Height = primaryImage.Height;

                //e.Graphics.Clear(picCanvas.BackColor);
                e.Graphics.DrawImage(primaryImage, 0, 0, primaryImage.Width, primaryImage.Height);
            }
        }
        
        private void SelectColor(object sender, EventArgs e)
        {
            Color priorColor = ((Button)sender).BackColor;

            dlgColor.Color = ((Button)sender).BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                ((Button)sender).BackColor = dlgColor.Color;

                if (cube != null)
                {
                    Log("Color Change", String.Format("{0} Color changed from {1} to {2}", ((Button)sender).Tag, priorColor, ((Button)sender).BackColor));
                    cube.SetupPieces(btnUpper.BackColor, btnRight.BackColor, btnDown.BackColor, btnLeft.BackColor, btnFront.BackColor, btnBack.BackColor, btnOutline.BackColor, btnHighlight.BackColor, atCreationTime: false);
                    ReDrawCube();

                    // to avoid insta-solved if have not even messed with the cube post-create
                    if (beenRotated)
                        CheckIfSolved();
                }
            }
        }

        private void DrawStyle_CheckChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Log("Draw Style", ((RadioButton)sender).Text);
                ReDrawCube();
            }
        }

        private void btnQuickPicks_Click(object sender, EventArgs e)
        {
            if (frmQuickPicks.Visible)
                frmQuickPicks.Hide();
            else
                frmQuickPicks.Show();
        }

        private void FrmCubeSolver_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmQuickPicks.Close();
            frmDebug.Close();

            // then allow this form to close
            e.Cancel = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // in case did some solving working manually and accidentally clicked Close
            if (beenRotated)
            {
                bool quickPicksVisible = frmQuickPicks.Visible;
                bool debugVisible = frmDebug.Visible;

                // hide the stay-on-top forms since they even cover the messagebox
                frmQuickPicks.Hide();
                frmDebug.Hide();
                DialogResult dr = MessageBox.Show("You have performed manual rotation operations!\r\n\nAre you sure you want to Close?", "Close Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // put back whatever stay-on-tops were hidden
                if (quickPicksVisible) frmQuickPicks.Show();
                if (debugVisible) frmDebug.Show();

                if (dr == DialogResult.No)
                    return;
            }

            Close();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {

            if (cube != null)
            {
                if (frmDebug.Visible)
                    frmDebug.Hide();
                else
                {
                    frmDebug.RefreshTree();
                    frmDebug.Show();
                }
            }
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            // assuming having a primary image also built the maskImage (I need to blow up if that is not true since need to know!  dont feel like a try/catch atm)
            if (primaryImage != null)
            {
                Color color = maskImage.GetPixel(e.X, e.Y);

                // seems color comes back named "0" if clicked area is not drawn on (whew)
                if (color.Name == "0")
                {
                    //ClearSelectedPiece();
                }
                else
                {
                    // dig out the piece cords from the mask image color!  so glad this worked
                    SelectedPieceZ = color.R;
                    SelectedPieceX = color.G;
                    SelectedPieceY = color.B;

                    cube.SelectedPieceZ = SelectedPieceZ;
                    cube.SelectedPieceX = SelectedPieceX;
                    cube.SelectedPieceY = SelectedPieceY;

                    string selected = String.Format("[{0}][{1},{2}]", SelectedPieceZ, SelectedPieceX, SelectedPieceY);
                    Log("Cube Click", "Selected Piece:" + selected);
                    lblSelectedCoords.Text = selected;

                    // lets make the numeric up/downs match the selection too
                    numZ.Value = SelectedPieceZ;
                    numX.Value = SelectedPieceX;
                    numY.Value = SelectedPieceY;

                    DrawSelectedPiece();

                    cube.SetupPieces(btnUpper.BackColor, btnRight.BackColor, btnDown.BackColor, btnLeft.BackColor, btnFront.BackColor, btnBack.BackColor, btnOutline.BackColor, btnHighlight.BackColor, atCreationTime: false);
                    ReDrawCube();

                }
            }
            frmQuickPicks.SetButtonAvailability();
        }

        private void DrawSelectedPiece()
        {
            // assuming having a primary image also built the maskImage (I need to blow up if that is not true since need to know!  dont feel like a try/catch atm)
            if (primaryImage != null && SelectedPieceZ != -1)
            {
                cube.DrawSelectedPiece(ref selectedPieceImage, picSelected.Width, picSelected.Height, SelectedPieceZ, SelectedPieceX, SelectedPieceY);
                picSelected.Image = selectedPieceImage;
                picSelected.Refresh();
            }
            else
                ClearSelectedPiece();
        }

        private void pnlLeft_Click(object sender, EventArgs e)
        {
            //ClearSelectedPiece();
            //frmQuickPicks.SetButtonAvailability();
        }

        private void ClearSelectedPiece()
        {
            picSelected.Image = null;
            lblSelectedCoords.Text = "n/a";
            SelectedPieceZ = -1;
            SelectedPieceX = -1;
            SelectedPieceY = -1;
        }

        private void FrmCubeSolver_KeyDown(object sender, KeyEventArgs e)
        {
            // shift flips to counterclockwise
            if (e.Shift && frmQuickPicks.DoClockwise)
                frmQuickPicks.ToggleDirection();
        }

        private void FrmCubeSolver_KeyUp(object sender, KeyEventArgs e)
        {
            // UN-shift flips back to clockwise
            if (e.KeyCode == Keys.ShiftKey && !frmQuickPicks.DoClockwise)
                frmQuickPicks.ToggleDirection();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (cube.Size == 2)
                SolveAs2x2x2();
            else if (cube.Size == 3)
                SolveAs3x3x3();
            else if (cube.Size % 2 == 0)
                SolveAsLargeEven();
            else
                SolveAsLargeOdd();
        }

        private void SolveAs2x2x2()
        {
            Log("Auto-Solve", "2x2x2");
        }

        private void SolveAs3x3x3()
        {
            Color color;
            Log("Auto-Solve", "3x3x3 (Beginner's Method)");
            
            Log("Auto-Solve", "Step [1]:  SOLVE THE DOWN FACE CROSS (for ease of visibility, it will be built on the Upper face first then rotated to the bottom)");
            
            Log("Auto-Solve", "Step [1.a]: Pick the color intended to be the Down face.");
            color = cube.GetRandomFaceColor();
            Log("Auto-Solve", "Randomly selected " + color);

            Log("Auto-Solve", "Step [1.b]: Rotate the cube to have the center piece of the selected color on the Upper face.");
            //Log("Auto-Solve", "Rotate the cube to have the color of choice as the upper face center.");
            //Log("Auto-Solve", "While the upper cross is not completed:");
            //Log("Auto-Solve", "    Locate an edge belonging to the upper face that is not correctly up on the upper face.");
            //Log("Auto-Solve", "    If the located edge is on the upper face but not matching the correct face,");
            //Log("Auto-Solve", "        Move bad edge off of the upper face.");
            //Log("Auto-Solve", "    Move located edge up to the upper face.");
            Log("Auto-Solve", "Step [2]:  DOWN FACE CORNERS");
            Log("Auto-Solve", "This completes the first layer.");
            Log("Auto-Solve", "Step [3]:  MIDDLE LAYER EDGES");
            Log("Auto-Solve", "This completes the second layer."); 
            Log("Auto-Solve", "Step [4]:  UPPER FACE CROSS");
            Log("Auto-Solve", "Step [4.a]:  UPPER FACE EDGES ORIENTATION");
            Log("Auto-Solve", "Step [4.b]:  UPPER FACE EDGES POSITIONING");
            Log("Auto-Solve", "Step [5]:  UPPER FACE CORNER POSITIONING");
            Log("Auto-Solve", "Step [6]:  UPPER FACE CORNER ORIENTATION");
        }


        private void SolveAsLargeEven()
        {
            Log("Auto-Solve", String.Format("{0}x{0}x{0} - AUTO-SOLUTION NOT CODED YET.", cube.Size));
            Log("Auto-Solve", "Even-numbered cubes sizes 4 and above introduce the follow additional aspects:");
            Log("Auto-Solve", "1. Color orientatin determination since there is no fixed center piece for guidance.");
            Log("Auto-Solve", "2. Center building since each \"center\" is made up of multipe pieces.");
            Log("Auto-Solve", "3. Edge pairing since each \"edge\" is made up of multiple edges.");
            Log("Auto-Solve", "4. Multiple Parity errors to work through.");
        }

        private void SolveAsLargeOdd()
        {
            Log("Auto-Solve", String.Format("{0}x{0}x{0} - AUTO-SOLUTION NOT CODED YET.", cube.Size));
            Log("Auto-Solve", "Odd-numbered cubes sizes 5 and above introduce the follow additional aspects:");
            Log("Auto-Solve", "1. Center building since each \"center\" is made up of multipe pieces.");
            Log("Auto-Solve", "2. Edge pairing since each \"edge\" is made up of multiple edges.");
            Log("Auto-Solve", "3. Multiple Parity errors to work through (though less than the even-numbered larger cubes).");
        }
    }
}
