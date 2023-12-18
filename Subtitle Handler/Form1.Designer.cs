namespace Subtitle_Handler
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
            closeAppBtn = new Button();
            minAppBtn = new Button();
            SuspendLayout();
            // 
            // closeAppBtn
            // 
            closeAppBtn.Location = new Point(762, 12);
            closeAppBtn.Name = "closeAppBtn";
            closeAppBtn.Size = new Size(26, 25);
            closeAppBtn.TabIndex = 0;
            closeAppBtn.Text = "X";
            closeAppBtn.UseVisualStyleBackColor = true;
            closeAppBtn.Click += closeAppBtn_Click;
            // 
            // minAppBtn
            // 
            minAppBtn.Location = new Point(730, 12);
            minAppBtn.Name = "minAppBtn";
            minAppBtn.Size = new Size(26, 25);
            minAppBtn.TabIndex = 1;
            minAppBtn.Text = "-";
            minAppBtn.UseVisualStyleBackColor = true;
            minAppBtn.Click += minAppBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(minAppBtn);
            Controls.Add(closeAppBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button closeAppBtn;
        private Button minAppBtn;
    }
}
