namespace CubeSolver
{
    partial class FrmCubeSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCubeSolver));
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblCubeSize = new System.Windows.Forms.Label();
            this.lblPieceSize = new System.Windows.Forms.Label();
            this.grpCreate = new System.Windows.Forms.GroupBox();
            this.btnDebug = new System.Windows.Forms.Button();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.lblDelay = new System.Windows.Forms.Label();
            this.btnSolve = new System.Windows.Forms.Button();
            this.numPieceSize = new System.Windows.Forms.NumericUpDown();
            this.btnScramble = new System.Windows.Forms.Button();
            this.numCubeSize = new System.Windows.Forms.NumericUpDown();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnQuickPicks = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.cmbPlane = new System.Windows.Forms.ComboBox();
            this.numZ = new System.Windows.Forms.NumericUpDown();
            this.lblPlane = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.grpColors = new System.Windows.Forms.GroupBox();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.lblHighlight = new System.Windows.Forms.Label();
            this.btnOutline = new System.Windows.Forms.Button();
            this.lblOutline = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblBack = new System.Windows.Forms.Label();
            this.btnFront = new System.Windows.Forms.Button();
            this.lblFront = new System.Windows.Forms.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.lblLeft = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.lblRight = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.lblDown = new System.Windows.Forms.Label();
            this.btnUpper = new System.Windows.Forms.Button();
            this.lblUpper = new System.Windows.Forms.Label();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpDrawType = new System.Windows.Forms.GroupBox();
            this.radDrawUnfold = new System.Windows.Forms.RadioButton();
            this.radDrawSplitStack = new System.Windows.Forms.RadioButton();
            this.radDrawGrid = new System.Windows.Forms.RadioButton();
            this.radDraw3D = new System.Windows.Forms.RadioButton();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblSelectedCoords = new System.Windows.Forms.Label();
            this.lblSelectedPiece = new System.Windows.Forms.Label();
            this.picSelected = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitter = new System.Windows.Forms.Splitter();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.grpCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPieceSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCubeSize)).BeginInit();
            this.grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).BeginInit();
            this.grpColors.SuspendLayout();
            this.grpDrawType.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelected)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.pnlLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(109, 73);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.Create_Click);
            // 
            // lblCubeSize
            // 
            this.lblCubeSize.AutoSize = true;
            this.lblCubeSize.Location = new System.Drawing.Point(85, 23);
            this.lblCubeSize.Name = "lblCubeSize";
            this.lblCubeSize.Size = new System.Drawing.Size(55, 13);
            this.lblCubeSize.TabIndex = 3;
            this.lblCubeSize.Text = "Cube Size";
            this.lblCubeSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPieceSize
            // 
            this.lblPieceSize.AutoSize = true;
            this.lblPieceSize.Location = new System.Drawing.Point(83, 49);
            this.lblPieceSize.Name = "lblPieceSize";
            this.lblPieceSize.Size = new System.Drawing.Size(57, 13);
            this.lblPieceSize.TabIndex = 5;
            this.lblPieceSize.Text = "Piece Size";
            this.lblPieceSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpCreate
            // 
            this.grpCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCreate.Controls.Add(this.btnDebug);
            this.grpCreate.Controls.Add(this.numDelay);
            this.grpCreate.Controls.Add(this.lblDelay);
            this.grpCreate.Controls.Add(this.btnSolve);
            this.grpCreate.Controls.Add(this.numPieceSize);
            this.grpCreate.Controls.Add(this.btnScramble);
            this.grpCreate.Controls.Add(this.numCubeSize);
            this.grpCreate.Controls.Add(this.lblCubeSize);
            this.grpCreate.Controls.Add(this.lblPieceSize);
            this.grpCreate.Controls.Add(this.btnCreate);
            this.grpCreate.Location = new System.Drawing.Point(19, 279);
            this.grpCreate.Name = "grpCreate";
            this.grpCreate.Size = new System.Drawing.Size(197, 155);
            this.grpCreate.TabIndex = 0;
            this.grpCreate.TabStop = false;
            this.grpCreate.Text = "Create";
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(26, 99);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 4;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // numDelay
            // 
            this.numDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDelay.Location = new System.Drawing.Point(111, 126);
            this.numDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(72, 20);
            this.numDelay.TabIndex = 6;
            // 
            // lblDelay
            // 
            this.lblDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(23, 128);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(86, 13);
            this.lblDelay.TabIndex = 7;
            this.lblDelay.Text = "Move Delay (ms)";
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(109, 99);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 5;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // numPieceSize
            // 
            this.numPieceSize.Location = new System.Drawing.Point(143, 47);
            this.numPieceSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPieceSize.Name = "numPieceSize";
            this.numPieceSize.Size = new System.Drawing.Size(40, 20);
            this.numPieceSize.TabIndex = 1;
            this.numPieceSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numPieceSize.ValueChanged += new System.EventHandler(this.numPieceSize_ValueChanged);
            // 
            // btnScramble
            // 
            this.btnScramble.Location = new System.Drawing.Point(26, 73);
            this.btnScramble.Name = "btnScramble";
            this.btnScramble.Size = new System.Drawing.Size(75, 23);
            this.btnScramble.TabIndex = 2;
            this.btnScramble.Text = "Scramble";
            this.btnScramble.UseVisualStyleBackColor = true;
            this.btnScramble.Click += new System.EventHandler(this.btnScramble_Click);
            // 
            // numCubeSize
            // 
            this.numCubeSize.Location = new System.Drawing.Point(143, 21);
            this.numCubeSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCubeSize.Name = "numCubeSize";
            this.numCubeSize.Size = new System.Drawing.Size(40, 20);
            this.numCubeSize.TabIndex = 0;
            this.numCubeSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // grpActions
            // 
            this.grpActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpActions.Controls.Add(this.btnQuickPicks);
            this.grpActions.Controls.Add(this.btnRotate);
            this.grpActions.Controls.Add(this.lblX);
            this.grpActions.Controls.Add(this.cmbDirection);
            this.grpActions.Controls.Add(this.lblZ);
            this.grpActions.Controls.Add(this.lblDirection);
            this.grpActions.Controls.Add(this.numY);
            this.grpActions.Controls.Add(this.numX);
            this.grpActions.Controls.Add(this.cmbPlane);
            this.grpActions.Controls.Add(this.numZ);
            this.grpActions.Controls.Add(this.lblPlane);
            this.grpActions.Controls.Add(this.lblY);
            this.grpActions.Location = new System.Drawing.Point(19, 436);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(197, 131);
            this.grpActions.TabIndex = 1;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Actions";
            // 
            // btnQuickPicks
            // 
            this.btnQuickPicks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickPicks.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuickPicks.Location = new System.Drawing.Point(26, 100);
            this.btnQuickPicks.Name = "btnQuickPicks";
            this.btnQuickPicks.Size = new System.Drawing.Size(75, 23);
            this.btnQuickPicks.TabIndex = 5;
            this.btnQuickPicks.Text = "Quick Picks";
            this.btnQuickPicks.UseVisualStyleBackColor = true;
            this.btnQuickPicks.Click += new System.EventHandler(this.btnQuickPicks_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(108, 100);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(75, 23);
            this.btnRotate.TabIndex = 5;
            this.btnRotate.Text = "Rotate";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(69, 23);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 13);
            this.lblX.TabIndex = 8;
            this.lblX.Text = "X";
            // 
            // cmbDirection
            // 
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Location = new System.Drawing.Point(61, 73);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(122, 21);
            this.cmbDirection.TabIndex = 4;
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(6, 23);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(14, 13);
            this.lblZ.TabIndex = 7;
            this.lblZ.Text = "Z";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(11, 76);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(49, 13);
            this.lblDirection.TabIndex = 12;
            this.lblDirection.Text = "Direction";
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(144, 21);
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(40, 20);
            this.numY.TabIndex = 2;
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(83, 21);
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(40, 20);
            this.numX.TabIndex = 1;
            // 
            // cmbPlane
            // 
            this.cmbPlane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlane.FormattingEnabled = true;
            this.cmbPlane.Location = new System.Drawing.Point(61, 50);
            this.cmbPlane.Name = "cmbPlane";
            this.cmbPlane.Size = new System.Drawing.Size(122, 21);
            this.cmbPlane.TabIndex = 3;
            // 
            // numZ
            // 
            this.numZ.Location = new System.Drawing.Point(20, 21);
            this.numZ.Name = "numZ";
            this.numZ.Size = new System.Drawing.Size(40, 20);
            this.numZ.TabIndex = 0;
            // 
            // lblPlane
            // 
            this.lblPlane.AutoSize = true;
            this.lblPlane.Location = new System.Drawing.Point(26, 53);
            this.lblPlane.Name = "lblPlane";
            this.lblPlane.Size = new System.Drawing.Size(34, 13);
            this.lblPlane.TabIndex = 10;
            this.lblPlane.Text = "Plane";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(131, 23);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 13);
            this.lblY.TabIndex = 10;
            this.lblY.Text = "Y";
            // 
            // grpColors
            // 
            this.grpColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpColors.Controls.Add(this.btnHighlight);
            this.grpColors.Controls.Add(this.lblHighlight);
            this.grpColors.Controls.Add(this.btnOutline);
            this.grpColors.Controls.Add(this.lblOutline);
            this.grpColors.Controls.Add(this.btnBack);
            this.grpColors.Controls.Add(this.lblBack);
            this.grpColors.Controls.Add(this.btnFront);
            this.grpColors.Controls.Add(this.lblFront);
            this.grpColors.Controls.Add(this.btnLeft);
            this.grpColors.Controls.Add(this.lblLeft);
            this.grpColors.Controls.Add(this.btnRight);
            this.grpColors.Controls.Add(this.lblRight);
            this.grpColors.Controls.Add(this.btnDown);
            this.grpColors.Controls.Add(this.lblDown);
            this.grpColors.Controls.Add(this.btnUpper);
            this.grpColors.Controls.Add(this.lblUpper);
            this.grpColors.Location = new System.Drawing.Point(19, 14);
            this.grpColors.Name = "grpColors";
            this.grpColors.Size = new System.Drawing.Size(197, 200);
            this.grpColors.TabIndex = 3;
            this.grpColors.TabStop = false;
            this.grpColors.Text = "Colors";
            // 
            // btnHighlight
            // 
            this.btnHighlight.BackColor = System.Drawing.Color.Black;
            this.btnHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighlight.Location = new System.Drawing.Point(57, 169);
            this.btnHighlight.Margin = new System.Windows.Forms.Padding(0);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(129, 23);
            this.btnHighlight.TabIndex = 7;
            this.btnHighlight.Tag = "Highlight";
            this.btnHighlight.UseVisualStyleBackColor = false;
            this.btnHighlight.Click += new System.EventHandler(this.SelectColor);
            // 
            // lblHighlight
            // 
            this.lblHighlight.AutoSize = true;
            this.lblHighlight.Location = new System.Drawing.Point(8, 174);
            this.lblHighlight.Name = "lblHighlight";
            this.lblHighlight.Size = new System.Drawing.Size(48, 13);
            this.lblHighlight.TabIndex = 29;
            this.lblHighlight.Text = "Highlight";
            // 
            // btnOutline
            // 
            this.btnOutline.BackColor = System.Drawing.Color.Silver;
            this.btnOutline.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutline.Location = new System.Drawing.Point(57, 147);
            this.btnOutline.Margin = new System.Windows.Forms.Padding(0);
            this.btnOutline.Name = "btnOutline";
            this.btnOutline.Size = new System.Drawing.Size(129, 23);
            this.btnOutline.TabIndex = 6;
            this.btnOutline.Tag = "Outline";
            this.btnOutline.UseVisualStyleBackColor = false;
            this.btnOutline.Click += new System.EventHandler(this.SelectColor);
            // 
            // lblOutline
            // 
            this.lblOutline.AutoSize = true;
            this.lblOutline.Location = new System.Drawing.Point(15, 152);
            this.lblOutline.Name = "lblOutline";
            this.lblOutline.Size = new System.Drawing.Size(40, 13);
            this.lblOutline.TabIndex = 27;
            this.lblOutline.Text = "Outline";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Green;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(57, 125);
            this.btnBack.Margin = new System.Windows.Forms.Padding(0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(129, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Tag = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.SelectColor);
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Location = new System.Drawing.Point(23, 130);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(32, 13);
            this.lblBack.TabIndex = 25;
            this.lblBack.Text = "Back";
            // 
            // btnFront
            // 
            this.btnFront.BackColor = System.Drawing.Color.Blue;
            this.btnFront.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFront.Location = new System.Drawing.Point(57, 103);
            this.btnFront.Margin = new System.Windows.Forms.Padding(0);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(129, 23);
            this.btnFront.TabIndex = 4;
            this.btnFront.Tag = "Front";
            this.btnFront.UseVisualStyleBackColor = false;
            this.btnFront.Click += new System.EventHandler(this.SelectColor);
            // 
            // lblFront
            // 
            this.lblFront.AutoSize = true;
            this.lblFront.Location = new System.Drawing.Point(24, 108);
            this.lblFront.Name = "lblFront";
            this.lblFront.Size = new System.Drawing.Size(31, 13);
            this.lblFront.TabIndex = 23;
            this.lblFront.Text = "Front";
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.Red;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Location = new System.Drawing.Point(57, 81);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(129, 23);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Tag = "Left";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.SelectColor);
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(30, 86);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(25, 13);
            this.lblLeft.TabIndex = 21;
            this.lblLeft.Text = "Left";
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.DarkOrange;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Location = new System.Drawing.Point(57, 59);
            this.btnRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(129, 23);
            this.btnRight.TabIndex = 2;
            this.btnRight.Tag = "Right";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.SelectColor);
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(23, 64);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(32, 13);
            this.lblRight.TabIndex = 19;
            this.lblRight.Text = "Right";
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Yellow;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(57, 37);
            this.btnDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(129, 23);
            this.btnDown.TabIndex = 1;
            this.btnDown.Tag = "Down";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.SelectColor);
            // 
            // lblDown
            // 
            this.lblDown.AutoSize = true;
            this.lblDown.Location = new System.Drawing.Point(20, 42);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(35, 13);
            this.lblDown.TabIndex = 17;
            this.lblDown.Text = "Down";
            // 
            // btnUpper
            // 
            this.btnUpper.BackColor = System.Drawing.Color.White;
            this.btnUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpper.Location = new System.Drawing.Point(57, 15);
            this.btnUpper.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpper.Name = "btnUpper";
            this.btnUpper.Size = new System.Drawing.Size(129, 23);
            this.btnUpper.TabIndex = 0;
            this.btnUpper.Tag = "Upper";
            this.btnUpper.UseVisualStyleBackColor = false;
            this.btnUpper.Click += new System.EventHandler(this.SelectColor);
            // 
            // lblUpper
            // 
            this.lblUpper.AutoSize = true;
            this.lblUpper.Location = new System.Drawing.Point(19, 20);
            this.lblUpper.Name = "lblUpper";
            this.lblUpper.Size = new System.Drawing.Size(36, 13);
            this.lblUpper.TabIndex = 15;
            this.lblUpper.Text = "Upper";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(128, 691);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpDrawType
            // 
            this.grpDrawType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDrawType.Controls.Add(this.radDrawUnfold);
            this.grpDrawType.Controls.Add(this.radDrawSplitStack);
            this.grpDrawType.Controls.Add(this.radDrawGrid);
            this.grpDrawType.Controls.Add(this.radDraw3D);
            this.grpDrawType.Location = new System.Drawing.Point(19, 218);
            this.grpDrawType.Name = "grpDrawType";
            this.grpDrawType.Size = new System.Drawing.Size(197, 59);
            this.grpDrawType.TabIndex = 4;
            this.grpDrawType.TabStop = false;
            this.grpDrawType.Text = "Draw Type";
            // 
            // radDrawUnfold
            // 
            this.radDrawUnfold.AutoSize = true;
            this.radDrawUnfold.Location = new System.Drawing.Point(17, 35);
            this.radDrawUnfold.Name = "radDrawUnfold";
            this.radDrawUnfold.Size = new System.Drawing.Size(56, 17);
            this.radDrawUnfold.TabIndex = 3;
            this.radDrawUnfold.Text = "Unfold";
            this.radDrawUnfold.UseVisualStyleBackColor = true;
            this.radDrawUnfold.CheckedChanged += new System.EventHandler(this.DrawStyle_CheckChanged);
            // 
            // radDrawSplitStack
            // 
            this.radDrawSplitStack.AutoSize = true;
            this.radDrawSplitStack.Location = new System.Drawing.Point(107, 15);
            this.radDrawSplitStack.Name = "radDrawSplitStack";
            this.radDrawSplitStack.Size = new System.Drawing.Size(76, 17);
            this.radDrawSplitStack.TabIndex = 2;
            this.radDrawSplitStack.Text = "Split Stack";
            this.radDrawSplitStack.UseVisualStyleBackColor = true;
            this.radDrawSplitStack.CheckedChanged += new System.EventHandler(this.DrawStyle_CheckChanged);
            // 
            // radDrawGrid
            // 
            this.radDrawGrid.AutoSize = true;
            this.radDrawGrid.Location = new System.Drawing.Point(107, 35);
            this.radDrawGrid.Name = "radDrawGrid";
            this.radDrawGrid.Size = new System.Drawing.Size(44, 17);
            this.radDrawGrid.TabIndex = 1;
            this.radDrawGrid.Text = "Grid";
            this.radDrawGrid.UseVisualStyleBackColor = true;
            this.radDrawGrid.Visible = false;
            this.radDrawGrid.CheckedChanged += new System.EventHandler(this.DrawStyle_CheckChanged);
            // 
            // radDraw3D
            // 
            this.radDraw3D.AutoSize = true;
            this.radDraw3D.Checked = true;
            this.radDraw3D.Location = new System.Drawing.Point(17, 15);
            this.radDraw3D.Name = "radDraw3D";
            this.radDraw3D.Size = new System.Drawing.Size(39, 17);
            this.radDraw3D.TabIndex = 0;
            this.radDraw3D.TabStop = true;
            this.radDraw3D.Text = "3D";
            this.radDraw3D.UseVisualStyleBackColor = true;
            this.radDraw3D.CheckedChanged += new System.EventHandler(this.DrawStyle_CheckChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.AutoScroll = true;
            this.pnlRight.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlRight.Controls.Add(this.lblSelectedCoords);
            this.pnlRight.Controls.Add(this.lblSelectedPiece);
            this.pnlRight.Controls.Add(this.picSelected);
            this.pnlRight.Controls.Add(this.grpDrawType);
            this.pnlRight.Controls.Add(this.grpCreate);
            this.pnlRight.Controls.Add(this.btnClose);
            this.pnlRight.Controls.Add(this.grpActions);
            this.pnlRight.Controls.Add(this.grpColors);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(810, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(233, 724);
            this.pnlRight.TabIndex = 0;
            // 
            // lblSelectedCoords
            // 
            this.lblSelectedCoords.AutoSize = true;
            this.lblSelectedCoords.Location = new System.Drawing.Point(151, 574);
            this.lblSelectedCoords.Name = "lblSelectedCoords";
            this.lblSelectedCoords.Size = new System.Drawing.Size(37, 13);
            this.lblSelectedCoords.TabIndex = 14;
            this.lblSelectedCoords.Text = "[z][x,y]";
            // 
            // lblSelectedPiece
            // 
            this.lblSelectedPiece.AutoSize = true;
            this.lblSelectedPiece.Location = new System.Drawing.Point(69, 574);
            this.lblSelectedPiece.Name = "lblSelectedPiece";
            this.lblSelectedPiece.Size = new System.Drawing.Size(82, 13);
            this.lblSelectedPiece.TabIndex = 13;
            this.lblSelectedPiece.Text = "Selected Piece:";
            // 
            // picSelected
            // 
            this.picSelected.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.picSelected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSelected.Location = new System.Drawing.Point(72, 591);
            this.picSelected.Name = "picSelected";
            this.picSelected.Size = new System.Drawing.Size(128, 91);
            this.picSelected.TabIndex = 5;
            this.picSelected.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitter);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.pnlLog);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(810, 724);
            this.pnlMain.TabIndex = 11;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.Location = new System.Drawing.Point(0, 586);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(810, 3);
            this.splitter.TabIndex = 11;
            this.splitter.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.AutoSize = true;
            this.pnlLeft.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLeft.Controls.Add(this.picCanvas);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(810, 589);
            this.pnlLeft.TabIndex = 7;
            this.pnlLeft.Click += new System.EventHandler(this.pnlLeft_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(10, 10);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(200, 182);
            this.picCanvas.TabIndex = 6;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.txtLog);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLog.Location = new System.Drawing.Point(0, 589);
            this.pnlLog.MinimumSize = new System.Drawing.Size(0, 100);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(810, 135);
            this.pnlLog.TabIndex = 8;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(810, 135);
            this.txtLog.TabIndex = 1;
            this.txtLog.WordWrap = false;
            // 
            // FrmCubeSolver
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1043, 724);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FrmCubeSolver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cube Solver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCubeSolver_FormClosing);
            this.Load += new System.EventHandler(this.FrmCubeSolver_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCubeSolver_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCubeSolver_KeyUp);
            this.grpCreate.ResumeLayout(false);
            this.grpCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPieceSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCubeSize)).EndInit();
            this.grpActions.ResumeLayout(false);
            this.grpActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).EndInit();
            this.grpColors.ResumeLayout(false);
            this.grpColors.PerformLayout();
            this.grpDrawType.ResumeLayout(false);
            this.grpDrawType.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelected)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblCubeSize;
        private System.Windows.Forms.Label lblPieceSize;
        private System.Windows.Forms.GroupBox grpCreate;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.ComboBox cmbPlane;
        private System.Windows.Forms.Label lblPlane;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Button btnScramble;
        private System.Windows.Forms.GroupBox grpColors;
        private System.Windows.Forms.Label lblUpper;
        private System.Windows.Forms.Button btnUpper;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Label lblFront;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.NumericUpDown numZ;
        private System.Windows.Forms.NumericUpDown numCubeSize;
        private System.Windows.Forms.NumericUpDown numPieceSize;
        private System.Windows.Forms.GroupBox grpDrawType;
        private System.Windows.Forms.RadioButton radDrawUnfold;
        private System.Windows.Forms.RadioButton radDrawSplitStack;
        private System.Windows.Forms.RadioButton radDrawGrid;
        private System.Windows.Forms.RadioButton radDraw3D;
        private System.Windows.Forms.Button btnOutline;
        private System.Windows.Forms.Label lblOutline;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnQuickPicks;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblSelectedCoords;
        private System.Windows.Forms.Label lblSelectedPiece;
        private System.Windows.Forms.PictureBox picSelected;
        private System.Windows.Forms.Button btnHighlight;
        private System.Windows.Forms.Label lblHighlight;
    }
}

