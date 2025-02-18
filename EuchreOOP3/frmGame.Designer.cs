namespace EuchreOOP3
{
    partial class frmGame
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panTop = new System.Windows.Forms.Panel();
            this.panBottom = new System.Windows.Forms.Panel();
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.pbPlayedCards = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbTrick1 = new System.Windows.Forms.PictureBox();
            this.pbTrick2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayedCards)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrick1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrick2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(853, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(93, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Euchre";
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.Color.Gray;
            this.panTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panTop.Location = new System.Drawing.Point(534, 58);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(816, 255);
            this.panTop.TabIndex = 1;
            // 
            // panBottom
            // 
            this.panBottom.BackColor = System.Drawing.Color.Gray;
            this.panBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panBottom.Location = new System.Drawing.Point(519, 781);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(831, 248);
            this.panBottom.TabIndex = 2;
            this.panBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.panBottom_Paint);
            // 
            // pbDeck
            // 
            this.pbDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pbDeck.Location = new System.Drawing.Point(12, 12);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(221, 248);
            this.pbDeck.TabIndex = 3;
            this.pbDeck.TabStop = false;
            // 
            // pbPlayedCards
            // 
            this.pbPlayedCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pbPlayedCards.Location = new System.Drawing.Point(1671, 781);
            this.pbPlayedCards.Name = "pbPlayedCards";
            this.pbPlayedCards.Size = new System.Drawing.Size(221, 248);
            this.pbPlayedCards.TabIndex = 4;
            this.pbPlayedCards.TabStop = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Silver;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSettings.Location = new System.Drawing.Point(1761, 9);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 54);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pbTrick2);
            this.panel1.Controls.Add(this.pbTrick1);
            this.panel1.Location = new System.Drawing.Point(722, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 250);
            this.panel1.TabIndex = 6;
            // 
            // pbTrick1
            // 
            this.pbTrick1.BackColor = System.Drawing.Color.Red;
            this.pbTrick1.Location = new System.Drawing.Point(12, 3);
            this.pbTrick1.Name = "pbTrick1";
            this.pbTrick1.Size = new System.Drawing.Size(175, 244);
            this.pbTrick1.TabIndex = 0;
            this.pbTrick1.TabStop = false;
            // 
            // pbTrick2
            // 
            this.pbTrick2.BackColor = System.Drawing.Color.Red;
            this.pbTrick2.Location = new System.Drawing.Point(237, 3);
            this.pbTrick2.Name = "pbTrick2";
            this.pbTrick2.Size = new System.Drawing.Size(175, 244);
            this.pbTrick2.TabIndex = 1;
            this.pbTrick2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(239, 218);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 665);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(1395, 218);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 665);
            this.panel3.TabIndex = 3;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.pbPlayedCards);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.panBottom);
            this.Controls.Add(this.panTop);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGame";
            this.Load += new System.EventHandler(this.frmGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayedCards)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTrick1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrick2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.PictureBox pbPlayedCards;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbTrick1;
        private System.Windows.Forms.PictureBox pbTrick2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}