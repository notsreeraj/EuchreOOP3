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
            this.btnQuickPlay = new System.Windows.Forms.Button();
            this.btnCoUp = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnExit3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnQuickPlay
            // 
            this.btnQuickPlay.BackgroundImage = global::EuchreOOP3.Properties.Resources.Switch_2;
            this.btnQuickPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickPlay.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuickPlay.Location = new System.Drawing.Point(136, 217);
            this.btnQuickPlay.Name = "btnQuickPlay";
            this.btnQuickPlay.Size = new System.Drawing.Size(308, 61);
            this.btnQuickPlay.TabIndex = 0;
            this.btnQuickPlay.Text = "QUICK PLAY";
            this.btnQuickPlay.UseVisualStyleBackColor = true;
            // 
            // btnCoUp
            // 
            this.btnCoUp.BackgroundImage = global::EuchreOOP3.Properties.Resources.Switch_2;
            this.btnCoUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoUp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCoUp.Location = new System.Drawing.Point(136, 293);
            this.btnCoUp.Name = "btnCoUp";
            this.btnCoUp.Size = new System.Drawing.Size(308, 61);
            this.btnCoUp.TabIndex = 0;
            this.btnCoUp.Text = "CO-UP";
            this.btnCoUp.UseVisualStyleBackColor = true;
            // 
            // btnOptions
            // 
            this.btnOptions.BackgroundImage = global::EuchreOOP3.Properties.Resources.Switch_2;
            this.btnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOptions.Location = new System.Drawing.Point(136, 372);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(308, 61);
            this.btnOptions.TabIndex = 0;
            this.btnOptions.Text = "OPTIONS";
            this.btnOptions.UseVisualStyleBackColor = true;
            // 
            // btnExit3
            // 
            this.btnExit3.BackgroundImage = global::EuchreOOP3.Properties.Resources.Switch_2;
            this.btnExit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit3.Location = new System.Drawing.Point(136, 454);
            this.btnExit3.Name = "btnExit3";
            this.btnExit3.Size = new System.Drawing.Size(308, 61);
            this.btnExit3.TabIndex = 0;
            this.btnExit3.Text = "EXIT";
            this.btnExit3.UseVisualStyleBackColor = true;
            this.btnExit3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(136, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 73);
            this.label1.TabIndex = 1;
            this.label1.Text = "EUCHRE";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EuchreOOP3.Properties.Resources.opening2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1120, 718);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit3);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnCoUp);
            this.Controls.Add(this.btnQuickPlay);
            this.Name = "frmMainMenu";
            this.Text = "frmMainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuickPlay;
        private System.Windows.Forms.Button btnCoUp;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnExit3;
        private System.Windows.Forms.Label label1;
    }
}