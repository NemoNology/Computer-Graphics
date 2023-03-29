namespace Project;

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
        outputMainView = new PictureBox();
        menuStrip1 = new MenuStrip();
        imageToolStripMenuItem = new ToolStripMenuItem();
        loadToolStripMenuItem = new ToolStripMenuItem();
        inputHistBScale = new NumericUpDown();
        inputHistGScale = new NumericUpDown();
        inputHistRScale = new NumericUpDown();
        label9 = new Label();
        label6 = new Label();
        label2 = new Label();
        label8 = new Label();
        label5 = new Label();
        label3 = new Label();
        label7 = new Label();
        label4 = new Label();
        label1 = new Label();
        outputHistB = new PictureBox();
        outputHistG = new PictureBox();
        outputHistR = new PictureBox();
        inputOpenFileDialog = new OpenFileDialog();
        label10 = new Label();
        outputMaxR = new Label();
        label11 = new Label();
        outputMaxG = new Label();
        label13 = new Label();
        outputMaxB = new Label();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)outputMainView).BeginInit();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)inputHistBScale).BeginInit();
        ((System.ComponentModel.ISupportInitialize)inputHistGScale).BeginInit();
        ((System.ComponentModel.ISupportInitialize)inputHistRScale).BeginInit();
        ((System.ComponentModel.ISupportInitialize)outputHistB).BeginInit();
        ((System.ComponentModel.ISupportInitialize)outputHistG).BeginInit();
        ((System.ComponentModel.ISupportInitialize)outputHistR).BeginInit();
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
        splitContainer1.Panel1.Controls.Add(outputMainView);
        splitContainer1.Panel1.Controls.Add(menuStrip1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.BackColor = SystemColors.ButtonShadow;
        splitContainer1.Panel2.Controls.Add(inputHistBScale);
        splitContainer1.Panel2.Controls.Add(inputHistGScale);
        splitContainer1.Panel2.Controls.Add(inputHistRScale);
        splitContainer1.Panel2.Controls.Add(label9);
        splitContainer1.Panel2.Controls.Add(label6);
        splitContainer1.Panel2.Controls.Add(label2);
        splitContainer1.Panel2.Controls.Add(label8);
        splitContainer1.Panel2.Controls.Add(label5);
        splitContainer1.Panel2.Controls.Add(label3);
        splitContainer1.Panel2.Controls.Add(label7);
        splitContainer1.Panel2.Controls.Add(label4);
        splitContainer1.Panel2.Controls.Add(outputMaxB);
        splitContainer1.Panel2.Controls.Add(outputMaxG);
        splitContainer1.Panel2.Controls.Add(outputMaxR);
        splitContainer1.Panel2.Controls.Add(label13);
        splitContainer1.Panel2.Controls.Add(label11);
        splitContainer1.Panel2.Controls.Add(label10);
        splitContainer1.Panel2.Controls.Add(label1);
        splitContainer1.Panel2.Controls.Add(outputHistB);
        splitContainer1.Panel2.Controls.Add(outputHistG);
        splitContainer1.Panel2.Controls.Add(outputHistR);
        splitContainer1.Size = new Size(918, 660);
        splitContainer1.SplitterDistance = 415;
        splitContainer1.SplitterWidth = 10;
        splitContainer1.TabIndex = 0;
        // 
        // outputMainView
        // 
        outputMainView.Dock = DockStyle.Fill;
        outputMainView.Location = new Point(0, 24);
        outputMainView.Name = "outputMainView";
        outputMainView.Size = new Size(918, 391);
        outputMainView.SizeMode = PictureBoxSizeMode.StretchImage;
        outputMainView.TabIndex = 1;
        outputMainView.TabStop = false;
        // 
        // menuStrip1
        // 
        menuStrip1.BackColor = SystemColors.ButtonShadow;
        menuStrip1.Items.AddRange(new ToolStripItem[] { imageToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(918, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // imageToolStripMenuItem
        // 
        imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem });
        imageToolStripMenuItem.Name = "imageToolStripMenuItem";
        imageToolStripMenuItem.Size = new Size(52, 20);
        imageToolStripMenuItem.Text = "Image";
        // 
        // loadToolStripMenuItem
        // 
        loadToolStripMenuItem.Name = "loadToolStripMenuItem";
        loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
        loadToolStripMenuItem.Size = new Size(143, 22);
        loadToolStripMenuItem.Text = "Load";
        loadToolStripMenuItem.Click += ImageLoad_Click;
        // 
        // inputHistBScale
        // 
        inputHistBScale.Location = new Point(724, 198);
        inputHistBScale.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        inputHistBScale.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        inputHistBScale.Name = "inputHistBScale";
        inputHistBScale.Size = new Size(81, 23);
        inputHistBScale.TabIndex = 2;
        inputHistBScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
        inputHistBScale.ValueChanged += Scale_Changed;
        // 
        // inputHistGScale
        // 
        inputHistGScale.Location = new Point(426, 198);
        inputHistGScale.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        inputHistGScale.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        inputHistGScale.Name = "inputHistGScale";
        inputHistGScale.Size = new Size(81, 23);
        inputHistGScale.TabIndex = 2;
        inputHistGScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
        inputHistGScale.ValueChanged += Scale_Changed;
        // 
        // inputHistRScale
        // 
        inputHistRScale.Location = new Point(102, 198);
        inputHistRScale.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        inputHistRScale.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        inputHistRScale.Name = "inputHistRScale";
        inputHistRScale.Size = new Size(81, 23);
        inputHistRScale.TabIndex = 2;
        inputHistRScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
        inputHistRScale.ValueChanged += Scale_Changed;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label9.Location = new Point(679, 200);
        label9.Name = "label9";
        label9.Size = new Size(39, 15);
        label9.TabIndex = 1;
        label9.Text = "Scale:";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label6.Location = new Point(381, 200);
        label6.Name = "label6";
        label6.Size = new Size(39, 15);
        label6.TabIndex = 1;
        label6.Text = "Scale:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label2.Location = new Point(57, 200);
        label2.Name = "label2";
        label2.Size = new Size(39, 15);
        label2.TabIndex = 1;
        label2.Text = "Scale:";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label8.Location = new Point(811, 200);
        label8.Name = "label8";
        label8.Size = new Size(17, 15);
        label8.TabIndex = 1;
        label8.Text = "%";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label5.Location = new Point(513, 200);
        label5.Name = "label5";
        label5.Size = new Size(17, 15);
        label5.TabIndex = 1;
        label5.Text = "%";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label3.Location = new Point(189, 200);
        label3.Name = "label3";
        label3.Size = new Size(17, 15);
        label3.TabIndex = 1;
        label3.Text = "%";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label7.Location = new Point(634, 22);
        label7.Name = "label7";
        label7.Size = new Size(18, 15);
        label7.TabIndex = 1;
        label7.Text = "B:";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label4.Location = new Point(336, 22);
        label4.Name = "label4";
        label4.Size = new Size(19, 15);
        label4.TabIndex = 1;
        label4.Text = "G:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label1.Location = new Point(12, 22);
        label1.Name = "label1";
        label1.Size = new Size(18, 15);
        label1.TabIndex = 1;
        label1.Text = "R:";
        // 
        // outputHistB
        // 
        outputHistB.Location = new Point(634, 40);
        outputHistB.Name = "outputHistB";
        outputHistB.Size = new Size(258, 140);
        outputHistB.SizeMode = PictureBoxSizeMode.StretchImage;
        outputHistB.TabIndex = 0;
        outputHistB.TabStop = false;
        // 
        // outputHistG
        // 
        outputHistG.Location = new Point(336, 40);
        outputHistG.Name = "outputHistG";
        outputHistG.Size = new Size(258, 140);
        outputHistG.SizeMode = PictureBoxSizeMode.StretchImage;
        outputHistG.TabIndex = 0;
        outputHistG.TabStop = false;
        // 
        // outputHistR
        // 
        outputHistR.Location = new Point(12, 40);
        outputHistR.Name = "outputHistR";
        outputHistR.Size = new Size(258, 140);
        outputHistR.SizeMode = PictureBoxSizeMode.StretchImage;
        outputHistR.TabIndex = 0;
        outputHistR.TabStop = false;
        // 
        // inputOpenFileDialog
        // 
        inputOpenFileDialog.FileName = "openFileDialog1";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        label10.Location = new Point(102, 22);
        label10.Name = "label10";
        label10.Size = new Size(33, 15);
        label10.TabIndex = 1;
        label10.Text = "Max:";
        // 
        // outputMaxR
        // 
        outputMaxR.AutoSize = true;
        outputMaxR.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        outputMaxR.Location = new Point(141, 22);
        outputMaxR.Name = "outputMaxR";
        outputMaxR.Size = new Size(16, 15);
        outputMaxR.TabIndex = 1;
        outputMaxR.Text = "...";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        label11.Location = new Point(426, 22);
        label11.Name = "label11";
        label11.Size = new Size(33, 15);
        label11.TabIndex = 1;
        label11.Text = "Max:";
        // 
        // outputMaxG
        // 
        outputMaxG.AutoSize = true;
        outputMaxG.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        outputMaxG.Location = new Point(465, 22);
        outputMaxG.Name = "outputMaxG";
        outputMaxG.Size = new Size(16, 15);
        outputMaxG.TabIndex = 1;
        outputMaxG.Text = "...";
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        label13.Location = new Point(724, 22);
        label13.Name = "label13";
        label13.Size = new Size(33, 15);
        label13.TabIndex = 1;
        label13.Text = "Max:";
        // 
        // outputMaxB
        // 
        outputMaxB.AutoSize = true;
        outputMaxB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        outputMaxB.Location = new Point(763, 22);
        outputMaxB.Name = "outputMaxB";
        outputMaxB.Size = new Size(16, 15);
        outputMaxB.TabIndex = 1;
        outputMaxB.Text = "...";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(918, 660);
        Controls.Add(splitContainer1);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        splitContainer1.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)outputMainView).EndInit();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)inputHistBScale).EndInit();
        ((System.ComponentModel.ISupportInitialize)inputHistGScale).EndInit();
        ((System.ComponentModel.ISupportInitialize)inputHistRScale).EndInit();
        ((System.ComponentModel.ISupportInitialize)outputHistB).EndInit();
        ((System.ComponentModel.ISupportInitialize)outputHistG).EndInit();
        ((System.ComponentModel.ISupportInitialize)outputHistR).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem imageToolStripMenuItem;
    private ToolStripMenuItem loadToolStripMenuItem;
    private OpenFileDialog inputOpenFileDialog;
    private PictureBox outputMainView;
    private NumericUpDown inputHistBScale;
    private NumericUpDown inputHistGScale;
    private NumericUpDown inputHistRScale;
    private Label label9;
    private Label label6;
    private Label label2;
    private Label label8;
    private Label label5;
    private Label label3;
    private Label label7;
    private Label label4;
    private Label label1;
    private PictureBox pictureBox2;
    private PictureBox outputHistG;
    private PictureBox outputHistR;
    private PictureBox outputHistB;
    private Label outputMaxB;
    private Label outputMaxG;
    private Label outputMaxR;
    private Label label13;
    private Label label11;
    private Label label10;
}
