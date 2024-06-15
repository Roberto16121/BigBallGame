namespace BigBallGame
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
            components = new System.ComponentModel.Container();
            GameWindow = new Panel();
            StartDelay = new System.Windows.Forms.Timer(components);
            GameLoop = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // GameWindow
            // 
            GameWindow.BorderStyle = BorderStyle.FixedSingle;
            GameWindow.Location = new Point(12, 12);
            GameWindow.Name = "GameWindow";
            GameWindow.Size = new Size(760, 537);
            GameWindow.TabIndex = 0;
            // 
            // StartDelay
            // 
            StartDelay.Tick += StartDelay_Tick;
            // 
            // GameLoop
            // 
            GameLoop.Interval = 250;
            GameLoop.Tick += GameLoop_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(GameWindow);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel GameWindow;
        private System.Windows.Forms.Timer StartDelay;
        private System.Windows.Forms.Timer GameLoop;
    }
}
