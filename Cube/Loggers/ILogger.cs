using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSolver.Loggers
{
    public interface ILogger
    {
        void Clear();
        void Log(string category);
        void Log(string category, string message);
    }
}
