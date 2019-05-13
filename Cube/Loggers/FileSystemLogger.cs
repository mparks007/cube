using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSolver.Loggers
{
    
    public class FileSystemLogger : ILogger, IDisposable
    {
        private bool disposed = false; 
        private System.IO.StreamWriter file;

        public FileSystemLogger(string filename)
        {
            if (!String.IsNullOrEmpty(filename))
                file = new System.IO.StreamWriter(filename, append:true);
            else
                throw new ArgumentException("Missing filename");
        }

        public void Clear()
        {
            // nah.  lets not blow away the text file
        }

        public void Log(string category)
        {
            Log(category, "");
        }

        public void Log(string category, string message)
        {
            if (file != null)
            {
                file.WriteLine(String.Format("{0} -- <<{1}>>{2}{3}", System.DateTime.Now, category, (String.IsNullOrEmpty(message) ? "" : " -- "), message));
                file.Flush();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (file != null)
                    {
                        file.Dispose();
                    }
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
