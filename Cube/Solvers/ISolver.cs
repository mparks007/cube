using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSolver.Solvers
{
    interface ISolver
    {
        void Solve();
        void Redraw(bool checkIfSolved);
        void Delay();
    }
}
