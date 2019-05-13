using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CubeSolver
{
    public partial class frmDebug : Form
    {
        public Cube Cube { get; set; }

        private bool allowClose;

        public frmDebug()
        {
            InitializeComponent();
        }

        private void frmDebug_KeyPress(object sender, KeyPressEventArgs e)
        {
            // always nice to have ESC key close an active window
            if (e.KeyChar == (char)Keys.Escape)
                Hide();
        }

        public void RefreshTree()
        {
            Cube.CreateTree(treeDebug);
        }

        private void frmDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            e.Cancel = !allowClose;
        }
    }
}
