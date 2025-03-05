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
            this.btnQuckPlay = new System.Windows.Forms.Button();
            this.btnCoUp = new System.Windows.Forms.Button();
            this.btnOption = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuckPlay
            // 
            this.btnQuckPlay.Location = new System.Drawing.Point(159, 238);
            this.btnQuckPlay.Name = "btnQuckPlay";
            this.btnQuckPlay.Size = new System.Drawing.Size(292, 55);
            this.btnQuckPlay.TabIndex = 1;
            this.btnQuckPlay.Text = "QUICK PLAY";
            this.btnQuckPlay.UseVisualStyleBackColor = true;
            // 
            // btnCoUp
            // 
            this.btnCoUp.Location = new System.Drawing.Point(159, 321);
            this.btnCoUp.Name = "btnCoUp";
            this.btnCoUp.Size = new System.Drawing.Size(292, 55);
            this.btnCoUp.TabIndex = 1;
            this.btnCoUp.Text = "CO - UP ";
            this.btnCoUp.UseVisualStyleBackColor = true;
            // 
            // btnOption
            // 
            this.btnOption.Location = new System.Drawing.Point(159, 403);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(292, 55);
            this.btnOption.TabIndex = 1;
            this.btnOption.Text = "OPTION";
            this.btnOption.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(159, 485);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(292, 55);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserName.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(1382, 716);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(142, 32);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "ssdgfhgjfhkj";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(1410, 751);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(114, 39);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 808);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOption);
            this.Controls.Add(this.btnCoUp);
            this.Controls.Add(this.btnQuckPlay);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnQuckPlay;
        private System.Windows.Forms.Button btnCoUp;
        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnLogOut;
    }
}