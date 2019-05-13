using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CubeSolver
{
    public partial class FrmQuickPicks : Form
    {
        public bool DoClockwise { get; set; }
        public FrmCubeSolver MainForm { get; set; }
        public Cube Cube { get; set; }

        private bool allowClose = false;

        public FrmQuickPicks()
        {
            InitializeComponent();

            DoClockwise = true;

            // connect headers to their panels for expand/collapse action
            btnFullCube.Tag = pnlFullCube;
            btnFullLayers.Tag = pnlFullLayers;
            btnStandard.Tag = pnlStandard;
            btnSpecial.Tag = pnlSpecial;
            btnFun.Tag = pnlFun;
        }

        private void FrmQuickPicks_KeyPress(object sender, KeyPressEventArgs e)
        {
            // always nice to have ESC key close an active window
            if (e.KeyChar == (char)Keys.Escape)
                Hide();
        }

        public void btnDirectionToggle_Click(object sender, EventArgs e)
        {
            ToggleDirection();
        }

        private void FrmQuickPicks_KeyDown(object sender, KeyEventArgs e)
        {
            // shift flips to counterclockwise
            if (e.Shift && DoClockwise)
                ToggleDirection();
        }

        private void FrmQuickPicks_KeyUp(object sender, KeyEventArgs e)
        {
            // UN-shift flips back to clockwise
            if (e.KeyCode == Keys.ShiftKey && !DoClockwise)
                ToggleDirection();
        }

        private void FrmQuickPicks_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            e.Cancel = !allowClose;
        }
        
        public void ToggleDirection()
        {
            if (DoClockwise)
            {
                DoClockwise = false;
                btnDirectionToggle.Text = "Counterclockwise";
            }
            else
            {
                DoClockwise = true;
                btnDirectionToggle.Text = "Clockwise";
            }
        }

        private void HeaderClick(object sender, EventArgs e)
        {
            // toggle the viewing of buttons for a given category
            Panel activePanel = (Panel)((Button)sender).Tag;
            activePanel.Visible = !activePanel.Visible;
        }

        private void Redraw(bool checkIfSolved=true)
        {
            MainForm.ReDrawCube(checkIfSolved);

            int delay = MainForm.Delay;
            if (delay > 0)
                System.Threading.Thread.Sleep(delay);
        }

        public void SetButtonAvailability()
        {
            bool hasEdges = (Cube.Size > 2);
            bool tooSmall = (Cube.Size == 1);
            bool hasSelection = (MainForm.SelectedPieceX != -1);

            // the 1x1x1 and 2x2x2 doesn't need edge-related algorithms
            btnFunCheckered.Enabled = hasEdges;
            btnSDotToLToLineToCross.Enabled = hasEdges;
            btnSGoHomeLeft.Enabled = hasEdges;
            btnSGoHomeRight.Enabled = hasEdges;
            btnSLowerLeftEdgeSwap.Enabled = hasEdges;

            // the 2x2x2 can use this special move (other cubes can too but my approach never needs it)
            btnRightCornersSwap.Enabled = !tooSmall && !hasEdges;

            btnCrossCornerDropLeft.Enabled = !tooSmall;
            btnCrossCornerDropRight.Enabled = !tooSmall;
            btnLayerHorizontal90.Enabled = !tooSmall && hasSelection;
            btnLayerVerticalDepth90.Enabled = !tooSmall && hasSelection;
            btnLayerVerticalWidth90.Enabled = !tooSmall && hasSelection;
            btnStandardDownOverUpOver.Enabled = !tooSmall;
            btnStandardUpperThreeShift.Enabled = !tooSmall;

            btnFunCheckered.Enabled = (Cube.Size % 2 > 0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Full Cube
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CubeRotate90(object sender, Plane plane, bool usingZ, bool usingX, bool usingY)
        {
            MainForm.Log("Quick Pick", ((Button)sender).Text); 
            
            int z = 0;
            int x = 0;
            int y = 0;

            // to turn every designated plane once
            for (int j = 0; j < Cube.Size; j++)
            {
                Cube.Rotate(z, x, y, plane, (DoClockwise ? Direction.Clockwise : Direction.Counterclockwise));
                MainForm.Log("Rotate", String.Format("Z-Axis:{0}, X-Axis:{1}, Y-Axis:{2}, Plane:{3}, Direction:{4}", z, x, y, plane.GetDescription(), (DoClockwise ? Direction.Clockwise.GetDescription() : Direction.Counterclockwise.GetDescription())));

                // common method here so having to only incement the dimension specific
                if (usingZ) z++;
                else if (usingX) x++;
                else if (usingY) y++;
            }
            Redraw(checkIfSolved: false);
        }

        private void btnCH90_Click(object sender, EventArgs e)
        {
            CubeRotate90(sender, Plane.Horizontal, usingZ: true, usingX: false, usingY: false);
        }

        private void btnCVD90_Click(object sender, EventArgs e)
        {
            CubeRotate90(sender, Plane.VerticalDepth, usingZ: false, usingX: true, usingY: false);
        }

        private void btnCVW90_Click(object sender, EventArgs e)
        {
            CubeRotate90(sender, Plane.VerticalWidth, usingZ: false, usingX: false, usingY: true);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Full Layers
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FullLayerRotate(int z, int x, int y, Plane plane, bool invertDirection)
        {
            MainForm.Log("Rotate", String.Format("Z-Axis:{0}, X-Axis:{1}, Y-Axis:{2}, Plane:{3}, Direction:{4}", z, x, y, plane, (DoClockwise ? Direction.Clockwise.GetDescription() : Direction.Counterclockwise.GetDescription())));

            if (invertDirection)
                Cube.Rotate(z, x, y, plane, (!DoClockwise ? Direction.Clockwise : Direction.Counterclockwise)); // for faces that rotate as if first turning to look at that face so it appears reversed (Left/Down/Back)
            else
                Cube.Rotate(z, x, y, plane, (DoClockwise ? Direction.Clockwise : Direction.Counterclockwise));

            Redraw();
        }

        public void btnSingleLayerHorizontal90_Click(object sender, EventArgs e)
        {
            // am I above the middle of the cube (where an odd-numbered center layer counts as the beginning of the upper layers)
            bool invertDirection = (MainForm.SelectedPieceZ >= (Cube.Size / 2) + (Cube.Size % 2));

            MainForm.Log("Quick Pick", ((Button)sender).Text);
            FullLayerRotate(MainForm.SelectedPieceZ, MainForm.SelectedPieceX, MainForm.SelectedPieceY, Plane.Horizontal, invertDirection);
        }

        private void btnSingleLayerVerticalDepth90_Click(object sender, EventArgs e)
        {
            // am I to the left of the middle of the cube (where an odd-numbered center layer counts as the beginning of the right layers)
            bool invertDirection = (MainForm.SelectedPieceX < (Cube.Size / 2));

            MainForm.Log("Quick Pick", ((Button)sender).Text);
            FullLayerRotate(MainForm.SelectedPieceZ, MainForm.SelectedPieceX, MainForm.SelectedPieceY, Plane.VerticalDepth, invertDirection);
        }

        private void btnSingleLayerVerticalWidth90_Click(object sender, EventArgs e)
        {
            // am I towards the back of the cube (where an odd-numbered center layer counts as the beginning of the front layers)
            bool invertDirection = (MainForm.SelectedPieceY < (Cube.Size / 2));

            MainForm.Log("Quick Pick", ((Button)sender).Text);
            FullLayerRotate(MainForm.SelectedPieceZ, MainForm.SelectedPieceX, MainForm.SelectedPieceY, Plane.VerticalWidth, invertDirection);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Standard Algorithms
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void AlgorithmRotate(int z, int x, int y, Plane plane, Direction direction)
        {
            MainForm.Log("Rotate", String.Format("Z-Axis:{0}, X-Axis:{1}, Y-Axis:{2}, Plane:{3}, Direction:{4}", z, x, y, plane, direction));
            Cube.Rotate(z, x, y, plane, direction);
            Redraw();
        }

        private void btnCrossCornerDropLeft_Click(object sender, EventArgs e)
        {
            MainForm.Log("Quick Pick", ((Button)sender).Text);

            AlgorithmRotate(0, 0, Cube.Size - 1, Plane.VerticalWidth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, Cube.Size - 1, Plane.VerticalWidth, Direction.Clockwise);
        }

        private void btnCrossCornerDropRight_Click(object sender, EventArgs e)
        {
            MainForm.Log("Quick Pick", ((Button)sender).Text);

            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
        }

        private void btnSGoHomeLeft_Click(object sender, EventArgs e)
        {
            MainForm.Log("Quick Pick", ((Button)sender).Text);

            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, Cube.Size - 1, Plane.VerticalWidth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, 0, Cube.Size - 1, Plane.VerticalWidth, Direction.Clockwise);
        }

        private void btnSGoHomeRight_Click(object sender, EventArgs e)
        {
            MainForm.Log("Quick Pick", ((Button)sender).Text);

            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, Cube.Size - 1, Plane.VerticalWidth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, 0, Cube.Size - 1, Plane.VerticalWidth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
        }

        private void btnSDotToLToLineToCross_Click(object sender, EventArgs e)
        {
            MainForm.Log("Quick Pick", ((Button)sender).Text);

            AlgorithmRotate(0, 0, Cube.Size - 1, Plane.VerticalWidth, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, Cube.Size - 1, Plane.VerticalWidth, Direction.Counterclockwise);
        }

        private void btnSLoweLeftEdgeSwap_Click(object sender, EventArgs e)
        {
            MainForm.Log("Quick Pick", ((Button)sender).Text);

            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
        }

        private void UpperThreeCornerShift_Click(object sender, EventArgs e)
        {
            MainForm.Log("Quick Pick", String.Format("{0} ({1})", ((Button)sender).Text, (DoClockwise ? "Clockwise" : "Counterclockwise")));

            if (DoClockwise)
            {
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.VerticalDepth, Direction.Clockwise); // actually counter, but the matrix system I used is backwords for faces that rotate as if looking AT them
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
                AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.VerticalDepth, Direction.Counterclockwise);  // actually clockwise, but the matrix system I used is backwords for faces that rotate as if looking AT them
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
                AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            }
            else
            {
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
                AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.VerticalDepth, Direction.Clockwise); // actually counter, but the matrix system I used is backwords for faces that rotate as if looking AT them
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
                AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.VerticalDepth, Direction.Counterclockwise);  // actually clockwise, but the matrix system I used is backwords for faces that rotate as if looking AT them
            }
        }

        private void btnSDownOverUpOver_Click(object sender, EventArgs e)
        {
            MainForm.Log("Quick Pick", ((Button)sender).Text);

            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(Cube.Size - 1, 0, 0, Plane.Horizontal, Direction.Clockwise);  // actually counter, but the matrix system I used is backwords for faces that rotate as if looking AT them
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(Cube.Size - 1, 0, 0, Plane.Horizontal, Direction.Counterclockwise);  // actually clockwise, but the matrix system I used is backwords for faces that rotate as if looking AT them
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Special Algorithms
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnRightCornersSwap_Click(object sender, EventArgs e)
        {
            MainForm.Log("Quick Pick", ((Button)sender).Text);

            // part 1
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            // part 2: rotate whole cube counterclockwise
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(Cube.Size -1, 0, 0, Plane.Horizontal, Direction.Counterclockwise);  // actually clockwise, but the matrix system I used is backwords for faces that rotate as if looking AT them
            // part 3
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, Cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            // final
            AlgorithmRotate(Cube.Size - 1, 0, 0, Plane.Horizontal, Direction.Clockwise);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Fun Algorithms
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnFunCheckered_Click(object sender, EventArgs e)
        {
            MainForm.Log("Quick Pick", ((Button)sender).Text);

            // part 1: rotate up every other vertical depth
            for (int x = 0; x < Cube.Size; x += 2)
            {
                bool invertDirection = (x < (Cube.Size / 2));

                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
            }

            // part 2: rotate whole cube horizontally clockwise 
            CubeRotate90(sender, Plane.Horizontal, usingZ: true, usingX: false, usingY: false);

            // part 3: rotate up every other vertical depth per the new face facing front
            for (int x = 0; x < Cube.Size; x += 2)
            {
                bool invertDirection = (x < (Cube.Size / 2));

                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
            }

            // part 4: rotate whole cube vertical-widthly clockwise (barrel roll)
            CubeRotate90(sender, Plane.VerticalWidth, usingZ: false, usingX: false, usingY: true);

            // part 5: rotate up every other vertical depth per the final new face facing front
            for (int x = 0; x < Cube.Size; x += 2)
            {
                bool invertDirection = (x < (Cube.Size / 2));

                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
            }
        }
    }
}
