using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSolver.Loggers
{
    public class CompositeLogger : ILogger
    {
        private List<ILogger> loggers = new List<ILogger>();

        public CompositeLogger(List<ILogger> loggers)
        {
            foreach (ILogger logger in loggers)
                this.loggers.Add(logger);
        }

        public void Clear()
        {
            foreach (ILogger logger in loggers)
                logger.Clear();
        }

        public void Log(string category)
        {
            foreach (ILogger logger in loggers)
                logger.Log(category, "");
        }

        public void Log(string category, string message)
        {
            foreach (ILogger logger in loggers)
                logger.Log(category, message);
        }
    }
}
