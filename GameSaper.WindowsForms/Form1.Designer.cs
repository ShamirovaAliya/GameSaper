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
            this.WidthTB = new System.Windows.Forms.TextBox();
            this.HeightTB = new System.Windows.Forms.TextBox();
            this.WidthLbl = new System.Windows.Forms.Label();
            this.HeigthLbl = new System.Windows.Forms.Label();
            this.ErrorLbl = new System.Windows.Forms.Label();
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
            this.GamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GamePanel.AutoScroll = true;
            this.GamePanel.BackColor = System.Drawing.SystemColors.Control;
            this.GamePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GamePanel.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GamePanel.ForeColor = System.Drawing.Color.Black;
            this.GamePanel.Location = new System.Drawing.Point(0, 141);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(383, 380);
            this.GamePanel.TabIndex = 1;
            // 
            // WidthTB
            // 
            this.WidthTB.Location = new System.Drawing.Point(73, 62);
            this.WidthTB.Name = "WidthTB";
            this.WidthTB.Size = new System.Drawing.Size(100, 23);
            this.WidthTB.TabIndex = 2;
            // 
            // HeightTB
            // 
            this.HeightTB.Location = new System.Drawing.Point(263, 62);
            this.HeightTB.Name = "HeightTB";
            this.HeightTB.Size = new System.Drawing.Size(100, 23);
            this.HeightTB.TabIndex = 3;
            // 
            // WidthLbl
            // 
            this.WidthLbl.AutoSize = true;
            this.WidthLbl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.WidthLbl.ForeColor = System.Drawing.Color.Black;
            this.WidthLbl.Location = new System.Drawing.Point(12, 65);
            this.WidthLbl.Name = "WidthLbl";
            this.WidthLbl.Size = new System.Drawing.Size(55, 15);
            this.WidthLbl.TabIndex = 4;
            this.WidthLbl.Text = "Ширина:";
            // 
            // HeigthLbl
            // 
            this.HeigthLbl.AutoSize = true;
            this.HeigthLbl.ForeColor = System.Drawing.Color.Black;
            this.HeigthLbl.Location = new System.Drawing.Point(212, 66);
            this.HeigthLbl.Name = "HeigthLbl";
            this.HeigthLbl.Size = new System.Drawing.Size(45, 15);
            this.HeigthLbl.TabIndex = 5;
            this.HeigthLbl.Text = "Длина:";
            // 
            // ErrorLbl
            // 
            this.ErrorLbl.AutoSize = true;
            this.ErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.ErrorLbl.Location = new System.Drawing.Point(12, 103);
            this.ErrorLbl.Name = "ErrorLbl";
            this.ErrorLbl.Size = new System.Drawing.Size(0, 15);
            this.ErrorLbl.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(374, 529);
            this.Controls.Add(this.ErrorLbl);
            this.Controls.Add(this.HeigthLbl);
            this.Controls.Add(this.WidthLbl);
            this.Controls.Add(this.HeightTB);
            this.Controls.Add(this.WidthTB);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.StartBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartBtn;
        private Panel GamePanel;
        private TextBox WidthTB;
        private TextBox HeightTB;
        private Label WidthLbl;
        private Label HeigthLbl;
        private Label ErrorLbl;
    }
}