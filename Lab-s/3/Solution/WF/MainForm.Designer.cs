namespace WF
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            mainView = new PictureBox();
            GB_centralPointCoordinates = new GroupBox();
            l_x = new Label();
            b_rotate = new Button();
            inputX = new NumericUpDown();
            input_y = new NumericUpDown();
            l_y = new Label();
            GB_rotateSettings = new GroupBox();
            l_rotateAngle = new Label();
            inputRotateAngle = new NumericUpDown();
            l_degrees = new Label();
            button1 = new Button();
            button2 = new Button();
            b_chooseCentralPoint = new Button();
            menuStrip1 = new MenuStrip();
            tool_image = new ToolStripMenuItem();
            image_clear = new ToolStripMenuItem();
            image_load = new ToolStripMenuItem();
            image = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            image_resize = new ToolStripMenuItem();
            image_rotate = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainView).BeginInit();
            GB_centralPointCoordinates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inputX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)input_y).BeginInit();
            GB_rotateSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inputRotateAngle).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.Control;
            splitContainer1.Panel1.Controls.Add(mainView);
            splitContainer1.Panel1.Controls.Add(menuStrip1);
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveBorder;
            splitContainer1.Panel2.Controls.Add(GB_rotateSettings);
            splitContainer1.Panel2.Controls.Add(GB_centralPointCoordinates);
            splitContainer1.Panel2.RightToLeft = RightToLeft.No;
            splitContainer1.Size = new Size(911, 697);
            splitContainer1.SplitterDistance = 542;
            splitContainer1.TabIndex = 0;
            // 
            // mainView
            // 
            mainView.Dock = DockStyle.Fill;
            mainView.Location = new Point(0, 24);
            mainView.Name = "mainView";
            mainView.Size = new Size(911, 518);
            mainView.TabIndex = 0;
            mainView.TabStop = false;
            // 
            // GB_centralPointCoordinates
            // 
            GB_centralPointCoordinates.Controls.Add(l_y);
            GB_centralPointCoordinates.Controls.Add(l_x);
            GB_centralPointCoordinates.Controls.Add(b_chooseCentralPoint);
            GB_centralPointCoordinates.Controls.Add(input_y);
            GB_centralPointCoordinates.Controls.Add(inputX);
            GB_centralPointCoordinates.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GB_centralPointCoordinates.Location = new Point(12, 21);
            GB_centralPointCoordinates.Name = "GB_centralPointCoordinates";
            GB_centralPointCoordinates.Size = new Size(187, 118);
            GB_centralPointCoordinates.TabIndex = 3;
            GB_centralPointCoordinates.TabStop = false;
            GB_centralPointCoordinates.Text = "Central Point Coordinates";
            // 
            // l_x
            // 
            l_x.Anchor = AnchorStyles.None;
            l_x.AutoSize = true;
            l_x.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            l_x.Location = new Point(22, 24);
            l_x.Name = "l_x";
            l_x.Size = new Size(18, 15);
            l_x.TabIndex = 0;
            l_x.Text = "X:";
            // 
            // b_rotate
            // 
            b_rotate.Anchor = AnchorStyles.None;
            b_rotate.Location = new Point(237, 24);
            b_rotate.Name = "b_rotate";
            b_rotate.Size = new Size(75, 23);
            b_rotate.TabIndex = 2;
            b_rotate.Text = "Rotate";
            b_rotate.UseVisualStyleBackColor = true;
            // 
            // inputX
            // 
            inputX.Anchor = AnchorStyles.None;
            inputX.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            inputX.Location = new Point(46, 22);
            inputX.Name = "inputX";
            inputX.Size = new Size(120, 23);
            inputX.TabIndex = 1;
            // 
            // input_y
            // 
            input_y.Anchor = AnchorStyles.None;
            input_y.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            input_y.Location = new Point(46, 51);
            input_y.Name = "input_y";
            input_y.Size = new Size(120, 23);
            input_y.TabIndex = 1;
            // 
            // l_y
            // 
            l_y.Anchor = AnchorStyles.None;
            l_y.AutoSize = true;
            l_y.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            l_y.Location = new Point(22, 53);
            l_y.Name = "l_y";
            l_y.Size = new Size(17, 15);
            l_y.TabIndex = 0;
            l_y.Text = "Y:";
            // 
            // GB_rotateSettings
            // 
            GB_rotateSettings.Controls.Add(l_degrees);
            GB_rotateSettings.Controls.Add(button2);
            GB_rotateSettings.Controls.Add(button1);
            GB_rotateSettings.Controls.Add(b_rotate);
            GB_rotateSettings.Controls.Add(l_rotateAngle);
            GB_rotateSettings.Controls.Add(inputRotateAngle);
            GB_rotateSettings.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GB_rotateSettings.Location = new Point(242, 21);
            GB_rotateSettings.Name = "GB_rotateSettings";
            GB_rotateSettings.Size = new Size(330, 105);
            GB_rotateSettings.TabIndex = 3;
            GB_rotateSettings.TabStop = false;
            GB_rotateSettings.Text = "Rotate Settings";
            // 
            // l_rotateAngle
            // 
            l_rotateAngle.Anchor = AnchorStyles.None;
            l_rotateAngle.AutoSize = true;
            l_rotateAngle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            l_rotateAngle.Location = new Point(24, 28);
            l_rotateAngle.Name = "l_rotateAngle";
            l_rotateAngle.Size = new Size(83, 15);
            l_rotateAngle.TabIndex = 0;
            l_rotateAngle.Text = "Rotate Angle:";
            // 
            // inputRotateAngle
            // 
            inputRotateAngle.Anchor = AnchorStyles.None;
            inputRotateAngle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            inputRotateAngle.Location = new Point(113, 26);
            inputRotateAngle.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            inputRotateAngle.Name = "inputRotateAngle";
            inputRotateAngle.Size = new Size(54, 23);
            inputRotateAngle.TabIndex = 1;
            // 
            // l_degrees
            // 
            l_degrees.Anchor = AnchorStyles.None;
            l_degrees.AutoSize = true;
            l_degrees.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            l_degrees.Location = new Point(173, 28);
            l_degrees.Name = "l_degrees";
            l_degrees.Size = new Size(48, 15);
            l_degrees.TabIndex = 0;
            l_degrees.Text = "degrees";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(24, 66);
            button1.Name = "button1";
            button1.Size = new Size(118, 23);
            button1.TabIndex = 2;
            button1.Text = "Start Rotating";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(173, 66);
            button2.Name = "button2";
            button2.Size = new Size(118, 23);
            button2.TabIndex = 2;
            button2.Text = "Stop Rotating";
            button2.UseVisualStyleBackColor = true;
            // 
            // b_chooseCentralPoint
            // 
            b_chooseCentralPoint.Anchor = AnchorStyles.None;
            b_chooseCentralPoint.Location = new Point(55, 82);
            b_chooseCentralPoint.Name = "b_chooseCentralPoint";
            b_chooseCentralPoint.Size = new Size(87, 23);
            b_chooseCentralPoint.TabIndex = 2;
            b_chooseCentralPoint.Text = "Choose";
            b_chooseCentralPoint.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tool_image });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(911, 24);
            menuStrip1.TabIndex = 1;
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
            image_clear.Size = new Size(180, 22);
            image_clear.Text = "Clear";
            // 
            // image_load
            // 
            image_load.Name = "image_load";
            image_load.ShortcutKeys = Keys.Control | Keys.O;
            image_load.Size = new Size(180, 22);
            image_load.Text = "Load";
            // 
            // image
            // 
            image.Name = "image";
            image.ShortcutKeys = Keys.Control | Keys.S;
            image.Size = new Size(180, 22);
            image.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // image_resize
            // 
            image_resize.Name = "image_resize";
            image_resize.ShortcutKeys = Keys.Control | Keys.C;
            image_resize.Size = new Size(180, 22);
            image_resize.Text = "Resize";
            // 
            // image_rotate
            // 
            image_rotate.Name = "image_rotate";
            image_rotate.ShortcutKeys = Keys.Control | Keys.X;
            image_rotate.Size = new Size(180, 22);
            image_rotate.Text = "Rotate";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 697);
            Controls.Add(splitContainer1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainView).EndInit();
            GB_centralPointCoordinates.ResumeLayout(false);
            GB_centralPointCoordinates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inputX).EndInit();
            ((System.ComponentModel.ISupportInitialize)input_y).EndInit();
            GB_rotateSettings.ResumeLayout(false);
            GB_rotateSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inputRotateAngle).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox mainView;
        private Button b_rotate;
        private NumericUpDown inputX;
        private Label l_x;
        private GroupBox GB_centralPointCoordinates;
        private GroupBox GB_rotateSettings;
        private Label l_rotateAngle;
        private NumericUpDown inputRotateAngle;
        private Label l_y;
        private NumericUpDown input_y;
        private Label l_degrees;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tool_image;
        private ToolStripMenuItem image_clear;
        private ToolStripMenuItem image_load;
        private Button button2;
        private Button button1;
        private Button b_chooseCentralPoint;
        private ToolStripMenuItem image;
        private ToolStripMenuItem image_resize;
        private ToolStripMenuItem image_rotate;
        private ToolStripSeparator toolStripSeparator1;
    }
}