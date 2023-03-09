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
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            outputX = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            outputY = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            toolStripStatusLabel5 = new ToolStripStatusLabel();
            outputCPX = new ToolStripStatusLabel();
            toolStripStatusLabel6 = new ToolStripStatusLabel();
            outputCPY = new ToolStripStatusLabel();
            toolStripStatusLabel7 = new ToolStripStatusLabel();
            b_chooseCP = new ToolStripStatusLabel();
            toolStripStatusLabel8 = new ToolStripStatusLabel();
            b_color = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            tool_image = new ToolStripMenuItem();
            image_clear = new ToolStripMenuItem();
            image_resize = new ToolStripMenuItem();
            image_rotate = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            image = new ToolStripMenuItem();
            image_load = new ToolStripMenuItem();
            _mainView = new PictureBox();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_mainView).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.Control;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel4, toolStripStatusLabel1, outputX, toolStripStatusLabel2, outputY, toolStripStatusLabel3, toolStripStatusLabel5, outputCPX, toolStripStatusLabel6, outputCPY, toolStripStatusLabel7, b_chooseCP, toolStripStatusLabel8, b_color });
            statusStrip1.Location = new Point(0, 426);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 24);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel4.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new Size(115, 19);
            toolStripStatusLabel4.Text = "Mouse coordinates:";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel1.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(22, 19);
            toolStripStatusLabel1.Text = "X:";
            // 
            // outputX
            // 
            outputX.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            outputX.BorderStyle = Border3DStyle.Bump;
            outputX.Name = "outputX";
            outputX.Size = new Size(20, 19);
            outputX.Text = "...";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel2.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(21, 19);
            toolStripStatusLabel2.Text = "Y:";
            // 
            // outputY
            // 
            outputY.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            outputY.BorderStyle = Border3DStyle.Bump;
            outputY.Name = "outputY";
            outputY.Size = new Size(20, 19);
            outputY.Text = "...";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel3.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(150, 19);
            toolStripStatusLabel3.Text = "Central Point Coordinates:";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel5.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new Size(22, 19);
            toolStripStatusLabel5.Text = "X:";
            // 
            // outputCPX
            // 
            outputCPX.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            outputCPX.BorderStyle = Border3DStyle.Bump;
            outputCPX.Name = "outputCPX";
            outputCPX.Size = new Size(20, 19);
            outputCPX.Text = "...";
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel6.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new Size(21, 19);
            toolStripStatusLabel6.Text = "Y:";
            // 
            // outputCPY
            // 
            outputCPY.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            outputCPY.BorderStyle = Border3DStyle.Bump;
            outputCPY.Name = "outputCPY";
            outputCPY.Size = new Size(20, 19);
            outputCPY.Text = "...";
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
            // b_color
            // 
            b_color.BackColor = Color.Black;
            b_color.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            b_color.BorderStyle = Border3DStyle.Bump;
            b_color.ForeColor = Color.White;
            b_color.Name = "b_color";
            b_color.Size = new Size(39, 19);
            b_color.Text = "Black";
            b_color.Click += b_color_Click;
            b_color.MouseEnter += b_chooseCP_MouseEnter;
            b_color.MouseLeave += b_chooseCP_MouseLeave;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Items.AddRange(new ToolStripItem[] { tool_image });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // tool_image
            // 
            tool_image.DropDownItems.AddRange(new ToolStripItem[] { image_clear, image_resize, image_rotate, toolStripSeparator1, image, image_load });
            tool_image.Name = "tool_image";
            tool_image.Size = new Size(52, 20);
            tool_image.Text = "Image";
            // 
            // image_clear
            // 
            image_clear.Name = "image_clear";
            image_clear.ShortcutKeys = Keys.Control | Keys.N;
            image_clear.Size = new Size(149, 22);
            image_clear.Text = "Clear";
            // 
            // image_resize
            // 
            image_resize.Name = "image_resize";
            image_resize.ShortcutKeys = Keys.Control | Keys.C;
            image_resize.Size = new Size(149, 22);
            image_resize.Text = "Resize";
            // 
            // image_rotate
            // 
            image_rotate.Name = "image_rotate";
            image_rotate.ShortcutKeys = Keys.Control | Keys.X;
            image_rotate.Size = new Size(149, 22);
            image_rotate.Text = "Rotate";
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
            // 
            // image_load
            // 
            image_load.Name = "image_load";
            image_load.ShortcutKeys = Keys.Control | Keys.O;
            image_load.Size = new Size(149, 22);
            image_load.Text = "Load";
            // 
            // _mainView
            // 
            _mainView.BackColor = SystemColors.Window;
            _mainView.Dock = DockStyle.Fill;
            _mainView.Location = new Point(0, 24);
            _mainView.Name = "_mainView";
            _mainView.Size = new Size(800, 402);
            _mainView.TabIndex = 7;
            _mainView.TabStop = false;
            _mainView.Paint += MainView_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
        private ToolStripStatusLabel outputX;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel outputY;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripStatusLabel outputCPX;
        private ToolStripStatusLabel toolStripStatusLabel6;
        private ToolStripStatusLabel outputCPY;
        private ToolStripStatusLabel toolStripStatusLabel7;
        private ToolStripStatusLabel b_chooseCP;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tool_image;
        private ToolStripMenuItem image_clear;
        private ToolStripMenuItem image_resize;
        private ToolStripMenuItem image_rotate;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem image;
        private ToolStripMenuItem image_load;
        private PictureBox _mainView;
        private ToolStripStatusLabel toolStripStatusLabel8;
        private ToolStripStatusLabel b_color;
    }
}