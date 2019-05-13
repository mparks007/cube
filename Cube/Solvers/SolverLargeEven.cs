using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeSolver.Core;
using CubeSolver.Loggers;

namespace CubeSolver.Solvers
{
    class SolverLargeEven : SolverLarge
    {
        public SolverLargeEven(Cube cube, ILogger logger, int delay, Action<bool> drawMethod) 
            : base(cube, logger, delay, drawMethod)
        {

        }

        public override void Solve()
        {
            logger.Log("Auto-Solve", String.Format("{0}x{0}x{0} - AUTO-SOLUTION NOT CODED YET.", cube.Size));
            logger.Log("Auto-Solve", "Even-numbered cubes sizes 4 and above introduce the follow additional aspects:");
            logger.Log("Auto-Solve", "1. Color orientatin determination since there is no fixed center piece for guidance.");
            logger.Log("Auto-Solve", "2. Center building since each \"center\" is made up of multipe pieces.");
            logger.Log("Auto-Solve", "3. Edge pairing since each \"edge\" is made up of multiple edges.");
            logger.Log("Auto-Solve", "4. Multiple Parity errors to work through.");
        }
    }
}
