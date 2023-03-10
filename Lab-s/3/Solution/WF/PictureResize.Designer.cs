namespace WF
{
    partial class PictureResize
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
            b_resize = new Button();
            _inputKX = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            _inputKY = new TextBox();
            statusStrip1 = new StatusStrip();
            _status = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            _outputPictureSize = new ToolStripStatusLabel();
            label5 = new Label();
            label6 = new Label();
            _inputWidth = new NumericUpDown();
            label7 = new Label();
            _inputHeight = new NumericUpDown();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_inputWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_inputHeight).BeginInit();
            SuspendLayout();
            // 
            // b_resize
            // 
            b_resize.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            b_resize.Location = new Point(97, 171);
            b_resize.Margin = new Padding(60);
            b_resize.Name = "b_resize";
            b_resize.Size = new Size(221, 39);
            b_resize.TabIndex = 1;
            b_resize.Text = "Resize";
            b_resize.UseVisualStyleBackColor = true;
            b_resize.Click += ButtonResize_Click;
            // 
            // _inputKX
            // 
            _inputKX.Location = new Point(74, 71);
            _inputKX.Name = "_inputKX";
            _inputKX.Size = new Size(66, 23);
            _inputKX.TabIndex = 2;
            _inputKX.Text = "1";
            _inputKX.TextChanged += Input_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(23, 32);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 0;
            label2.Text = "Resize by coefficient:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(51, 74);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 0;
            label3.Text = "X:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(51, 113);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 0;
            label4.Text = "Y:";
            // 
            // _inputKY
            // 
            _inputKY.Location = new Point(74, 110);
            _inputKY.Name = "_inputKY";
            _inputKY.Size = new Size(66, 23);
            _inputKY.TabIndex = 2;
            _inputKY.Text = "1";
            _inputKY.TextChanged += Input_ValueChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { _status, toolStripStatusLabel1, _outputPictureSize });
            statusStrip1.Location = new Point(0, 237);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(420, 24);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // _status
            // 
            _status.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _status.BorderStyle = Border3DStyle.Bump;
            _status.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            _status.ForeColor = Color.Brown;
            _status.Name = "_status";
            _status.Size = new Size(20, 19);
            _status.Text = "...";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel1.BorderStyle = Border3DStyle.Bump;
            toolStripStatusLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(124, 19);
            toolStripStatusLabel1.Text = "Current picrure size:";
            // 
            // _outputPictureSize
            // 
            _outputPictureSize.BorderSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _outputPictureSize.BorderStyle = Border3DStyle.Bump;
            _outputPictureSize.Name = "_outputPictureSize";
            _outputPictureSize.Size = new Size(20, 19);
            _outputPictureSize.Text = "...";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(208, 32);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 0;
            label5.Text = "Resize by pixels:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(227, 71);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 0;
            label6.Text = "Width:";
            // 
            // _inputWidth
            // 
            _inputWidth.Location = new Point(275, 66);
            _inputWidth.Name = "_inputWidth";
            _inputWidth.Size = new Size(92, 23);
            _inputWidth.TabIndex = 4;
            _inputWidth.ValueChanged += Input_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(227, 113);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 0;
            label7.Text = "Height:";
            // 
            // _inputHeight
            // 
            _inputHeight.Location = new Point(275, 111);
            _inputHeight.Name = "_inputHeight";
            _inputHeight.Size = new Size(92, 23);
            _inputHeight.TabIndex = 4;
            _inputHeight.ValueChanged += Input_ValueChanged;
            // 
            // PictureResize
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 261);
            Controls.Add(_inputHeight);
            Controls.Add(_inputWidth);
            Controls.Add(statusStrip1);
            Controls.Add(_inputKY);
            Controls.Add(_inputKX);
            Controls.Add(b_resize);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "PictureResize";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resize";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_inputWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)_inputHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button b_resize;
        private TextBox _inputKX;
        private Label asd;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox _inputKY;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel _status;
        private Label label5;
        private Label label6;
        private NumericUpDown _inputWidth;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel _outputPictureSize;
        private Label label7;
        private NumericUpDown _inputHeight;
    }
}