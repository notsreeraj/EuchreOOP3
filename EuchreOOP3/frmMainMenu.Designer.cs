namespace EuchreOOP3
{
    partial class frmMainMenu
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnQuckPlay = new System.Windows.Forms.Button();
            this.btnCoUp = new System.Windows.Forms.Button();
            this.btnOption = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1138, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnQuckPlay
            // 
            this.btnQuckPlay.Location = new System.Drawing.Point(84, 76);
            this.btnQuckPlay.Name = "btnQuckPlay";
            this.btnQuckPlay.Size = new System.Drawing.Size(292, 55);
            this.btnQuckPlay.TabIndex = 1;
            this.btnQuckPlay.Text = "QUICK PLAY";
            this.btnQuckPlay.UseVisualStyleBackColor = true;
            // 
            // btnCoUp
            // 
            this.btnCoUp.Location = new System.Drawing.Point(84, 159);
            this.btnCoUp.Name = "btnCoUp";
            this.btnCoUp.Size = new System.Drawing.Size(292, 55);
            this.btnCoUp.TabIndex = 1;
            this.btnCoUp.Text = "CO - UP ";
            this.btnCoUp.UseVisualStyleBackColor = true;
            // 
            // btnOption
            // 
            this.btnOption.Location = new System.Drawing.Point(84, 241);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(292, 55);
            this.btnOption.TabIndex = 1;
            this.btnOption.Text = "OPTION";
            this.btnOption.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(84, 323);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(292, 55);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 808);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOption);
            this.Controls.Add(this.btnCoUp);
            this.Controls.Add(this.btnQuckPlay);
            this.Controls.Add(this.button1);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainMenu";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnQuckPlay;
        private System.Windows.Forms.Button btnCoUp;
        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.Button btnExit;
    }
}