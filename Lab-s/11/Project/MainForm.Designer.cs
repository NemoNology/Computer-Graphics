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
        splitContainer2 = new SplitContainer();
        outputBaseImage = new PictureBox();
        outputModifiedImage = new PictureBox();
        outputModifiedHist = new PictureBox();
        outputBaseHist = new PictureBox();
        inputIsB = new RadioButton();
        inputIsG = new RadioButton();
        inputIsR = new RadioButton();
        label1 = new Label();
        menuStrip = new MenuStrip();
        imageToolStripMenuItem = new ToolStripMenuItem();
        loadToolStripMenuItem = new ToolStripMenuItem();
        saveToolStripMenuItem = new ToolStripMenuItem();
        inputOpenFileDialog = new OpenFileDialog();
        inputSaveFileDialog = new SaveFileDialog();
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
        ((System.ComponentModel.ISupportInitialize)outputModifiedHist).BeginInit();
        ((System.ComponentModel.ISupportInitialize)outputBaseHist).BeginInit();
        menuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.BackColor = SystemColors.Control;
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
        splitContainer1.Panel2.BackColor = SystemColors.ScrollBar;
        splitContainer1.Panel2.Controls.Add(outputModifiedHist);
        splitContainer1.Panel2.Controls.Add(outputBaseHist);
        splitContainer1.Panel2.Controls.Add(inputIsB);
        splitContainer1.Panel2.Controls.Add(inputIsG);
        splitContainer1.Panel2.Controls.Add(inputIsR);
        splitContainer1.Panel2.Controls.Add(label1);
        splitContainer1.Panel2.Controls.Add(menuStrip);
        splitContainer1.Size = new Size(877, 637);
        splitContainer1.SplitterDistance = 432;
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
        splitContainer2.Size = new Size(877, 432);
        splitContainer2.SplitterDistance = 440;
        splitContainer2.SplitterWidth = 10;
        splitContainer2.TabIndex = 0;
        // 
        // outputBaseImage
        // 
        outputBaseImage.Dock = DockStyle.Fill;
        outputBaseImage.Location = new Point(0, 0);
        outputBaseImage.Name = "outputBaseImage";
        outputBaseImage.Size = new Size(440, 432);
        outputBaseImage.SizeMode = PictureBoxSizeMode.StretchImage;
        outputBaseImage.TabIndex = 0;
        outputBaseImage.TabStop = false;
        // 
        // outputModifiedImage
        // 
        outputModifiedImage.Dock = DockStyle.Fill;
        outputModifiedImage.Location = new Point(0, 0);
        outputModifiedImage.Name = "outputModifiedImage";
        outputModifiedImage.Size = new Size(427, 432);
        outputModifiedImage.SizeMode = PictureBoxSizeMode.StretchImage;
        outputModifiedImage.TabIndex = 0;
        outputModifiedImage.TabStop = false;
        // 
        // outputModifiedHist
        // 
        outputModifiedHist.Location = new Point(527, 24);
        outputModifiedHist.Name = "outputModifiedHist";
        outputModifiedHist.Size = new Size(300, 150);
        outputModifiedHist.SizeMode = PictureBoxSizeMode.StretchImage;
        outputModifiedHist.TabIndex = 2;
        outputModifiedHist.TabStop = false;
        // 
        // outputBaseHist
        // 
        outputBaseHist.Location = new Point(199, 24);
        outputBaseHist.Name = "outputBaseHist";
        outputBaseHist.Size = new Size(300, 150);
        outputBaseHist.SizeMode = PictureBoxSizeMode.StretchImage;
        outputBaseHist.TabIndex = 2;
        outputBaseHist.TabStop = false;
        // 
        // inputIsB
        // 
        inputIsB.AutoSize = true;
        inputIsB.Location = new Point(120, 125);
        inputIsB.Name = "inputIsB";
        inputIsB.Size = new Size(32, 19);
        inputIsB.TabIndex = 1;
        inputIsB.TabStop = true;
        inputIsB.Text = "B";
        inputIsB.UseVisualStyleBackColor = true;
        // 
        // inputIsG
        // 
        inputIsG.AutoSize = true;
        inputIsG.Location = new Point(120, 100);
        inputIsG.Name = "inputIsG";
        inputIsG.Size = new Size(33, 19);
        inputIsG.TabIndex = 1;
        inputIsG.TabStop = true;
        inputIsG.Text = "G";
        inputIsG.UseVisualStyleBackColor = true;
        // 
        // inputIsR
        // 
        inputIsR.AutoSize = true;
        inputIsR.Checked = true;
        inputIsR.Location = new Point(120, 75);
        inputIsR.Name = "inputIsR";
        inputIsR.Size = new Size(32, 19);
        inputIsR.TabIndex = 1;
        inputIsR.TabStop = true;
        inputIsR.Text = "R";
        inputIsR.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label1.Location = new Point(112, 50);
        label1.Name = "label1";
        label1.Size = new Size(44, 15);
        label1.TabIndex = 0;
        label1.Text = "Chanel";
        // 
        // menuStrip
        // 
        menuStrip.Dock = DockStyle.Left;
        menuStrip.Items.AddRange(new ToolStripItem[] { imageToolStripMenuItem });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(58, 195);
        menuStrip.TabIndex = 3;
        menuStrip.Text = "menuStrip1";
        // 
        // imageToolStripMenuItem
        // 
        imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem });
        imageToolStripMenuItem.Name = "imageToolStripMenuItem";
        imageToolStripMenuItem.Size = new Size(45, 19);
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
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        saveToolStripMenuItem.Size = new Size(143, 22);
        saveToolStripMenuItem.Text = "Save";
        saveToolStripMenuItem.Click += ImageSave_Click;
        // 
        // inputOpenFileDialog
        // 
        inputOpenFileDialog.FileName = "openFileDialog1";
        // 
        // inputSaveFileDialog
        // 
        inputSaveFileDialog.Filter = "png files|*.png";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(877, 637);
        Controls.Add(splitContainer1);
        MainMenuStrip = menuStrip;
        Name = "MainForm";
        Text = "Перекраска изображения по видоизменнёной гистограмме";
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
        ((System.ComponentModel.ISupportInitialize)outputModifiedHist).EndInit();
        ((System.ComponentModel.ISupportInitialize)outputBaseHist).EndInit();
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private SplitContainer splitContainer2;
    private PictureBox outputBaseImage;
    private PictureBox outputModifiedImage;
    private RadioButton inputIsB;
    private RadioButton inputIsG;
    private RadioButton inputIsR;
    private Label label1;
    private PictureBox outputBaseHist;
    private MenuStrip menuStrip;
    private ToolStripMenuItem imageToolStripMenuItem;
    private ToolStripMenuItem loadToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private PictureBox outputModifiedHist;
    private OpenFileDialog inputOpenFileDialog;
    private SaveFileDialog inputSaveFileDialog;
}
