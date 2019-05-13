namespace CubeSolver
{
    partial class FrmQuickPicks
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
            this.btnFullCube = new System.Windows.Forms.Button();
            this.btnDirectionToggle = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlFun = new System.Windows.Forms.Panel();
            this.btnFunCheckered = new System.Windows.Forms.Button();
            this.btnFun = new System.Windows.Forms.Button();
            this.pnlSpecial = new System.Windows.Forms.Panel();
            this.btnRightCornersSwap = new System.Windows.Forms.Button();
            this.btnSpecial = new System.Windows.Forms.Button();
            this.pnlStandard = new System.Windows.Forms.Panel();
            this.btnSLowerLeftEdgeSwap = new System.Windows.Forms.Button();
            this.btnStandardUpperThreeShift = new System.Windows.Forms.Button();
            this.btnSDotToLToLineToCross = new System.Windows.Forms.Button();
            this.btnSGoHomeRight = new System.Windows.Forms.Button();
            this.btnSGoHomeLeft = new System.Windows.Forms.Button();
            this.btnCrossCornerDropRight = new System.Windows.Forms.Button();
            this.btnCrossCornerDropLeft = new System.Windows.Forms.Button();
            this.btnStandardDownOverUpOver = new System.Windows.Forms.Button();
            this.btnStandard = new System.Windows.Forms.Button();
            this.pnlFullLayers = new System.Windows.Forms.Panel();
            this.btnLayerVerticalWidth90 = new System.Windows.Forms.Button();
            this.btnLayerVerticalDepth90 = new System.Windows.Forms.Button();
            this.btnLayerHorizontal90 = new System.Windows.Forms.Button();
            this.btnFullLayers = new System.Windows.Forms.Button();
            this.pnlFullCube = new System.Windows.Forms.Panel();
            this.btnCVW90 = new System.Windows.Forms.Button();
            this.btnCVD90 = new System.Windows.Forms.Button();
            this.btnCH90 = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlFun.SuspendLayout();
            this.pnlSpecial.SuspendLayout();
            this.pnlStandard.SuspendLayout();
            this.pnlFullLayers.SuspendLayout();
            this.pnlFullCube.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFullCube
            // 
            this.btnFullCube.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnFullCube.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFullCube.Location = new System.Drawing.Point(0, 0);
            this.btnFullCube.Name = "btnFullCube";
            this.btnFullCube.Size = new System.Drawing.Size(239, 23);
            this.btnFullCube.TabIndex = 1;
            this.btnFullCube.Text = "Full Cube Rotations";
            this.btnFullCube.UseVisualStyleBackColor = false;
            this.btnFullCube.Click += new System.EventHandler(this.HeaderClick);
            // 
            // btnDirectionToggle
            // 
            this.btnDirectionToggle.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDirectionToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDirectionToggle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDirectionToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectionToggle.ForeColor = System.Drawing.SystemColors.Info;
            this.btnDirectionToggle.Location = new System.Drawing.Point(0, 0);
            this.btnDirectionToggle.Name = "btnDirectionToggle";
            this.btnDirectionToggle.Size = new System.Drawing.Size(239, 28);
            this.btnDirectionToggle.TabIndex = 0;
            this.btnDirectionToggle.Text = "Clockwise";
            this.btnDirectionToggle.UseVisualStyleBackColor = false;
            this.btnDirectionToggle.Click += new System.EventHandler(this.btnDirectionToggle_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlFun);
            this.pnlMain.Controls.Add(this.btnFun);
            this.pnlMain.Controls.Add(this.pnlSpecial);
            this.pnlMain.Controls.Add(this.btnSpecial);
            this.pnlMain.Controls.Add(this.pnlStandard);
            this.pnlMain.Controls.Add(this.btnStandard);
            this.pnlMain.Controls.Add(this.pnlFullLayers);
            this.pnlMain.Controls.Add(this.btnFullLayers);
            this.pnlMain.Controls.Add(this.pnlFullCube);
            this.pnlMain.Controls.Add(this.btnFullCube);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 28);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(239, 487);
            this.pnlMain.TabIndex = 22;
            // 
            // pnlFun
            // 
            this.pnlFun.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFun.Controls.Add(this.btnFunCheckered);
            this.pnlFun.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFun.Location = new System.Drawing.Point(0, 462);
            this.pnlFun.Name = "pnlFun";
            this.pnlFun.Size = new System.Drawing.Size(239, 26);
            this.pnlFun.TabIndex = 11;
            // 
            // btnFunCheckered
            // 
            this.btnFunCheckered.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFunCheckered.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFunCheckered.ForeColor = System.Drawing.SystemColors.Info;
            this.btnFunCheckered.Location = new System.Drawing.Point(0, -1);
            this.btnFunCheckered.Name = "btnFunCheckered";
            this.btnFunCheckered.Size = new System.Drawing.Size(235, 23);
            this.btnFunCheckered.TabIndex = 0;
            this.btnFunCheckered.Text = "Checkerboard";
            this.btnFunCheckered.UseVisualStyleBackColor = true;
            this.btnFunCheckered.Click += new System.EventHandler(this.btnFunCheckered_Click);
            // 
            // btnFun
            // 
            this.btnFun.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnFun.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFun.Location = new System.Drawing.Point(0, 439);
            this.btnFun.Name = "btnFun";
            this.btnFun.Size = new System.Drawing.Size(239, 23);
            this.btnFun.TabIndex = 10;
            this.btnFun.Text = "Fun Algorithms";
            this.btnFun.UseVisualStyleBackColor = false;
            this.btnFun.Click += new System.EventHandler(this.HeaderClick);
            // 
            // pnlSpecial
            // 
            this.pnlSpecial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSpecial.Controls.Add(this.btnRightCornersSwap);
            this.pnlSpecial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpecial.Location = new System.Drawing.Point(0, 412);
            this.pnlSpecial.Name = "pnlSpecial";
            this.pnlSpecial.Size = new System.Drawing.Size(239, 27);
            this.pnlSpecial.TabIndex = 7;
            // 
            // btnRightCornersSwap
            // 
            this.btnRightCornersSwap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRightCornersSwap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRightCornersSwap.ForeColor = System.Drawing.SystemColors.Info;
            this.btnRightCornersSwap.Location = new System.Drawing.Point(0, 0);
            this.btnRightCornersSwap.Name = "btnRightCornersSwap";
            this.btnRightCornersSwap.Size = new System.Drawing.Size(235, 23);
            this.btnRightCornersSwap.TabIndex = 0;
            this.btnRightCornersSwap.Text = "Right Side Corners Swap (2x2x2)";
            this.btnRightCornersSwap.UseVisualStyleBackColor = true;
            this.btnRightCornersSwap.Click += new System.EventHandler(this.btnRightCornersSwap_Click);
            // 
            // btnSpecial
            // 
            this.btnSpecial.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSpecial.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSpecial.Location = new System.Drawing.Point(0, 389);
            this.btnSpecial.Name = "btnSpecial";
            this.btnSpecial.Size = new System.Drawing.Size(239, 23);
            this.btnSpecial.TabIndex = 6;
            this.btnSpecial.Text = "Special Case Algorithms";
            this.btnSpecial.UseVisualStyleBackColor = false;
            this.btnSpecial.Click += new System.EventHandler(this.HeaderClick);
            // 
            // pnlStandard
            // 
            this.pnlStandard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlStandard.Controls.Add(this.btnSLowerLeftEdgeSwap);
            this.pnlStandard.Controls.Add(this.btnStandardUpperThreeShift);
            this.pnlStandard.Controls.Add(this.btnSDotToLToLineToCross);
            this.pnlStandard.Controls.Add(this.btnSGoHomeRight);
            this.pnlStandard.Controls.Add(this.btnSGoHomeLeft);
            this.pnlStandard.Controls.Add(this.btnCrossCornerDropRight);
            this.pnlStandard.Controls.Add(this.btnCrossCornerDropLeft);
            this.pnlStandard.Controls.Add(this.btnStandardDownOverUpOver);
            this.pnlStandard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStandard.Location = new System.Drawing.Point(0, 209);
            this.pnlStandard.Name = "pnlStandard";
            this.pnlStandard.Size = new System.Drawing.Size(239, 180);
            this.pnlStandard.TabIndex = 5;
            // 
            // btnSLowerLeftEdgeSwap
            // 
            this.btnSLowerLeftEdgeSwap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSLowerLeftEdgeSwap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSLowerLeftEdgeSwap.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSLowerLeftEdgeSwap.Location = new System.Drawing.Point(0, 109);
            this.btnSLowerLeftEdgeSwap.Name = "btnSLowerLeftEdgeSwap";
            this.btnSLowerLeftEdgeSwap.Size = new System.Drawing.Size(235, 23);
            this.btnSLowerLeftEdgeSwap.TabIndex = 5;
            this.btnSLowerLeftEdgeSwap.Text = "Left-Edge / Front-Edge Swap";
            this.btnSLowerLeftEdgeSwap.UseVisualStyleBackColor = true;
            this.btnSLowerLeftEdgeSwap.Click += new System.EventHandler(this.btnSLowerLeftEdgeSwap_Click);
            // 
            // btnStandardUpperThreeShift
            // 
            this.btnStandardUpperThreeShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStandardUpperThreeShift.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStandardUpperThreeShift.ForeColor = System.Drawing.SystemColors.Info;
            this.btnStandardUpperThreeShift.Location = new System.Drawing.Point(0, 131);
            this.btnStandardUpperThreeShift.Name = "btnStandardUpperThreeShift";
            this.btnStandardUpperThreeShift.Size = new System.Drawing.Size(235, 23);
            this.btnStandardUpperThreeShift.TabIndex = 6;
            this.btnStandardUpperThreeShift.Text = "Upper Three-Corner Shift";
            this.btnStandardUpperThreeShift.UseVisualStyleBackColor = true;
            this.btnStandardUpperThreeShift.Click += new System.EventHandler(this.UpperThreeCornerShift_Click);
            // 
            // btnSDotToLToLineToCross
            // 
            this.btnSDotToLToLineToCross.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSDotToLToLineToCross.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSDotToLToLineToCross.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSDotToLToLineToCross.Location = new System.Drawing.Point(0, 87);
            this.btnSDotToLToLineToCross.Name = "btnSDotToLToLineToCross";
            this.btnSDotToLToLineToCross.Size = new System.Drawing.Size(235, 23);
            this.btnSDotToLToLineToCross.TabIndex = 4;
            this.btnSDotToLToLineToCross.Text = "Dot to \'L\' to Line to Cross";
            this.btnSDotToLToLineToCross.UseVisualStyleBackColor = true;
            this.btnSDotToLToLineToCross.Click += new System.EventHandler(this.btnSDotToLToLineToCross_Click);
            // 
            // btnSGoHomeRight
            // 
            this.btnSGoHomeRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSGoHomeRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSGoHomeRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSGoHomeRight.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSGoHomeRight.Location = new System.Drawing.Point(0, 65);
            this.btnSGoHomeRight.Name = "btnSGoHomeRight";
            this.btnSGoHomeRight.Size = new System.Drawing.Size(235, 23);
            this.btnSGoHomeRight.TabIndex = 3;
            this.btnSGoHomeRight.Text = "Middle Edge Mover (Right to Front)";
            this.btnSGoHomeRight.UseVisualStyleBackColor = true;
            this.btnSGoHomeRight.Click += new System.EventHandler(this.btnSGoHomeRight_Click);
            // 
            // btnSGoHomeLeft
            // 
            this.btnSGoHomeLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSGoHomeLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSGoHomeLeft.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSGoHomeLeft.Location = new System.Drawing.Point(0, 43);
            this.btnSGoHomeLeft.Name = "btnSGoHomeLeft";
            this.btnSGoHomeLeft.Size = new System.Drawing.Size(235, 23);
            this.btnSGoHomeLeft.TabIndex = 2;
            this.btnSGoHomeLeft.Text = "Middle Edge Mover (Front to Right)";
            this.btnSGoHomeLeft.UseVisualStyleBackColor = true;
            this.btnSGoHomeLeft.Click += new System.EventHandler(this.btnSGoHomeLeft_Click);
            // 
            // btnCrossCornerDropRight
            // 
            this.btnCrossCornerDropRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrossCornerDropRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrossCornerDropRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrossCornerDropRight.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCrossCornerDropRight.Location = new System.Drawing.Point(0, 21);
            this.btnCrossCornerDropRight.Name = "btnCrossCornerDropRight";
            this.btnCrossCornerDropRight.Size = new System.Drawing.Size(235, 23);
            this.btnCrossCornerDropRight.TabIndex = 1;
            this.btnCrossCornerDropRight.Text = "Corner Drop into Cross (Facing Right)";
            this.btnCrossCornerDropRight.UseVisualStyleBackColor = true;
            this.btnCrossCornerDropRight.Click += new System.EventHandler(this.btnCrossCornerDropRight_Click);
            // 
            // btnCrossCornerDropLeft
            // 
            this.btnCrossCornerDropLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrossCornerDropLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrossCornerDropLeft.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCrossCornerDropLeft.Location = new System.Drawing.Point(0, -1);
            this.btnCrossCornerDropLeft.Name = "btnCrossCornerDropLeft";
            this.btnCrossCornerDropLeft.Size = new System.Drawing.Size(235, 23);
            this.btnCrossCornerDropLeft.TabIndex = 0;
            this.btnCrossCornerDropLeft.Text = "Corner Drop into Cross (Facing Front)";
            this.btnCrossCornerDropLeft.UseVisualStyleBackColor = true;
            this.btnCrossCornerDropLeft.Click += new System.EventHandler(this.btnCrossCornerDropLeft_Click);
            // 
            // btnStandardDownOverUpOver
            // 
            this.btnStandardDownOverUpOver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStandardDownOverUpOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStandardDownOverUpOver.ForeColor = System.Drawing.SystemColors.Info;
            this.btnStandardDownOverUpOver.Location = new System.Drawing.Point(0, 153);
            this.btnStandardDownOverUpOver.Name = "btnStandardDownOverUpOver";
            this.btnStandardDownOverUpOver.Size = new System.Drawing.Size(235, 23);
            this.btnStandardDownOverUpOver.TabIndex = 8;
            this.btnStandardDownOverUpOver.Text = "Upper/Right/Front Corner Rotater";
            this.btnStandardDownOverUpOver.UseVisualStyleBackColor = true;
            this.btnStandardDownOverUpOver.Click += new System.EventHandler(this.btnSDownOverUpOver_Click);
            // 
            // btnStandard
            // 
            this.btnStandard.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnStandard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStandard.Location = new System.Drawing.Point(0, 186);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Size = new System.Drawing.Size(239, 23);
            this.btnStandard.TabIndex = 4;
            this.btnStandard.Text = "Standard Algorithms";
            this.btnStandard.UseVisualStyleBackColor = false;
            this.btnStandard.Click += new System.EventHandler(this.HeaderClick);
            // 
            // pnlFullLayers
            // 
            this.pnlFullLayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFullLayers.Controls.Add(this.btnLayerVerticalWidth90);
            this.pnlFullLayers.Controls.Add(this.btnLayerVerticalDepth90);
            this.pnlFullLayers.Controls.Add(this.btnLayerHorizontal90);
            this.pnlFullLayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFullLayers.Location = new System.Drawing.Point(0, 116);
            this.pnlFullLayers.Name = "pnlFullLayers";
            this.pnlFullLayers.Size = new System.Drawing.Size(239, 70);
            this.pnlFullLayers.TabIndex = 3;
            // 
            // btnLayerVerticalWidth90
            // 
            this.btnLayerVerticalWidth90.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLayerVerticalWidth90.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLayerVerticalWidth90.ForeColor = System.Drawing.SystemColors.Info;
            this.btnLayerVerticalWidth90.Location = new System.Drawing.Point(0, 43);
            this.btnLayerVerticalWidth90.Name = "btnLayerVerticalWidth90";
            this.btnLayerVerticalWidth90.Size = new System.Drawing.Size(235, 23);
            this.btnLayerVerticalWidth90.TabIndex = 4;
            this.btnLayerVerticalWidth90.Text = "Vertical (Width) (90)";
            this.btnLayerVerticalWidth90.UseVisualStyleBackColor = true;
            this.btnLayerVerticalWidth90.Click += new System.EventHandler(this.btnSingleLayerVerticalWidth90_Click);
            // 
            // btnLayerVerticalDepth90
            // 
            this.btnLayerVerticalDepth90.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLayerVerticalDepth90.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLayerVerticalDepth90.ForeColor = System.Drawing.SystemColors.Info;
            this.btnLayerVerticalDepth90.Location = new System.Drawing.Point(0, 21);
            this.btnLayerVerticalDepth90.Name = "btnLayerVerticalDepth90";
            this.btnLayerVerticalDepth90.Size = new System.Drawing.Size(235, 23);
            this.btnLayerVerticalDepth90.TabIndex = 2;
            this.btnLayerVerticalDepth90.Text = "Vertical (Depth) (90)";
            this.btnLayerVerticalDepth90.UseVisualStyleBackColor = true;
            this.btnLayerVerticalDepth90.Click += new System.EventHandler(this.btnSingleLayerVerticalDepth90_Click);
            // 
            // btnLayerHorizontal90
            // 
            this.btnLayerHorizontal90.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLayerHorizontal90.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLayerHorizontal90.ForeColor = System.Drawing.SystemColors.Info;
            this.btnLayerHorizontal90.Location = new System.Drawing.Point(0, -1);
            this.btnLayerHorizontal90.Name = "btnLayerHorizontal90";
            this.btnLayerHorizontal90.Size = new System.Drawing.Size(235, 23);
            this.btnLayerHorizontal90.TabIndex = 0;
            this.btnLayerHorizontal90.Text = "Horizontal (90)";
            this.btnLayerHorizontal90.UseVisualStyleBackColor = true;
            this.btnLayerHorizontal90.Click += new System.EventHandler(this.btnSingleLayerHorizontal90_Click);
            // 
            // btnFullLayers
            // 
            this.btnFullLayers.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnFullLayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFullLayers.Location = new System.Drawing.Point(0, 93);
            this.btnFullLayers.Name = "btnFullLayers";
            this.btnFullLayers.Size = new System.Drawing.Size(239, 23);
            this.btnFullLayers.TabIndex = 2;
            this.btnFullLayers.Text = "Full Layer Rotations";
            this.btnFullLayers.UseVisualStyleBackColor = false;
            this.btnFullLayers.Click += new System.EventHandler(this.HeaderClick);
            // 
            // pnlFullCube
            // 
            this.pnlFullCube.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFullCube.Controls.Add(this.btnCVW90);
            this.pnlFullCube.Controls.Add(this.btnCVD90);
            this.pnlFullCube.Controls.Add(this.btnCH90);
            this.pnlFullCube.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFullCube.Location = new System.Drawing.Point(0, 23);
            this.pnlFullCube.Name = "pnlFullCube";
            this.pnlFullCube.Size = new System.Drawing.Size(239, 70);
            this.pnlFullCube.TabIndex = 1;
            // 
            // btnCVW90
            // 
            this.btnCVW90.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCVW90.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCVW90.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCVW90.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCVW90.Location = new System.Drawing.Point(0, 43);
            this.btnCVW90.Name = "btnCVW90";
            this.btnCVW90.Size = new System.Drawing.Size(235, 23);
            this.btnCVW90.TabIndex = 2;
            this.btnCVW90.Text = "Vertical (Width) (90)";
            this.btnCVW90.UseVisualStyleBackColor = true;
            this.btnCVW90.Click += new System.EventHandler(this.btnCVW90_Click);
            // 
            // btnCVD90
            // 
            this.btnCVD90.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCVD90.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCVD90.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCVD90.Location = new System.Drawing.Point(0, 21);
            this.btnCVD90.Name = "btnCVD90";
            this.btnCVD90.Size = new System.Drawing.Size(235, 23);
            this.btnCVD90.TabIndex = 1;
            this.btnCVD90.Text = "Vertical (Depth) (90)";
            this.btnCVD90.UseVisualStyleBackColor = true;
            this.btnCVD90.Click += new System.EventHandler(this.btnCVD90_Click);
            // 
            // btnCH90
            // 
            this.btnCH90.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCH90.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCH90.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCH90.Location = new System.Drawing.Point(0, -1);
            this.btnCH90.Name = "btnCH90";
            this.btnCH90.Size = new System.Drawing.Size(235, 23);
            this.btnCH90.TabIndex = 0;
            this.btnCH90.Text = "Horizontal (90)";
            this.btnCH90.UseVisualStyleBackColor = true;
            this.btnCH90.Click += new System.EventHandler(this.btnCH90_Click);
            // 
            // FrmQuickPicks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(239, 515);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnDirectionToggle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuickPicks";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Quick Picks";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQuickPicks_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmQuickPicks_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmQuickPicks_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmQuickPicks_KeyUp);
            this.pnlMain.ResumeLayout(false);
            this.pnlFun.ResumeLayout(false);
            this.pnlSpecial.ResumeLayout(false);
            this.pnlStandard.ResumeLayout(false);
            this.pnlFullLayers.ResumeLayout(false);
            this.pnlFullCube.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFullCube;
        private System.Windows.Forms.Button btnDirectionToggle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlFullLayers;
        private System.Windows.Forms.Button btnLayerHorizontal90;
        private System.Windows.Forms.Button btnFullLayers;
        private System.Windows.Forms.Panel pnlFullCube;
        private System.Windows.Forms.Button btnCVW90;
        private System.Windows.Forms.Button btnCVD90;
        private System.Windows.Forms.Button btnCH90;
        private System.Windows.Forms.Button btnLayerVerticalWidth90;
        private System.Windows.Forms.Button btnLayerVerticalDepth90;
        private System.Windows.Forms.Panel pnlStandard;
        private System.Windows.Forms.Button btnCrossCornerDropRight;
        private System.Windows.Forms.Button btnCrossCornerDropLeft;
        private System.Windows.Forms.Button btnStandardDownOverUpOver;
        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.Button btnSLowerLeftEdgeSwap;
        private System.Windows.Forms.Button btnStandardUpperThreeShift;
        private System.Windows.Forms.Button btnSDotToLToLineToCross;
        private System.Windows.Forms.Button btnSGoHomeRight;
        private System.Windows.Forms.Button btnSGoHomeLeft;
        private System.Windows.Forms.Panel pnlFun;
        private System.Windows.Forms.Button btnFunCheckered;
        private System.Windows.Forms.Button btnFun;
        private System.Windows.Forms.Panel pnlSpecial;
        private System.Windows.Forms.Button btnRightCornersSwap;
        private System.Windows.Forms.Button btnSpecial;
    }
}