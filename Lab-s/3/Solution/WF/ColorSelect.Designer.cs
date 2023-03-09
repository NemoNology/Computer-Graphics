namespace WF
{
    partial class ColorSelect
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
            label1 = new Label();
            _colors = new ComboBox();
            _outputColor = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 33);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Color:";
            // 
            // _colors
            // 
            _colors.FormattingEnabled = true;
            _colors.Location = new Point(74, 30);
            _colors.Name = "_colors";
            _colors.Size = new Size(121, 23);
            _colors.TabIndex = 1;
            _colors.SelectedIndexChanged += Colors_SelectedIndexChanged;
            // 
            // _outputColor
            // 
            _outputColor.AutoSize = true;
            _outputColor.Location = new Point(201, 33);
            _outputColor.Name = "_outputColor";
            _outputColor.Size = new Size(55, 15);
            _outputColor.TabIndex = 0;
            _outputColor.Text = "                ";
            // 
            // ColorSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 81);
            Controls.Add(_colors);
            Controls.Add(_outputColor);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ColorSelect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Color Select";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox _colors;
        private Label _outputColor;
    }
}