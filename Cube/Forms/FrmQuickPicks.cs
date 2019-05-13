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
using CubeSolver.Solvers;

namespace CubeSolver
{
    public partial class FrmQuickPicks : Form
    {
        private bool allowClose = false;
        private ILogger logger;
       
        private SolverQuickPicks solver;
        public SolverQuickPicks Solver
        { 
            get { return solver; }
            set { this.solver = value; }
        }

        public bool DoClockwise { get { return solver.DoClockwise; } }

        public FrmQuickPicks()
        {
            Init();
        }
        
        public FrmQuickPicks(SolverQuickPicks solver, ILogger logger)
        {
            Init();

            this.solver = solver;
            this.logger = logger;
        }

        private void Init()
        {
            InitializeComponent();

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
            if (e.Shift && solver.DoClockwise)
                ToggleDirection();
        }

        private void FrmQuickPicks_KeyUp(object sender, KeyEventArgs e)
        {
            // UN-shift flips back to clockwise
            if (e.KeyCode == Keys.ShiftKey && !solver.DoClockwise)
                ToggleDirection();
        }

        private void FrmQuickPicks_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            // allow the main form to decide if this form can close.  this prevents the X on this from from destroying the form, it only allows hiding it
            e.Cancel = !allowClose;
        }
        
        public void ToggleDirection()
        {
            if (solver.DoClockwise)
            {
                solver.DoClockwise = false;
                btnDirectionToggle.Text = "Counterclockwise";
            }
            else
            {
                solver.DoClockwise = true;
                btnDirectionToggle.Text = "Clockwise";
            }
        }

        private void HeaderClick(object sender, EventArgs e)
        {
            // toggle the viewing of buttons for a given category
            Panel activePanel = (Panel)((Button)sender).Tag;
            activePanel.Visible = !activePanel.Visible;
        }

        public void SetButtonAvailability()
        {
            if (solver != null && solver.Cube != null)
            {
                bool hasEdges = (solver.Cube.Size > 2);
                bool tooSmall = (solver.Cube.Size == 1);
                bool hasSelection = (solver.Cube.IsSelected());

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

                btnFunCheckered.Enabled = (Solver.Cube.Size % 2 > 0);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Full Cube
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnCH90_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text); 
            solver.CubeRotate90(Plane.Horizontal, (solver.DoClockwise ? Direction.Clockwise : Direction.Counterclockwise));
        }

        private void btnCVD90_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.CubeRotate90(Plane.VerticalDepth, (solver.DoClockwise ? Direction.Clockwise : Direction.Counterclockwise));
        }

        private void btnCVW90_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.CubeRotate90(Plane.VerticalWidth, (solver.DoClockwise ? Direction.Clockwise : Direction.Counterclockwise));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Full Layers
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void btnSingleLayerHorizontal90_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.SingleLayerRotate90(Plane.Horizontal);
        }

        private void btnSingleLayerVerticalDepth90_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.SingleLayerRotate90(Plane.VerticalDepth);
        }

        private void btnSingleLayerVerticalWidth90_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.SingleLayerRotate90(Plane.VerticalWidth);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Standard Algorithms
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnCrossCornerDropLeft_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.CrossCornerDropLeft();
        }

        private void btnCrossCornerDropRight_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.CrossCornerDropRight();
        }

        private void btnSGoHomeLeft_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.GoToYourHomeLeft();
        }

        private void btnSGoHomeRight_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.GoToYourHomeRight();
        }

        private void btnSDotToLToLineToCross_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.DotToLToLineToCross();
        }

        private void btnSLowerLeftEdgeSwap_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.LowerLeft_EdgeSwap();
        }

        private void UpperThreeCornerShift_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", String.Format("{0} ({1})", ((Button)sender).Text, (solver.DoClockwise ? "Clockwise" : "Counterclockwise")));
            solver.UpperThreeCornerShift();
        }

        private void btnSDownOverUpOver_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.DownOverUpOver();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Special Algorithms
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnRightCornersSwap_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.RightCornersSwap();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Fun Algorithms
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnFunCheckered_Click(object sender, EventArgs e)
        {
            logger.Log("Quick Pick", ((Button)sender).Text);
            solver.Checkered();
        }
    }
}
