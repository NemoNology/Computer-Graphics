namespace WF
{
    partial class MainForm
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
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel4 = new ToolStripStatusLabel();
            _outputMouseCoordinates = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            _outputCentralPointCoordinates = new ToolStripStatusLabel();
            toolStripStatusLabel7 = new ToolStripStatusLabel();
            b_chooseCP = new ToolStripStatusLabel();
            toolStripStatusLabel8 = new ToolStripStatusLabel();
            b_chooseColor = new ToolStripStatusLabel();
            toolStripStatusLabel9 = new ToolStripStatusLabel();
            _outputPictureSize = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            menu_image = new ToolStripMenuItem();
            image_clear = new ToolStripMenuItem();
            image_resize = new ToolStripMenuItem();
            image_rotate = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            image = new ToolStripMenuItem();
            image_load = new ToolStripMenuItem();
            _mainView = new PictureBox();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_mainView).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.Control;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel4, _outputMouseCoordinates, toolStripStatusLabel3, _outputCentralPointCoordinates, toolStripStatusLabel7, b_chooseCP, toolStripStatusLabel8, b_chooseColor, toolStripStatusLabel9, _outputPictureSize });
            statusStrip1.Location = new Point(0, 426);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RightToLeft = RightToLeft.No;
            statusStrip1.Size = new Size(800, 24);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "StatusStribBar";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel4.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new Size(151, 19);
            toolStripStatusLabel4.Text = "Mouse coordinates (X, Y):";
            // 
            // _outputMouseCoordinates
            // 
            _outputMouseCoordinates.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _outputMouseCoordinates.BorderStyle = Border3DStyle.Bump;
            _outputMouseCoordinates.Name = "_outputMouseCoordinates";
            _outputMouseCoordinates.Size = new Size(20, 19);
            _outputMouseCoordinates.Text = "...";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel3.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(187, 19);
            toolStripStatusLabel3.Text = "Central Point Coordinates (X, Y):";
            toolStripStatusLabel3.MouseEnter += ShowCentralPoint;
            toolStripStatusLabel3.MouseLeave += HideCentralPoint;
            // 
            // _outputCentralPointCoordinates
            // 
            _outputCentralPointCoordinates.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            _outputCentralPointCoordinates.BorderStyle = Border3DStyle.Bump;
            _outputCentralPointCoordinates.Name = "_outputCentralPointCoordinates";
            _outputCentralPointCoordinates.Size = new Size(20, 19);
            _outputCentralPointCoordinates.Text = "...";
            // 
            // toolStripStatusLabel7
            // 
            toolStripStatusLabel7.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel7.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            toolStripStatusLabel7.Size = new Size(14, 19);
            toolStripStatusLabel7.Text = "I";
            // 
            // b_chooseCP
            // 
            b_chooseCP.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            b_chooseCP.BorderStyle = Border3DStyle.Bump;
            b_chooseCP.Name = "b_chooseCP";
            b_chooseCP.Size = new Size(51, 19);
            b_chooseCP.Text = "Choose";
            b_chooseCP.MouseDown += b_chooseCP_MouseDown;
            b_chooseCP.MouseEnter += b_chooseCP_MouseEnter;
            b_chooseCP.MouseLeave += b_chooseCP_MouseLeave;
            // 
            // toolStripStatusLabel8
            // 
            toolStripStatusLabel8.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel8.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            toolStripStatusLabel8.Size = new Size(43, 19);
            toolStripStatusLabel8.Text = "Color:";
            // 
            // b_chooseColor
            // 
            b_chooseColor.BackColor = Color.Black;
            b_chooseColor.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            b_chooseColor.BorderStyle = Border3DStyle.Bump;
            b_chooseColor.ForeColor = Color.White;
            b_chooseColor.Name = "b_chooseColor";
            b_chooseColor.Size = new Size(39, 19);
            b_chooseColor.Text = "Black";
            b_chooseColor.Click += b_color_Click;
            b_chooseColor.MouseEnter += b_chooseCP_MouseEnter;
            b_chooseColor.MouseLeave += b_chooseCP_MouseLeave;
            // 
            // toolStripStatusLabel9
            // 
            toolStripStatusLabel9.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel9.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            toolStripStatusLabel9.Size = new Size(80, 19);
            toolStripStatusLabel9.Text = "Picture Size:";
            // 
            // _outputPictureSize
            // 
            _outputPictureSize.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _outputPictureSize.BorderStyle = Border3DStyle.Bump;
            _outputPictureSize.Name = "_outputPictureSize";
            _outputPictureSize.Size = new Size(20, 19);
            _outputPictureSize.Text = "...";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Items.AddRange(new ToolStripItem[] { menu_image });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // menu_image
            // 
            menu_image.DropDownItems.AddRange(new ToolStripItem[] { image_clear, image_resize, image_rotate, toolStripSeparator1, image, image_load });
            menu_image.Name = "menu_image";
            menu_image.Size = new Size(52, 20);
            menu_image.Text = "Image";
            // 
            // image_clear
            // 
            image_clear.Name = "image_clear";
            image_clear.ShortcutKeys = Keys.Control | Keys.N;
            image_clear.Size = new Size(149, 22);
            image_clear.Text = "Clear";
            image_clear.Click += ImageClear_Click;
            // 
            // image_resize
            // 
            image_resize.Name = "image_resize";
            image_resize.ShortcutKeys = Keys.Control | Keys.C;
            image_resize.Size = new Size(149, 22);
            image_resize.Text = "Resize";
            image_resize.Click += ImageResize_Click;
            // 
            // image_rotate
            // 
            image_rotate.Name = "image_rotate";
            image_rotate.ShortcutKeys = Keys.Control | Keys.X;
            image_rotate.Size = new Size(149, 22);
            image_rotate.Text = "Rotate";
            image_rotate.Click += ImageRotate_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(146, 6);
            // 
            // image
            // 
            image.Name = "image";
            image.ShortcutKeys = Keys.Control | Keys.S;
            image.Size = new Size(149, 22);
            image.Text = "Save";
            image.Click += ImageSave_Click;
            // 
            // image_load
            // 
            image_load.Name = "image_load";
            image_load.ShortcutKeys = Keys.Control | Keys.O;
            image_load.Size = new Size(149, 22);
            image_load.Text = "Load";
            image_load.Click += ImageLoad_Click;
            // 
            // _mainView
            // 
            _mainView.BackColor = SystemColors.Window;
            _mainView.BackgroundImageLayout = ImageLayout.None;
            _mainView.Location = new Point(0, 24);
            _mainView.Name = "_mainView";
            _mainView.Size = new Size(800, 402);
            _mainView.SizeMode = PictureBoxSizeMode.AutoSize;
            _mainView.TabIndex = 7;
            _mainView.TabStop = false;
            _mainView.ClientSizeChanged += MainView_Move;
            _mainView.MouseDown += MainView_LineDrawStart;
            _mainView.MouseLeave += MainView_MouseLeave;
            _mainView.MouseMove += MainView_Draw;
            _mainView.MouseUp += MainView_LineDrawEnd;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(800, 450);
            Controls.Add(_mainView);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paint by NemoNology";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_mainView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel _outputMouseCoordinates;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripStatusLabel toolStripStatusLabel6;
        private ToolStripStatusLabel _outputCentralPointCoordinates;
        private ToolStripStatusLabel toolStripStatusLabel7;
        private ToolStripStatusLabel b_chooseCP;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menu_image;
        private ToolStripMenuItem image_clear;
        private ToolStripMenuItem image_resize;
        private ToolStripMenuItem image_rotate;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem image;
        private ToolStripMenuItem image_load;
        private PictureBox _mainView;
        private ToolStripStatusLabel toolStripStatusLabel8;
        private ToolStripStatusLabel b_chooseColor;
        private ToolStripStatusLabel toolStripStatusLabel9;
        private ToolStripStatusLabel _outputPictureSize;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
    }
}