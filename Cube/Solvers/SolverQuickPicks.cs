using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeSolver.Core;
using CubeSolver.Loggers;
using CubeSolver.Enums;
using CubeSolver.Utils;

namespace CubeSolver.Solvers
{
    public class SolverQuickPicks : SolverBase
    {
        public bool DoClockwise { get; set; }

        public SolverQuickPicks(Cube cube, ILogger logger, int delay, Action<bool> drawMethod)
            : base(cube, logger, delay, drawMethod)
        {
            DoClockwise = true;
        }

        public void SetCube(Cube cube)
        {
            this.cube = cube;
        }

        public void SetDelay(int delay)
        {
            this.delay = delay;
        }

        private void Redraw(bool checkIfSolved, bool useDelay = false)
        {
            base.Redraw(checkIfSolved);
            
            if (useDelay)
                Delay();
        }

        private Direction GetDirectionAfterCounterCheck(int z, int x, int y, Plane plane, Direction direction)
        {
            bool invertDirection = false;
            switch (plane)
            {
                case Plane.Horizontal:
                    // am I above the middle of the cube (where an odd-numbered center layer counts as the beginning of the upper layers)
                    invertDirection = (z >= (cube.Size / 2) + (cube.Size % 2));
                    break;
                case Plane.VerticalDepth:
                    // am I to the left of the middle of the cube (where an odd-numbered center layer counts as the beginning of the right layers)
                    invertDirection = (x < (cube.Size / 2));
                    break;
                case Plane.VerticalWidth:
                    // am I towards the back of the cube (where an odd-numbered center layer counts as the beginning of the front layers)
                    invertDirection = (y < (cube.Size / 2));
                    break;
            }

            if (invertDirection)
            {
                if (direction == Direction.Clockwise)
                    direction = Direction.Counterclockwise;
                else
                    direction = Direction.Clockwise;
            }

            return direction;
        }

        public void SingleLayerRotate90(Plane plane)
        {
            if (cube.IsSelected())
            {
                Direction direction = (DoClockwise ? Direction.Clockwise : Direction.Counterclockwise);

                logger.Log("Rotate", String.Format("Z-Axis:{0}, X-Axis:{1}, Y-Axis:{2}, Plane:{3}, Direction:{4}", cube.SelectedPieceZ, cube.SelectedPieceX, cube.SelectedPieceY, plane.GetDescription(), direction.GetDescription()));

                cube.Rotate(plane, GetDirectionAfterCounterCheck(cube.SelectedPieceZ, cube.SelectedPieceX, cube.SelectedPieceY, plane, direction));
                Redraw(checkIfSolved: true);
            }
        }

        private void AlgorithmRotate(int z, int x, int y, Plane plane, Direction direction)
        {
            logger.Log("Rotate", String.Format("Z-Axis:{0}, X-Axis:{1}, Y-Axis:{2}, Plane:{3}, Direction:{4}", z, x, y, plane, direction));
            cube.Rotate(z, x, y, plane, GetDirectionAfterCounterCheck(z, x, y, plane, direction));
            Redraw(checkIfSolved: true, useDelay: true);
        }

        public void CrossCornerDropLeft()
        {
            AlgorithmRotate(0, 0, cube.Size - 1, Plane.VerticalWidth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, cube.Size - 1, Plane.VerticalWidth, Direction.Clockwise);
        }

        public void CrossCornerDropRight()
        {
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
        }

        public void GoToYourHomeLeft()
        {
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, cube.Size - 1, Plane.VerticalWidth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, 0, cube.Size - 1, Plane.VerticalWidth, Direction.Clockwise);
        }

        public void GoToYourHomeRight()
        {
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, cube.Size - 1, Plane.VerticalWidth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, 0, cube.Size - 1, Plane.VerticalWidth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
        }

        public void DotToLToLineToCross()
        {
            AlgorithmRotate(0, 0, cube.Size - 1, Plane.VerticalWidth, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, cube.Size - 1, Plane.VerticalWidth, Direction.Counterclockwise);
        }

        public void LowerLeft_EdgeSwap()
        {
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
        }

        public void UpperThreeCornerShift()
        {
            if (DoClockwise)
            {
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.VerticalDepth, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
                AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.VerticalDepth, Direction.Clockwise);
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
                AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            }
            else
            {
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
                AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.VerticalDepth, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
                AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
                AlgorithmRotate(0, 0, 0, Plane.VerticalDepth, Direction.Clockwise);
            }
        }

        public void DownOverUpOver()
        {
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(cube.Size - 1, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(cube.Size - 1, 0, 0, Plane.Horizontal, Direction.Clockwise);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Special Algorithms
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RightCornersSwap()
        {
            // 2x2x2 only

            // part 1
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            // part 2: rotate whole cube counterclockwise (Since for 2x2x2, only need to do Upper and Down face)
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(cube.Size - 1, 0, 0, Plane.Horizontal, Direction.Clockwise); //
            // part 3
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Counterclockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Counterclockwise);
            AlgorithmRotate(0, 0, 0, Plane.Horizontal, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            AlgorithmRotate(0, cube.Size - 1, 0, Plane.VerticalDepth, Direction.Clockwise);
            // final
            AlgorithmRotate(cube.Size - 1, 0, 0, Plane.Horizontal, Direction.Clockwise);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Fun Algorithms
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Checkered()
        {
            // part 1: rotate up every other vertical depth
            for (int x = 0; x < cube.Size; x += 2)
            {
                bool invertDirection = (x < (cube.Size / 2));

                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
            }

            // part 2: rotate whole cube horizontally clockwise 
            CubeRotate90(Plane.Horizontal, Direction.Clockwise);
            Delay();

            // part 3: rotate up every other vertical depth per the new face facing front
            for (int x = 0; x < cube.Size; x += 2)
            {
                bool invertDirection = (x < (cube.Size / 2));

                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
            }

            // part 4: rotate whole cube vertical-widthly clockwise (barrel roll)
            CubeRotate90(Plane.VerticalWidth, Direction.Clockwise);
            Delay();

            // part 5: rotate up every other vertical depth per the final new face facing front
            for (int x = 0; x < cube.Size; x += 2)
            {
                bool invertDirection = (x < (cube.Size / 2));

                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
                AlgorithmRotate(0, x, 0, Plane.VerticalDepth, (invertDirection ? Direction.Counterclockwise : Direction.Clockwise));
            }
        }
    }
}
