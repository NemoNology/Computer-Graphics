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
        inputColorMode = new ComboBox();
        label1 = new Label();
        menuStrip1 = new MenuStrip();
        imageToolStripMenuItem = new ToolStripMenuItem();
        loadToolStripMenuItem = new ToolStripMenuItem();
        saveToolStripMenuItem = new ToolStripMenuItem();
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
        splitContainer1.Panel2.Controls.Add(inputColorMode);
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
        // inputColorMode
        // 
        inputColorMode.FormattingEnabled = true;
        inputColorMode.Items.AddRange(new object[] { "Usual", "R", "G", "B" });
        inputColorMode.Location = new Point(756, 52);
        inputColorMode.Name = "inputColorMode";
        inputColorMode.Size = new Size(121, 23);
        inputColorMode.TabIndex = 2;
        inputColorMode.SelectedIndexChanged += InputColorModeSelectIndex_Changed;
        // 
        // label1
        // 
        label1.Location = new Point(756, 34);
        label1.Name = "label1";
        label1.Size = new Size(121, 23);
        label1.TabIndex = 1;
        label1.Text = "Режим отрисовки";
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
        Text = "Фильтры";
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
}
