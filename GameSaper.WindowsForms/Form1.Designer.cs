namespace GameSaper.WindowsForms
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
            this.StartBtn = new System.Windows.Forms.Button();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.GamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.SystemColors.Control;
            this.StartBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StartBtn.Location = new System.Drawing.Point(142, 12);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(124, 31);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Начать новую игру";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // GamePanel
            // 
            this.GamePanel.AutoScroll = true;
            this.GamePanel.BackColor = System.Drawing.SystemColors.Control;
            this.GamePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GamePanel.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GamePanel.ForeColor = System.Drawing.Color.Black;
            this.GamePanel.Location = new System.Drawing.Point(12, 79);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(390, 360);
            this.GamePanel.TabIndex = 1;
            // 
            // CellBtn_Click
            // 
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(394, 441);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.StartBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1Load);
            this.GamePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button StartBtn;
        private Panel GamePanel;
    }
}