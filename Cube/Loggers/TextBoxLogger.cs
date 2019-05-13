using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CubeSolver.Loggers
{
    public class TextBoxLogger : ILogger
    {
        TextBox txtLog;

        public TextBoxLogger(TextBox txtLog)
        {
            this.txtLog = txtLog;
        }

        public void Clear()
        {
            txtLog.Clear();
        }

        public void Log(string category)
        {
            Log(category, "");
        }

        public void Log(string category, string message)
        {
            txtLog.AppendText(String.Format("{0} -- <<{1}>>{2}{3}{4}", System.DateTime.Now, category, (String.IsNullOrEmpty(message) ? "" : " -- "), message, Environment.NewLine));
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }
    }
}
