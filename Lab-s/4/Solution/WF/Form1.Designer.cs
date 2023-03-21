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
            _mainView = new PictureBox();
            splitContainer1 = new SplitContainer();
            buttonDraw = new Button();
            inputRDz = new NumericUpDown();
            inputRPz = new NumericUpDown();
            inputCz = new NumericUpDown();
            label15 = new Label();
            label11 = new Label();
            label4 = new Label();
            inputCubeSize = new NumericUpDown();
            inputRDy = new NumericUpDown();
            inputRPy = new NumericUpDown();
            inputCy = new NumericUpDown();
            label14 = new Label();
            label10 = new Label();
            label3 = new Label();
            inputRDx = new NumericUpDown();
            inputRPx = new NumericUpDown();
            label13 = new Label();
            label8 = new Label();
            inputCx = new NumericUpDown();
            label2 = new Label();
            label5 = new Label();
            label12 = new Label();
            label7 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)_mainView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inputRDz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputRPz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputCz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputCubeSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputRDy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputRPy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputCy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputRDx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputRPx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputCx).BeginInit();
            SuspendLayout();
            // 
            // _mainView
            // 
            _mainView.Dock = DockStyle.Fill;
            _mainView.Location = new Point(0, 0);
            _mainView.Name = "_mainView";
            _mainView.Size = new Size(800, 288);
            _mainView.TabIndex = 0;
            _mainView.TabStop = false;
            _mainView.SizeChanged += MainView_SizeChanged;
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
            splitContainer1.Panel1.Controls.Add(_mainView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveBorder;
            splitContainer1.Panel2.Controls.Add(buttonDraw);
            splitContainer1.Panel2.Controls.Add(inputRDz);
            splitContainer1.Panel2.Controls.Add(inputRPz);
            splitContainer1.Panel2.Controls.Add(inputCz);
            splitContainer1.Panel2.Controls.Add(label15);
            splitContainer1.Panel2.Controls.Add(label11);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(inputCubeSize);
            splitContainer1.Panel2.Controls.Add(inputRDy);
            splitContainer1.Panel2.Controls.Add(inputRPy);
            splitContainer1.Panel2.Controls.Add(inputCy);
            splitContainer1.Panel2.Controls.Add(label14);
            splitContainer1.Panel2.Controls.Add(label10);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(inputRDx);
            splitContainer1.Panel2.Controls.Add(inputRPx);
            splitContainer1.Panel2.Controls.Add(label13);
            splitContainer1.Panel2.Controls.Add(label8);
            splitContainer1.Panel2.Controls.Add(inputCx);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label12);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 288;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 1;
            // 
            // buttonDraw
            // 
            buttonDraw.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDraw.Location = new Point(690, 67);
            buttonDraw.Name = "buttonDraw";
            buttonDraw.Size = new Size(83, 40);
            buttonDraw.TabIndex = 3;
            buttonDraw.Text = "Draw";
            buttonDraw.UseVisualStyleBackColor = true;
            buttonDraw.Click += ButtonDraw_Click;
            // 
            // inputRDz
            // 
            inputRDz.Location = new Point(480, 116);
            inputRDz.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            inputRDz.Name = "inputRDz";
            inputRDz.Size = new Size(49, 23);
            inputRDz.TabIndex = 2;
            // 
            // inputRPz
            // 
            inputRPz.Location = new Point(294, 116);
            inputRPz.Name = "inputRPz";
            inputRPz.Size = new Size(83, 23);
            inputRPz.TabIndex = 2;
            // 
            // inputCz
            // 
            inputCz.Location = new Point(51, 116);
            inputCz.Name = "inputCz";
            inputCz.Size = new Size(83, 23);
            inputCz.TabIndex = 2;
            inputCz.Value = new decimal(new int[] { 20, 0, 0, 0 });
            inputCz.ValueChanged += CubeInputs_ValueChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(457, 118);
            label15.Name = "label15";
            label15.Size = new Size(17, 15);
            label15.TabIndex = 1;
            label15.Text = "Z:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(271, 118);
            label11.Name = "label11";
            label11.Size = new Size(17, 15);
            label11.TabIndex = 1;
            label11.Text = "Z:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 118);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 1;
            label4.Text = "Z:";
            // 
            // inputCubeSize
            // 
            inputCubeSize.Location = new Point(173, 72);
            inputCubeSize.Name = "inputCubeSize";
            inputCubeSize.Size = new Size(63, 23);
            inputCubeSize.TabIndex = 2;
            inputCubeSize.Value = new decimal(new int[] { 10, 0, 0, 0 });
            inputCubeSize.ValueChanged += CubeInputs_ValueChanged;
            // 
            // inputRDy
            // 
            inputRDy.Location = new Point(480, 78);
            inputRDy.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            inputRDy.Name = "inputRDy";
            inputRDy.Size = new Size(49, 23);
            inputRDy.TabIndex = 2;
            // 
            // inputRPy
            // 
            inputRPy.Location = new Point(294, 78);
            inputRPy.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            inputRPy.Name = "inputRPy";
            inputRPy.Size = new Size(83, 23);
            inputRPy.TabIndex = 2;
            // 
            // inputCy
            // 
            inputCy.Location = new Point(51, 78);
            inputCy.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            inputCy.Name = "inputCy";
            inputCy.Size = new Size(83, 23);
            inputCy.TabIndex = 2;
            inputCy.ValueChanged += CubeInputs_ValueChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(457, 80);
            label14.Name = "label14";
            label14.Size = new Size(17, 15);
            label14.TabIndex = 1;
            label14.Text = "Y:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(271, 80);
            label10.Name = "label10";
            label10.Size = new Size(17, 15);
            label10.TabIndex = 1;
            label10.Text = "Y:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 80);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 1;
            label3.Text = "Y:";
            // 
            // inputRDx
            // 
            inputRDx.Location = new Point(480, 37);
            inputRDx.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            inputRDx.Name = "inputRDx";
            inputRDx.Size = new Size(49, 23);
            inputRDx.TabIndex = 2;
            // 
            // inputRPx
            // 
            inputRPx.Location = new Point(294, 37);
            inputRPx.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            inputRPx.Name = "inputRPx";
            inputRPx.Size = new Size(83, 23);
            inputRPx.TabIndex = 2;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(457, 39);
            label13.Name = "label13";
            label13.Size = new Size(17, 15);
            label13.TabIndex = 1;
            label13.Text = "X:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(271, 39);
            label8.Name = "label8";
            label8.Size = new Size(17, 15);
            label8.TabIndex = 1;
            label8.Text = "X:";
            // 
            // inputCx
            // 
            inputCx.Location = new Point(51, 37);
            inputCx.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            inputCx.Name = "inputCx";
            inputCx.Size = new Size(83, 23);
            inputCx.TabIndex = 2;
            inputCx.ValueChanged += CubeInputs_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 39);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 1;
            label2.Text = "X:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(161, 54);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 0;
            label5.Text = "Cube side size:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(438, 12);
            label12.Name = "label12";
            label12.Size = new Size(124, 15);
            label12.TabIndex = 0;
            label12.Text = "Rotations in degrees:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(255, 12);
            label7.Name = "label7";
            label7.Size = new Size(158, 15);
            label7.TabIndex = 0;
            label7.Text = "Rotation Point coordinates:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(147, 15);
            label1.TabIndex = 0;
            label1.Text = "Cube Center coordinates:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)_mainView).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inputRDz).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputRPz).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputCz).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputCubeSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputRDy).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputRPy).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputCy).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputRDx).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputRPx).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputCx).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox _mainView;
        private SplitContainer splitContainer1;
        private Label label1;
        private NumericUpDown inputCz;
        private Label label4;
        private NumericUpDown inputCy;
        private Label label3;
        private NumericUpDown inputCx;
        private Label label2;
        private NumericUpDown inputCubeSize;
        private Label label5;
        private Button buttonDraw;
        private NumericUpDown inputRPz;
        private Label label11;
        private NumericUpDown inputRPy;
        private Label label10;
        private NumericUpDown inputRPx;
        private Label label8;
        private Label label7;
        private NumericUpDown inputRDz;
        private Label label15;
        private NumericUpDown inputRDy;
        private Label label14;
        private NumericUpDown inputRDx;
        private Label label13;
        private Label label12;
    }
}