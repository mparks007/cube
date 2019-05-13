using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CubeSolver.Core;
using CubeSolver.Loggers;
using CubeSolver.Enums;

namespace CubeSolver.Solvers
{
    class Solver3x3x3 : Solver2x2x2
    {
        public Solver3x3x3(Cube cube, ILogger logger, int delay, Action<bool> drawMethod) 
            : base(cube, logger, delay, drawMethod)
        {

        }

        public override void Solve()
        {
            Color color;
            logger.Log("Auto-Solve", "3x3x3 (Beginner's Method)");

            logger.Log("Auto-Solve", "Step [1]:  SOLVE THE DOWN FACE CROSS (for ease of visibility, it will be built on the Upper face first then rotated to the bottom)");

            logger.Log("Auto-Solve", "Step [1.a]: Pick the color intended to be the Down face.");
            color = cube.GetRandomFaceColor();
            logger.Log("Auto-Solve", "Randomly selected " + color);

            // quick callback test
            for (int i = 0; i < 5; i++)
            {
                logger.Log("Auto-Solve", String.Format("Z-Axis:{0}, X-Axis:{1}, Y-Axis:{2}, Plane:{3}, Direction:{4}", 0,0,0, Plane.Horizontal, Direction.Clockwise));
                CubeRotate90(Plane.Horizontal, Direction.Clockwise);
                ExternalDraw(true);
                if (cube.IsSolved())
                    return;
                if (delay > 0)
                    System.Threading.Thread.Sleep(delay);
            }

            logger.Log("Auto-Solve", "Step [1.b]: Rotate the cube to have the center piece of the selected color on the Upper face.");
            //logger.Log("Auto-Solve", "Rotate the cube to have the color of choice as the upper face center.");
            //logger.Log("Auto-Solve", "While the upper cross is not completed:");
            //logger.Log("Auto-Solve", "    Locate an edge belonging to the upper face that is not correctly up on the upper face.");
            //logger.Log("Auto-Solve", "    If the located edge is on the upper face but not matching the correct face,");
            //logger.Log("Auto-Solve", "        Move bad edge off of the upper face.");
            //logger.Log("Auto-Solve", "    Move located edge up to the upper face.");
            logger.Log("Auto-Solve", "Step [2]:  DOWN FACE CORNERS");
            logger.Log("Auto-Solve", "This completes the first layer.");
            logger.Log("Auto-Solve", "Step [3]:  MIDDLE LAYER EDGES");
            logger.Log("Auto-Solve", "This completes the second layer.");
            logger.Log("Auto-Solve", "Step [4]:  UPPER FACE CROSS");
            logger.Log("Auto-Solve", "Step [4.a]:  UPPER FACE EDGES ORIENTATION");
            logger.Log("Auto-Solve", "Step [4.b]:  UPPER FACE EDGES POSITIONING");
            logger.Log("Auto-Solve", "Step [5]:  UPPER FACE CORNER POSITIONING");
            logger.Log("Auto-Solve", "Step [6]:  UPPER FACE CORNER ORIENTATION");
        }
    }
}
