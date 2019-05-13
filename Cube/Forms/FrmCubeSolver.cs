using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CubeSolver.Core;
using CubeSolver.Enums;
using CubeSolver.Utils;
using CubeSolver.Loggers;
using CubeSolver.Renderers;
using CubeSolver.Solvers;

namespace CubeSolver
{
    public partial class FrmCubeSolver : Form
    {
        private Cube cube;
        private List<RadioButton> drawTypes = new List<RadioButton>();
        private bool beenManuallyRotated = false;
        private FrmQuickPicks frmQuickPicks;
        
        private CompositeLogger logger;
        private RenderBase primaryRenderer;
        private RenderAsBitmapSelectedPiece selectedPieceRenderer;

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

            logger = new CompositeLogger(new List<ILogger> { new TextBoxLogger(txtLog), new FileSystemLogger("log.txt")});
            logger.Log("CubeSolver by Matt J. Parks");

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
            radDrawGrid.Tag = (int)DrawType.UglyGrid;
            radDrawSplitStack.Tag = (int)DrawType.SplitStack;
            radDrawUnfold.Tag = (int)DrawType.Unfold;
            // then store as list to easy find out which is selected later
            drawTypes.AddRange(new List<RadioButton> { radDraw3D, radDrawGrid, radDrawSplitStack, radDrawUnfold });
        }

        private void FrmCubeSolver_Load(object sender, EventArgs e)
        {
            frmQuickPicks = new FrmQuickPicks(new SolverQuickPicks(null, logger, (int)numDelay.Value, Redraw), logger);
            frmQuickPicks.Owner = this;
            frmQuickPicks.Left = Left + (int)(Width / 2);
            frmQuickPicks.Top = Top;

            // might as well start with a standard cube already created
            Create();
            SetRenderer(DrawType.ThreeD);
            Redraw();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Create();
            SetRenderer((DrawType)drawTypes.First(r => r.Checked).Tag); 
            Redraw();
        }

        private void Create()
        {
            if (ContinueOperationAfterUserWarning("Create Warning", "You have performed manual rotation operations!\r\n\nAre you sure you want to re-Create?"))
            {
                logger.Log("Create", String.Format("Cube Size:{0}, Piece Size:{1}, Upper Color:{2}, Right Color:{3}, Down Color:{4}, Left Color:{5}, Front Color:{6}, Back Color:{7}, Outline Color:{8}, Highlight Color:{9}", (int)numCubeSize.Value, (int)numPieceSize.Value, btnUpper.BackColor, btnRight.BackColor, btnDown.BackColor, btnLeft.BackColor, btnFront.BackColor, btnBack.BackColor, btnOutline.BackColor, btnHighlight.BackColor));

                if (cube != null)
                    cube.Dispose();

                cube = new Cube((int)numCubeSize.Value, (int)numPieceSize.Value, btnUpper.BackColor, btnRight.BackColor, btnDown.BackColor, btnLeft.BackColor, btnFront.BackColor, btnBack.BackColor, btnOutline.BackColor, btnHighlight.BackColor);

                // if our axis index selections don't fit in the new cube size, clear it
                if (SelectedPieceZ > cube.Size - 1 || SelectedPieceX > cube.Size - 1 || SelectedPieceY > cube.Size - 1)
                    ClearSelectedPiece();
                else
                    cube.SetSelectedPiece(SelectedPieceZ, SelectedPieceX, SelectedPieceY);

                // fresh cube, so flag to allow scramble, create, and close without a user warning
                beenManuallyRotated = false;

                // cube size might have changed so update the max for dimension choices
                numZ.Maximum = cube.Size - 1;
                numX.Maximum = cube.Size - 1;
                numY.Maximum = cube.Size - 1;

                frmQuickPicks.Solver.SetCube(cube);
                frmQuickPicks.SetButtonAvailability();
            }
        }

        private void btnScramble_Click(object sender, EventArgs e)
        {
            if (cube != null)
            {
                if (ContinueOperationAfterUserWarning("Scramble Warning", "You have performed manual rotation operations!\r\n\nAre you sure you want to re-Scramble?"))
                {
                    logger.Log("Scramble");
                    cube.Scramble();
                    Redraw();

                    beenManuallyRotated = false;
                }
            }
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (cube != null)
            {
                beenManuallyRotated = true;

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

                logger.Log("Manual Rotate", String.Format("Z-Axis:{0}, X-Axis:{1}, Y-Axis:{2}, Plane:{3}, Direction:{4}", (int)numZ.Value, (int)numX.Value, (int)numY.Value, plane.GetDescription(), direction.GetDescription()));

                if (invertDirection)
                    if (direction == Direction.Clockwise)
                        direction = Direction.Counterclockwise;
                    else
                        direction = Direction.Clockwise;

                cube.Rotate((int)numZ.Value, (int)numX.Value, (int)numY.Value, plane, direction);
                primaryRenderer.Render();
                Redraw(checkIfSolved:true);
            }
        }


        private void numPieceSize_ValueChanged(object sender, EventArgs e)
        {
            if (cube != null)
            {
                SetRenderer((DrawType)drawTypes.First(r => r.Checked).Tag);
                Redraw();
            }
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (primaryRenderer != null)
            {
                try
                {
                    primaryRenderer.Render();

                    Bitmap renderedBitmap = ((RenderAsBitmapBase)primaryRenderer).PrimaryBitmap;

                    picCanvas.Width = renderedBitmap.Width;
                    picCanvas.Height = renderedBitmap.Height;

                    e.Graphics.Clear(picCanvas.BackColor);
                    e.Graphics.DrawImage(renderedBitmap, 0, 0, renderedBitmap.Width, renderedBitmap.Height);
                }
                catch (Exception ex)
                {
                    frmQuickPicks.Hide();
                    
                    MessageBox.Show("There was a problem redenering the cube for the current configuration.  Please try reducing the dimension or slowing down your dang clicking.  You may have to restart the application.\r\n\r\nException: " + ex.Message, "Rendering Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DrawSelectedPiece()
        {
            if (cube != null)
            {
                if (selectedPieceRenderer == null)
                    selectedPieceRenderer = new RenderAsBitmapSelectedPiece(cube, 30, picSelected.Width, picSelected.Height);
                else
                    selectedPieceRenderer.UpdateCube(cube);

                selectedPieceRenderer.Render();

                picSelected.Image = selectedPieceRenderer.PrimaryBitmap;
                picSelected.Refresh();
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
                    logger.Log("Color Change", String.Format("{0} Color changed from {1} to {2}", ((Button)sender).Tag, priorColor, ((Button)sender).BackColor));
                    cube.SetupPieces(btnUpper.BackColor, btnRight.BackColor, btnDown.BackColor, btnLeft.BackColor, btnFront.BackColor, btnBack.BackColor, btnOutline.BackColor, btnHighlight.BackColor, atCreationTime: false);
                    Redraw();
                }
            }
        }

        private void DrawStyle_CheckChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                logger.Log("Draw Style", ((RadioButton)sender).Text);
                SetRenderer((DrawType)drawTypes.First(r => r.Checked).Tag);
                Redraw();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //if (ContinueAfterUserWarning("Close Warning", "You have performed manual rotation operations!\r\n\nAre you sure you want to Close?"))
                Close();
        }

        private void FrmCubeSolver_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ContinueOperationAfterUserWarning("Close Warning", "You have performed manual rotation operations!\r\n\nAre you sure you want to Close?"))
            {
                frmQuickPicks.Close();

                // then allow this form to close
                e.Cancel = false;
            }
        }
        
        private void btnQuickPicks_Click(object sender, EventArgs e)
        {
            if (frmQuickPicks.Visible)
                frmQuickPicks.Hide();
            else
                frmQuickPicks.Show();
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (cube != null)
            {
                if (cube.Size == 1 && cube.IsSelected())
                    return;

                Color color = ((RenderAsBitmapBase)primaryRenderer).MaskBitmap.GetPixel(e.X, e.Y);

                // clicking outside the colors of the cube returns a "0" named color.  handy
                if (color.Name != "0")
                {
                    // dig out the piece cords from the mask image color!  so glad this worked
                    SelectedPieceZ = color.R;
                    SelectedPieceX = color.G;
                    SelectedPieceY = color.B;

                    cube.SetSelectedPiece(SelectedPieceZ, SelectedPieceX, SelectedPieceY);

                    string selected = String.Format("[{0}][{1},{2}]", SelectedPieceZ, SelectedPieceX, SelectedPieceY);
                    logger.Log("Cube Click", "Selected Piece:" + selected);
                    lblSelectedCoords.Text = selected;

                    // lets make the numeric up/downs match the selection too
                    numZ.Value = SelectedPieceZ;
                    numX.Value = SelectedPieceX;
                    numY.Value = SelectedPieceY;

                    frmQuickPicks.SetButtonAvailability();

                    // TODO: extremely wasteful to redraw the whole cube just to add a hilight but maybe will fix later
                    Redraw();
                }
            }
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
            if (cube != null && primaryRenderer != null && logger != null)
            {
                if (cube.Size == 1)
                    return;

                ISolver solver;

                if (cube.Size == 2)
                    solver = new Solver2x2x2(cube, logger, (int)numDelay.Value, Redraw);
                else if (cube.Size == 3)
                    solver = new Solver3x3x3(cube, logger, (int)numDelay.Value, Redraw);
                else if (cube.Size % 2 == 0)
                    solver = new SolverLargeEven(cube, logger, (int)numDelay.Value, Redraw);
                else
                    solver = new SolverLargeOdd(cube, logger, (int)numDelay.Value, Redraw);

                solver.Solve();
            }
        }

        private void numDelay_ValueChanged(object sender, EventArgs e)
        {
            frmQuickPicks.Solver.SetDelay((int)numDelay.Value);
        }

        public void Redraw(bool checkIfSolved = false)
        {
            if (cube != null && primaryRenderer != null)
            {
                if (chkDefer.Checked)
                    picCanvas.Invalidate();
                else
                    picCanvas.Refresh();

                DrawSelectedPiece();

                if (checkIfSolved)
                {
                    beenManuallyRotated = true; // going to assume the caller did an action that manually modified the cube (otherwise a bug with the places that set checkIfSolved)
                    CheckIfSolved();
                }
            }
        }

        private bool ContinueOperationAfterUserWarning(string caption, string message)
        {
            // in case did some solving working manually and accidentally clicked Scramble
            if (beenManuallyRotated)
            {
                bool quickPicksVisible = frmQuickPicks.Visible;

                // hide the stay-on-top forms since they even cover the messagebox
                frmQuickPicks.Hide();

                DialogResult dr = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // put back whatever stay-on-tops were hidden
                if (quickPicksVisible)
                    frmQuickPicks.Show();

                if (dr == DialogResult.No)
                    return false;
            }
            return true;
        }

        private void CheckIfSolved()
        {
            if (cube != null && cube.IsSolved())
            {
                logger.Log("Solved");
                MessageBox.Show("Congratulations!", "Solved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                beenManuallyRotated = false;

                // if was on counterclockwise when you finished, trick it to toggle back to default of clockwise
                if (!frmQuickPicks.DoClockwise)
                    frmQuickPicks.ToggleDirection();
            }
        }

        private void ClearSelectedPiece()
        {
            picSelected.Image = null;
            lblSelectedCoords.Text = "n/a";

            SelectedPieceZ = -1;
            SelectedPieceX = -1;
            SelectedPieceY = -1;
        }

        private void SetRenderer(DrawType drawType)
        {
            if (primaryRenderer != null)
                primaryRenderer.Dispose();

            switch (drawType)
            {
                case DrawType.ThreeD:
                    primaryRenderer = new RenderAsBitmapThreeD(cube, (int)numPieceSize.Value);
                    break;
                case DrawType.Unfold:
                    primaryRenderer = new RenderAsBitmapUnFold(cube, (int)numPieceSize.Value);
                    break;
                case DrawType.SplitStack:
                    primaryRenderer = new RenderAsBitmapSplitStack(cube, (int)numPieceSize.Value);
                    break;
                case DrawType.UglyGrid:
                    primaryRenderer = new RenderAsBitmapUglyGrid(cube, (int)numPieceSize.Value);
                    break;
                default:
                    primaryRenderer = null;
                    break;
            }
        }

    }
}
