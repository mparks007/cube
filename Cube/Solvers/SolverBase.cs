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
    abstract public class SolverBase : ISolver
    {
        protected Cube cube;
        public Cube Cube
        {
            get { return cube; }
        }

        protected ILogger logger;
        protected int delay;
        
        protected Action<bool> ExternalDraw;

        public SolverBase(Cube cube, ILogger logger, int delay, Action<bool> drawMethod)
        {
            this.cube = cube;
            this.logger = logger;
            this.delay = delay;
            this.ExternalDraw = drawMethod;
        }

        public virtual void Solve()
        {
            throw new NotImplementedException("Should use derived classes for Solve.");
        }

        public virtual void Redraw(bool checkIfSolved = true)
        {
            if (this.ExternalDraw != null)
                this.ExternalDraw(checkIfSolved);
        }

        public void Delay()
        {
            // TODO: a better way
            if (delay > 0)
                System.Threading.Thread.Sleep(delay);
        }

        public void CubeRotate90(Plane plane, Direction direction)
        {
            int z = 0;
            int x = 0;
            int y = 0;

            // to turn every designated plane once
            for (int i = 0; i < Cube.Size; i++)
            {
                logger.Log("Rotate", String.Format("Z-Axis:{0}, X-Axis:{1}, Y-Axis:{2}, Plane:{3}, Direction:{4}", z, x, y, plane.GetDescription(), direction.GetDescription()));
                cube.Rotate(z, x, y, plane, direction);

                // increment the dimension specific to the plan being rotated (horizontal does every z down the cube, etc.)
                if (plane == Plane.Horizontal)
                    z++;
                else if (plane == Plane.VerticalDepth)
                    x++;
                else
                    y++;
            }
            Redraw(checkIfSolved: false);
        }

        public void SingleLayerRotate90(int axis, Plane plane, Direction direction)
        {
            int z = 0;
            int x = 0;
            int y = 0;

            bool invertDirection = false;
            switch (plane)
            {
                case Plane.Horizontal:
                    // am I above the middle of the cube (where an odd-numbered center layer counts as the beginning of the upper layers)
                    invertDirection = (axis >= (cube.Size / 2) + (cube.Size % 2));
                    z = axis;
                    break;
                case Plane.VerticalDepth:
                    // am I to the left of the middle of the cube (where an odd-numbered center layer counts as the beginning of the right layers)
                    invertDirection = (axis < (cube.Size / 2));
                    x = axis;
                    break;
                case Plane.VerticalWidth:
                    // am I towards the back of the cube (where an odd-numbered center layer counts as the beginning of the front layers)
                    invertDirection = (axis < (cube.Size / 2));
                    y = axis;
                    break;
            }

            // logging HERE since I want to log the direction before I potentially invert it to deal with how I rotate.  also, we have the z, y, x set at this point.
            logger.Log("Rotate", String.Format("Z-Axis:{0}, X-Axis:{1}, Y-Axis:{2}, Plane:{3}, Direction:{4}", z, x, y, plane.GetDescription(), direction.GetDescription()));

            if (invertDirection)
            {
                if (direction == Direction.Clockwise)
                    direction = Direction.Counterclockwise;
                else
                    direction = Direction.Clockwise;
            }

            Cube.Rotate(z, x, y, plane, direction);
            Redraw(checkIfSolved: true);
        }

    }
}
