using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeSolver.Core;
using CubeSolver.Loggers;

namespace CubeSolver.Solvers
{
    class SolverLarge : Solver3x3x3
    {
        public SolverLarge(Cube cube, ILogger logger, int delay, Action<bool> drawMethod) 
            : base(cube, logger, delay, drawMethod)
        {

        }

        public override void Solve()
        {

        }
    }
}
