using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeSolver.Core;
using CubeSolver.Loggers;

namespace CubeSolver.Solvers
{
    class Solver2x2x2 : SolverBase
    {
        public Solver2x2x2(Cube cube, ILogger logger, int delay, Action<bool> drawMethod) 
            : base(cube, logger, delay, drawMethod)
        {

        }

        public override void Solve()
        {
            logger.Log("Auto-Solve", "2x2x2");
        }
    }
}
