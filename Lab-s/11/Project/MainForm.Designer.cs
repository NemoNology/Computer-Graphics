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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.outputBaseImage = new System.Windows.Forms.PictureBox();
            this.outputModifiedImage = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outputModifiedHist = new System.Windows.Forms.PictureBox();
            this.outputBaseHist = new System.Windows.Forms.PictureBox();
            this.inputIsB = new System.Windows.Forms.RadioButton();
            this.inputIsG = new System.Windows.Forms.RadioButton();
            this.inputIsR = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.inputSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputBaseImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputModifiedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputModifiedHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputBaseHist)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.outputModifiedHist);
            this.splitContainer1.Panel2.Controls.Add(this.outputBaseHist);
            this.splitContainer1.Panel2.Controls.Add(this.inputIsB);
            this.splitContainer1.Panel2.Controls.Add(this.inputIsG);
            this.splitContainer1.Panel2.Controls.Add(this.inputIsR);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.menuStrip);
            this.splitContainer1.Size = new System.Drawing.Size(877, 637);
            this.splitContainer1.SplitterDistance = 432;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.outputBaseImage);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.outputModifiedImage);
            this.splitContainer2.Size = new System.Drawing.Size(877, 432);
            this.splitContainer2.SplitterDistance = 440;
            this.splitContainer2.SplitterWidth = 10;
            this.splitContainer2.TabIndex = 0;
            // 
            // outputBaseImage
            // 
            this.outputBaseImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputBaseImage.Location = new System.Drawing.Point(0, 0);
            this.outputBaseImage.Name = "outputBaseImage";
            this.outputBaseImage.Size = new System.Drawing.Size(440, 432);
            this.outputBaseImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outputBaseImage.TabIndex = 0;
            this.outputBaseImage.TabStop = false;
            // 
            // outputModifiedImage
            // 
            this.outputModifiedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputModifiedImage.Location = new System.Drawing.Point(0, 0);
            this.outputModifiedImage.Name = "outputModifiedImage";
            this.outputModifiedImage.Size = new System.Drawing.Size(427, 432);
            this.outputModifiedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outputModifiedImage.TabIndex = 0;
            this.outputModifiedImage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Modified Image Histogram";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Base Image Histogram";
            // 
            // outputModifiedHist
            // 
            this.outputModifiedHist.BackColor = System.Drawing.SystemColors.Control;
            this.outputModifiedHist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputModifiedHist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outputModifiedHist.Location = new System.Drawing.Point(527, 33);
            this.outputModifiedHist.Name = "outputModifiedHist";
            this.outputModifiedHist.Size = new System.Drawing.Size(256, 150);
            this.outputModifiedHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outputModifiedHist.TabIndex = 2;
            this.outputModifiedHist.TabStop = false;
            this.outputModifiedHist.DoubleClick += new System.EventHandler(this.OutputModifiedHist_DoubleClick);
            // 
            // outputBaseHist
            // 
            this.outputBaseHist.BackColor = System.Drawing.SystemColors.Control;
            this.outputBaseHist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputBaseHist.Location = new System.Drawing.Point(199, 33);
            this.outputBaseHist.Name = "outputBaseHist";
            this.outputBaseHist.Size = new System.Drawing.Size(256, 150);
            this.outputBaseHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outputBaseHist.TabIndex = 2;
            this.outputBaseHist.TabStop = false;
            // 
            // inputIsB
            // 
            this.inputIsB.AutoSize = true;
            this.inputIsB.Location = new System.Drawing.Point(116, 125);
            this.inputIsB.Name = "inputIsB";
            this.inputIsB.Size = new System.Drawing.Size(32, 19);
            this.inputIsB.TabIndex = 1;
            this.inputIsB.TabStop = true;
            this.inputIsB.Text = "B";
            this.inputIsB.UseVisualStyleBackColor = true;
            this.inputIsB.CheckedChanged += new System.EventHandler(this.InputChannel_CheckedChanged);
            // 
            // inputIsG
            // 
            this.inputIsG.AutoSize = true;
            this.inputIsG.Location = new System.Drawing.Point(116, 100);
            this.inputIsG.Name = "inputIsG";
            this.inputIsG.Size = new System.Drawing.Size(33, 19);
            this.inputIsG.TabIndex = 1;
            this.inputIsG.TabStop = true;
            this.inputIsG.Text = "G";
            this.inputIsG.UseVisualStyleBackColor = true;
            this.inputIsG.CheckedChanged += new System.EventHandler(this.InputChannel_CheckedChanged);
            // 
            // inputIsR
            // 
            this.inputIsR.AutoSize = true;
            this.inputIsR.Checked = true;
            this.inputIsR.Location = new System.Drawing.Point(116, 75);
            this.inputIsR.Name = "inputIsR";
            this.inputIsR.Size = new System.Drawing.Size(32, 19);
            this.inputIsR.TabIndex = 1;
            this.inputIsR.TabStop = true;
            this.inputIsR.Text = "R";
            this.inputIsR.UseVisualStyleBackColor = true;
            this.inputIsR.CheckedChanged += new System.EventHandler(this.InputChannel_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(105, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Channel";
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(58, 195);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(45, 19);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.ImageLoad_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.ImageSave_Click);
            // 
            // inputOpenFileDialog
            // 
            this.inputOpenFileDialog.FileName = "openFileDialog1";
            // 
            // inputSaveFileDialog
            // 
            this.inputSaveFileDialog.Filter = "png files|*.png";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 637);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перекраска изображения по видоизменнёной гистограмме";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outputBaseImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputModifiedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputModifiedHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputBaseHist)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

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
    private Label label3;
    private Label label2;
}
