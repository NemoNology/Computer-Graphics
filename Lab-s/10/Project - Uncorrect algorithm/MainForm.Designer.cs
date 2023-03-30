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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        splitContainer1 = new SplitContainer();
        splitContainer2 = new SplitContainer();
        outputBaseImage = new PictureBox();
        outputModifiedImage = new PictureBox();
        button1 = new Button();
        inputCalculateB = new CheckBox();
        inputFillEmptyPixelsWithZero = new CheckBox();
        inputGetPixelsFromBaseImage = new CheckBox();
        inputCalculateG = new CheckBox();
        inputCalculateR = new CheckBox();
        inputMatrix = new DataGridView();
        inputK = new TextBox();
        inputN = new NumericUpDown();
        label8 = new Label();
        label10 = new Label();
        label9 = new Label();
        label3 = new Label();
        label7 = new Label();
        inputFilterPattern = new ComboBox();
        inputColorMode = new ComboBox();
        label5 = new Label();
        label11 = new Label();
        label6 = new Label();
        label4 = new Label();
        label2 = new Label();
        label1 = new Label();
        menuStrip1 = new MenuStrip();
        imageToolStripMenuItem = new ToolStripMenuItem();
        loadToolStripMenuItem = new ToolStripMenuItem();
        saveToolStripMenuItem = new ToolStripMenuItem();
        saveModifiedPictureAsBaseToolStripMenuItem = new ToolStripMenuItem();
        openFileDialog = new OpenFileDialog();
        saveFileDialog = new SaveFileDialog();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
        splitContainer2.Panel1.SuspendLayout();
        splitContainer2.Panel2.SuspendLayout();
        splitContainer2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)outputBaseImage).BeginInit();
        ((System.ComponentModel.ISupportInitialize)outputModifiedImage).BeginInit();
        ((System.ComponentModel.ISupportInitialize)inputMatrix).BeginInit();
        ((System.ComponentModel.ISupportInitialize)inputN).BeginInit();
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
        splitContainer1.Panel1.Controls.Add(splitContainer2);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.BackColor = SystemColors.ButtonShadow;
        splitContainer1.Panel2.Controls.Add(button1);
        splitContainer1.Panel2.Controls.Add(inputCalculateB);
        splitContainer1.Panel2.Controls.Add(inputFillEmptyPixelsWithZero);
        splitContainer1.Panel2.Controls.Add(inputGetPixelsFromBaseImage);
        splitContainer1.Panel2.Controls.Add(inputCalculateG);
        splitContainer1.Panel2.Controls.Add(inputCalculateR);
        splitContainer1.Panel2.Controls.Add(inputMatrix);
        splitContainer1.Panel2.Controls.Add(inputK);
        splitContainer1.Panel2.Controls.Add(inputN);
        splitContainer1.Panel2.Controls.Add(label8);
        splitContainer1.Panel2.Controls.Add(label10);
        splitContainer1.Panel2.Controls.Add(label9);
        splitContainer1.Panel2.Controls.Add(label3);
        splitContainer1.Panel2.Controls.Add(label7);
        splitContainer1.Panel2.Controls.Add(inputFilterPattern);
        splitContainer1.Panel2.Controls.Add(inputColorMode);
        splitContainer1.Panel2.Controls.Add(label5);
        splitContainer1.Panel2.Controls.Add(label11);
        splitContainer1.Panel2.Controls.Add(label6);
        splitContainer1.Panel2.Controls.Add(label4);
        splitContainer1.Panel2.Controls.Add(label2);
        splitContainer1.Panel2.Controls.Add(label1);
        splitContainer1.Panel2.Controls.Add(menuStrip1);
        splitContainer1.Size = new Size(927, 658);
        splitContainer1.SplitterDistance = 435;
        splitContainer1.SplitterWidth = 10;
        splitContainer1.TabIndex = 0;
        // 
        // splitContainer2
        // 
        splitContainer2.Dock = DockStyle.Fill;
        splitContainer2.Location = new Point(0, 0);
        splitContainer2.Name = "splitContainer2";
        // 
        // splitContainer2.Panel1
        // 
        splitContainer2.Panel1.Controls.Add(outputBaseImage);
        // 
        // splitContainer2.Panel2
        // 
        splitContainer2.Panel2.Controls.Add(outputModifiedImage);
        splitContainer2.Size = new Size(927, 435);
        splitContainer2.SplitterDistance = 455;
        splitContainer2.SplitterWidth = 10;
        splitContainer2.TabIndex = 0;
        // 
        // outputBaseImage
        // 
        outputBaseImage.Dock = DockStyle.Fill;
        outputBaseImage.Location = new Point(0, 0);
        outputBaseImage.Name = "outputBaseImage";
        outputBaseImage.Size = new Size(455, 435);
        outputBaseImage.SizeMode = PictureBoxSizeMode.StretchImage;
        outputBaseImage.TabIndex = 0;
        outputBaseImage.TabStop = false;
        // 
        // outputModifiedImage
        // 
        outputModifiedImage.Dock = DockStyle.Fill;
        outputModifiedImage.Location = new Point(0, 0);
        outputModifiedImage.Name = "outputModifiedImage";
        outputModifiedImage.Size = new Size(462, 435);
        outputModifiedImage.SizeMode = PictureBoxSizeMode.StretchImage;
        outputModifiedImage.TabIndex = 0;
        outputModifiedImage.TabStop = false;
        // 
        // button1
        // 
        button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        button1.Location = new Point(777, 137);
        button1.Name = "button1";
        button1.Size = new Size(101, 54);
        button1.TabIndex = 7;
        button1.Text = "Apply Filter";
        button1.UseVisualStyleBackColor = true;
        button1.Click += ApplyFilter_Click;
        // 
        // inputCalculateB
        // 
        inputCalculateB.AutoSize = true;
        inputCalculateB.Location = new Point(710, 61);
        inputCalculateB.Name = "inputCalculateB";
        inputCalculateB.Size = new Size(15, 14);
        inputCalculateB.TabIndex = 6;
        inputCalculateB.UseVisualStyleBackColor = true;
        // 
        // inputFillEmptyPixelsWithZero
        // 
        inputFillEmptyPixelsWithZero.AutoSize = true;
        inputFillEmptyPixelsWithZero.Checked = true;
        inputFillEmptyPixelsWithZero.CheckState = CheckState.Checked;
        inputFillEmptyPixelsWithZero.Location = new Point(244, 167);
        inputFillEmptyPixelsWithZero.Name = "inputFillEmptyPixelsWithZero";
        inputFillEmptyPixelsWithZero.Size = new Size(15, 14);
        inputFillEmptyPixelsWithZero.TabIndex = 6;
        inputFillEmptyPixelsWithZero.UseVisualStyleBackColor = true;
        // 
        // inputGetPixelsFromBaseImage
        // 
        inputGetPixelsFromBaseImage.AutoSize = true;
        inputGetPixelsFromBaseImage.Checked = true;
        inputGetPixelsFromBaseImage.CheckState = CheckState.Checked;
        inputGetPixelsFromBaseImage.Location = new Point(244, 123);
        inputGetPixelsFromBaseImage.Name = "inputGetPixelsFromBaseImage";
        inputGetPixelsFromBaseImage.Size = new Size(15, 14);
        inputGetPixelsFromBaseImage.TabIndex = 6;
        inputGetPixelsFromBaseImage.UseVisualStyleBackColor = true;
        // 
        // inputCalculateG
        // 
        inputCalculateG.AutoSize = true;
        inputCalculateG.Location = new Point(654, 61);
        inputCalculateG.Name = "inputCalculateG";
        inputCalculateG.Size = new Size(15, 14);
        inputCalculateG.TabIndex = 6;
        inputCalculateG.UseVisualStyleBackColor = true;
        // 
        // inputCalculateR
        // 
        inputCalculateR.AutoSize = true;
        inputCalculateR.Checked = true;
        inputCalculateR.CheckState = CheckState.Checked;
        inputCalculateR.Location = new Point(603, 61);
        inputCalculateR.Name = "inputCalculateR";
        inputCalculateR.Size = new Size(15, 14);
        inputCalculateR.TabIndex = 6;
        inputCalculateR.UseVisualStyleBackColor = true;
        // 
        // inputMatrix
        // 
        inputMatrix.AllowUserToAddRows = false;
        inputMatrix.AllowUserToDeleteRows = false;
        inputMatrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
        inputMatrix.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        inputMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        inputMatrix.Location = new Point(303, 32);
        inputMatrix.Name = "inputMatrix";
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Control;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        inputMatrix.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
        inputMatrix.RowTemplate.Height = 25;
        inputMatrix.Size = new Size(247, 169);
        inputMatrix.TabIndex = 5;
        // 
        // inputK
        // 
        inputK.Location = new Point(101, 71);
        inputK.Name = "inputK";
        inputK.Size = new Size(77, 23);
        inputK.TabIndex = 4;
        inputK.Text = "1";
        // 
        // inputN
        // 
        inputN.Location = new Point(101, 32);
        inputN.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        inputN.Name = "inputN";
        inputN.Size = new Size(77, 23);
        inputN.TabIndex = 3;
        inputN.Value = new decimal(new int[] { 1, 0, 0, 0 });
        inputN.ValueChanged += InputNValue_Changed;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        label8.Location = new Point(687, 60);
        label8.Name = "label8";
        label8.Size = new Size(17, 15);
        label8.TabIndex = 1;
        label8.Text = "B:";
        label8.TextAlign = ContentAlignment.TopCenter;
        // 
        // label10
        // 
        label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label10.Location = new Point(76, 159);
        label10.Name = "label10";
        label10.Size = new Size(162, 42);
        label10.TabIndex = 1;
        label10.Text = "Fill pixels data that is not inside a picture with 0:";
        label10.TextAlign = ContentAlignment.TopCenter;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label9.Location = new Point(76, 122);
        label9.Name = "label9";
        label9.Size = new Size(162, 15);
        label9.TabIndex = 1;
        label9.Text = "Get pixels from base image:";
        label9.TextAlign = ContentAlignment.TopCenter;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label3.Location = new Point(76, 74);
        label3.Name = "label3";
        label3.Size = new Size(18, 15);
        label3.TabIndex = 1;
        label3.Text = "K:";
        label3.TextAlign = ContentAlignment.TopCenter;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        label7.Location = new Point(631, 60);
        label7.Name = "label7";
        label7.Size = new Size(18, 15);
        label7.TabIndex = 1;
        label7.Text = "G:";
        label7.TextAlign = ContentAlignment.TopCenter;
        // 
        // inputFilterPattern
        // 
        inputFilterPattern.FormattingEnabled = true;
        inputFilterPattern.Location = new Point(580, 154);
        inputFilterPattern.Name = "inputFilterPattern";
        inputFilterPattern.Size = new Size(145, 23);
        inputFilterPattern.TabIndex = 2;
        inputFilterPattern.SelectedIndexChanged += InputFilterPatternSelectedIndex_Changed;
        // 
        // inputColorMode
        // 
        inputColorMode.FormattingEnabled = true;
        inputColorMode.Items.AddRange(new object[] { "Usual", "R", "G", "B" });
        inputColorMode.Location = new Point(757, 60);
        inputColorMode.Name = "inputColorMode";
        inputColorMode.Size = new Size(121, 23);
        inputColorMode.TabIndex = 2;
        inputColorMode.SelectedIndexChanged += InputColorModeSelectIndex_Changed;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        label5.Location = new Point(580, 60);
        label5.Name = "label5";
        label5.Size = new Size(17, 15);
        label5.TabIndex = 1;
        label5.Text = "R:";
        label5.TextAlign = ContentAlignment.TopCenter;
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label11.Location = new Point(608, 123);
        label11.Name = "label11";
        label11.Size = new Size(89, 15);
        label11.TabIndex = 1;
        label11.Text = "Filter patterns:";
        label11.TextAlign = ContentAlignment.TopCenter;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label6.Location = new Point(622, 34);
        label6.Name = "label6";
        label6.Size = new Size(59, 15);
        label6.TabIndex = 1;
        label6.Text = "Channels:";
        label6.TextAlign = ContentAlignment.TopCenter;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label4.Location = new Point(278, 34);
        label4.Name = "label4";
        label4.Size = new Size(21, 15);
        label4.TabIndex = 1;
        label4.Text = "M:";
        label4.TextAlign = ContentAlignment.TopCenter;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label2.Location = new Point(76, 34);
        label2.Name = "label2";
        label2.Size = new Size(19, 15);
        label2.TabIndex = 1;
        label2.Text = "N:";
        label2.TextAlign = ContentAlignment.TopCenter;
        // 
        // label1
        // 
        label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label1.Location = new Point(757, 34);
        label1.Name = "label1";
        label1.Size = new Size(121, 23);
        label1.TabIndex = 1;
        label1.Text = "View mode";
        label1.TextAlign = ContentAlignment.TopCenter;
        // 
        // menuStrip1
        // 
        menuStrip1.Dock = DockStyle.Left;
        menuStrip1.Items.AddRange(new ToolStripItem[] { imageToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(58, 213);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // imageToolStripMenuItem
        // 
        imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem, saveModifiedPictureAsBaseToolStripMenuItem });
        imageToolStripMenuItem.Name = "imageToolStripMenuItem";
        imageToolStripMenuItem.Size = new Size(45, 19);
        imageToolStripMenuItem.Text = "Image";
        // 
        // loadToolStripMenuItem
        // 
        loadToolStripMenuItem.Name = "loadToolStripMenuItem";
        loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
        loadToolStripMenuItem.Size = new Size(323, 22);
        loadToolStripMenuItem.Text = "Load";
        loadToolStripMenuItem.Click += ImageLoad_Click;
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        saveToolStripMenuItem.Size = new Size(323, 22);
        saveToolStripMenuItem.Text = "Save";
        saveToolStripMenuItem.Click += ImageSave_Click;
        // 
        // saveModifiedPictureAsBaseToolStripMenuItem
        // 
        saveModifiedPictureAsBaseToolStripMenuItem.Name = "saveModifiedPictureAsBaseToolStripMenuItem";
        saveModifiedPictureAsBaseToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
        saveModifiedPictureAsBaseToolStripMenuItem.Size = new Size(323, 22);
        saveModifiedPictureAsBaseToolStripMenuItem.Text = "Replace base image by modified";
        saveModifiedPictureAsBaseToolStripMenuItem.Click += ReplaceBaseImageByModified_Click;
        // 
        // openFileDialog
        // 
        openFileDialog.FileName = "openFileDialog1";
        // 
        // saveFileDialog
        // 
        saveFileDialog.Filter = "png files|*.png";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(927, 658);
        Controls.Add(splitContainer1);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Матричные фильтры обработки изображений";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        splitContainer1.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        splitContainer2.Panel1.ResumeLayout(false);
        splitContainer2.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
        splitContainer2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)outputBaseImage).EndInit();
        ((System.ComponentModel.ISupportInitialize)outputModifiedImage).EndInit();
        ((System.ComponentModel.ISupportInitialize)inputMatrix).EndInit();
        ((System.ComponentModel.ISupportInitialize)inputN).EndInit();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private SplitContainer splitContainer2;
    private PictureBox outputBaseImage;
    private PictureBox outputModifiedImage;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem imageToolStripMenuItem;
    private ToolStripMenuItem loadToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private OpenFileDialog openFileDialog;
    private SaveFileDialog saveFileDialog;
    private ComboBox inputColorMode;
    private Label label1;
    private TextBox inputK;
    private NumericUpDown inputN;
    private Label label3;
    private Label label2;
    private DataGridView inputMatrix;
    private Label label4;
    private CheckBox inputCalculateB;
    private CheckBox inputCalculateG;
    private CheckBox inputCalculateR;
    private Label label8;
    private Label label7;
    private Label label5;
    private Label label6;
    private CheckBox inputGetPixelsFromBaseImage;
    private Label label9;
    private CheckBox inputFillEmptyPixelsWithZero;
    private Label label10;
    private Button button1;
    private ComboBox inputFilterPattern;
    private Label label11;
    private ToolStripMenuItem saveModifiedPictureAsBaseToolStripMenuItem;
}
