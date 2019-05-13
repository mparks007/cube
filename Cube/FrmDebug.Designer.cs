namespace CubeSolver
{
    partial class frmDebug
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeDebug = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeDebug
            // 
            this.treeDebug.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.treeDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDebug.Location = new System.Drawing.Point(0, 0);
            this.treeDebug.Name = "treeDebug";
            this.treeDebug.Size = new System.Drawing.Size(212, 276);
            this.treeDebug.TabIndex = 0;
            // 
            // frmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 276);
            this.Controls.Add(this.treeDebug);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(150, 130);
            this.Name = "frmDebug";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Debug";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDebug_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmDebug_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeDebug;
    }
}