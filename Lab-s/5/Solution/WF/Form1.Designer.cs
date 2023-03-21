namespace WF
{
    partial class Form1
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
            chooseColor_button = new Button();
            inputFillingType = new ComboBox();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            imageToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            inputColor_Dialog = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)outputMainView).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(outputMainView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.Silver;
            splitContainer1.Panel2.Controls.Add(chooseColor_button);
            splitContainer1.Panel2.Controls.Add(inputFillingType);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(menuStrip1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 349;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 0;
            // 
            // outputMainView
            // 
            outputMainView.Dock = DockStyle.Fill;
            outputMainView.Location = new Point(0, 0);
            outputMainView.Name = "outputMainView";
            outputMainView.Size = new Size(800, 349);
            outputMainView.TabIndex = 0;
            outputMainView.TabStop = false;
            outputMainView.SizeChanged += MainView_SizeChanged;
            outputMainView.MouseDown += MainView_LineDrawStart;
            outputMainView.MouseMove += MainView_Draw;
            outputMainView.MouseUp += MainView_LineDrawEnd;
            // 
            // chooseColor_button
            // 
            chooseColor_button.AutoSize = true;
            chooseColor_button.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            chooseColor_button.Location = new Point(620, 32);
            chooseColor_button.Name = "chooseColor_button";
            chooseColor_button.Size = new Size(96, 31);
            chooseColor_button.TabIndex = 2;
            chooseColor_button.Text = "Choose color";
            chooseColor_button.UseVisualStyleBackColor = true;
            chooseColor_button.Click += ChoseColor_Click;
            // 
            // inputFillingType
            // 
            inputFillingType.FormattingEnabled = true;
            inputFillingType.Location = new Point(365, 37);
            inputFillingType.Name = "inputFillingType";
            inputFillingType.Size = new Size(121, 23);
            inputFillingType.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(289, 40);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Filling type:";
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.Items.AddRange(new ToolStripItem[] { imageToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(58, 91);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearToolStripMenuItem });
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(45, 19);
            imageToolStripMenuItem.Text = "Image";
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            clearToolStripMenuItem.Size = new Size(144, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += Image_Clear;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Color Filling";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)outputMainView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox outputMainView;
        private ComboBox inputFillingType;
        private Label label1;
        private Button chooseColor_button;
        private ColorDialog inputColor_Dialog;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
    }
}