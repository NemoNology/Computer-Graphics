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
        outputMaimView = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)outputMaimView).BeginInit();
        SuspendLayout();
        // 
        // outputMaimView
        // 
        outputMaimView.Dock = DockStyle.Fill;
        outputMaimView.Location = new Point(0, 0);
        outputMaimView.Name = "outputMaimView";
        outputMaimView.Size = new Size(800, 450);
        outputMaimView.TabIndex = 0;
        outputMaimView.TabStop = false;
        outputMaimView.MouseDown += MainView_MouseDown;
        outputMaimView.MouseMove += MainView_MouseMove;
        outputMaimView.MouseUp += MainView_MouseUp;
        outputMaimView.Resize += MainView_Resized;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(outputMaimView);
        Name = "MainForm";
        Text = "Shape Clipping";
        ((System.ComponentModel.ISupportInitialize)outputMaimView).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private PictureBox outputMaimView;
}
