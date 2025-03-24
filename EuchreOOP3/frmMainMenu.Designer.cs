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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuckPlay
            // 
            this.btnQuckPlay.Location = new System.Drawing.Point(42, 259);
            this.btnQuckPlay.Name = "btnQuckPlay";
            this.btnQuckPlay.Size = new System.Drawing.Size(292, 55);
            this.btnQuckPlay.TabIndex = 1;
            this.btnQuckPlay.Text = "QUICK PLAY";
            this.btnQuckPlay.UseVisualStyleBackColor = true;
            this.btnQuckPlay.Click += new System.EventHandler(this.btnQuckPlay_Click);
            // 
            // btnCoUp
            // 
            this.btnCoUp.Location = new System.Drawing.Point(42, 334);
            this.btnCoUp.Name = "btnCoUp";
            this.btnCoUp.Size = new System.Drawing.Size(292, 55);
            this.btnCoUp.TabIndex = 1;
            this.btnCoUp.Text = "CO - UP ";
            this.btnCoUp.UseVisualStyleBackColor = true;
            this.btnCoUp.Click += new System.EventHandler(this.btnCoUp_Click);
            // 
            // btnOption
            // 
            this.btnOption.Location = new System.Drawing.Point(42, 406);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(292, 55);
            this.btnOption.TabIndex = 1;
            this.btnOption.Text = "OPTION";
            this.btnOption.UseVisualStyleBackColor = true;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(42, 486);
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
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUserName.Location = new System.Drawing.Point(90, 11);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(142, 32);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "ssdgfhgjfhkj";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(90, 46);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(142, 47);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BackgroundImage = global::EuchreOOP3.Properties.Resources.dark_Blue;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnQuckPlay);
            this.panel1.Controls.Add(this.btnCoUp);
            this.panel1.Controls.Add(this.btnOption);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(82, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 818);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::EuchreOOP3.Properties.Resources.euchrelogo;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(31, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(316, 213);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.BackgroundImage = global::EuchreOOP3.Properties.Resources.user;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::EuchreOOP3.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(3, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 82);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::EuchreOOP3.Properties.Resources.best_card_games_pc_1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(-1, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1301, 631);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.lblUserName);
            this.panel3.Controls.Add(this.btnLogOut);
            this.panel3.Location = new System.Drawing.Point(1047, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 93);
            this.panel3.TabIndex = 0;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::EuchreOOP3.Properties.Resources.dark_Blue;
            this.ClientSize = new System.Drawing.Size(1300, 810);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnQuckPlay;
        private System.Windows.Forms.Button btnCoUp;
        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
    }
}