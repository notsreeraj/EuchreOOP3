namespace EuchreOOP3
{
    partial class frmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///   
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
            this.components = new System.ComponentModel.Container();
            this.panTop = new System.Windows.Forms.Panel();
            this.panBottom = new System.Windows.Forms.Panel();
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.pbPlayedCards = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panTrick = new System.Windows.Forms.Panel();
            this.panLeft = new System.Windows.Forms.Panel();
            this.panRight = new System.Windows.Forms.Panel();
            this.panDealer = new System.Windows.Forms.Panel();
            this.lblCurrentPlayer = new System.Windows.Forms.Label();
            this.pbPickedCard = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbDealerDeck = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayedCards)).BeginInit();
            this.panDealer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPickedCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealerDeck)).BeginInit();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.Color.Gray;
            this.panTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panTop.Location = new System.Drawing.Point(650, 141);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(539, 228);
            this.panTop.TabIndex = 1;
            this.panTop.Visible = false;
            // 
            // panBottom
            // 
            this.panBottom.BackColor = System.Drawing.Color.Gray;
            this.panBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panBottom.Location = new System.Drawing.Point(650, 711);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(539, 228);
            this.panBottom.TabIndex = 2;
            this.panBottom.Visible = false;
            this.panBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.panBottom_Paint);
            // 
            // pbDeck
            // 
            this.pbDeck.BackColor = System.Drawing.Color.Silver;
            this.pbDeck.Location = new System.Drawing.Point(12, 12);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(221, 321);
            this.pbDeck.TabIndex = 3;
            this.pbDeck.TabStop = false;
            this.pbDeck.Click += new System.EventHandler(this.pbDeck_Click);
            // 
            // pbPlayedCards
            // 
            this.pbPlayedCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pbPlayedCards.Location = new System.Drawing.Point(1671, 711);
            this.pbPlayedCards.Name = "pbPlayedCards";
            this.pbPlayedCards.Size = new System.Drawing.Size(221, 321);
            this.pbPlayedCards.TabIndex = 4;
            this.pbPlayedCards.TabStop = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Silver;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSettings.Location = new System.Drawing.Point(1817, 32);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 54);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panTrick
            // 
            this.panTrick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panTrick.Location = new System.Drawing.Point(650, 387);
            this.panTrick.Name = "panTrick";
            this.panTrick.Size = new System.Drawing.Size(539, 297);
            this.panTrick.TabIndex = 6;
            // 
            // panLeft
            // 
            this.panLeft.BackColor = System.Drawing.Color.Gray;
            this.panLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panLeft.Location = new System.Drawing.Point(302, 315);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(258, 462);
            this.panLeft.TabIndex = 2;
            this.panLeft.Visible = false;
            // 
            // panRight
            // 
            this.panRight.BackColor = System.Drawing.Color.Gray;
            this.panRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panRight.Location = new System.Drawing.Point(1283, 315);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(255, 458);
            this.panRight.TabIndex = 3;
            this.panRight.Visible = false;
            // 
            // panDealer
            // 
            this.panDealer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.panDealer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panDealer.Controls.Add(this.lblCurrentPlayer);
            this.panDealer.Controls.Add(this.pbPickedCard);
            this.panDealer.Controls.Add(this.label1);
            this.panDealer.Controls.Add(this.pbDealerDeck);
            this.panDealer.Location = new System.Drawing.Point(465, 189);
            this.panDealer.Name = "panDealer";
            this.panDealer.Size = new System.Drawing.Size(870, 693);
            this.panDealer.TabIndex = 7;
            // 
            // lblCurrentPlayer
            // 
            this.lblCurrentPlayer.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPlayer.Location = new System.Drawing.Point(374, 550);
            this.lblCurrentPlayer.Name = "lblCurrentPlayer";
            this.lblCurrentPlayer.Size = new System.Drawing.Size(100, 23);
            this.lblCurrentPlayer.TabIndex = 12;
            this.lblCurrentPlayer.Text = "PlayerName";
            this.lblCurrentPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCurrentPlayer.TextChanged += new System.EventHandler(this.lblCurrentPlayer_TextChanged);
            // 
            // pbPickedCard
            // 
            this.pbPickedCard.BackColor = System.Drawing.Color.Silver;
            this.pbPickedCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPickedCard.Location = new System.Drawing.Point(470, 150);
            this.pbPickedCard.Name = "pbPickedCard";
            this.pbPickedCard.Size = new System.Drawing.Size(191, 244);
            this.pbPickedCard.TabIndex = 11;
            this.pbPickedCard.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "The first one to get a Black Jack From the Deck will be the dealer";
            // 
            // pbDealerDeck
            // 
            this.pbDealerDeck.BackColor = System.Drawing.Color.Silver;
            this.pbDealerDeck.BackgroundImage = global::EuchreView.Properties.Resources.WG_BACK;
            this.pbDealerDeck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbDealerDeck.Location = new System.Drawing.Point(211, 150);
            this.pbDealerDeck.Name = "pbDealerDeck";
            this.pbDealerDeck.Size = new System.Drawing.Size(191, 244);
            this.pbDealerDeck.TabIndex = 8;
            this.pbDealerDeck.TabStop = false;
            this.pbDealerDeck.Click += new System.EventHandler(this.pbDealerDeck_Click);
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.panDealer);
            this.Controls.Add(this.panRight);
            this.Controls.Add(this.panLeft);
            this.Controls.Add(this.panTrick);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.pbPlayedCards);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.panBottom);
            this.Controls.Add(this.panTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGame";
            this.Load += new System.EventHandler(this.frmGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayedCards)).EndInit();
            this.panDealer.ResumeLayout(false);
            this.panDealer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPickedCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealerDeck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.PictureBox pbPlayedCards;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panTrick;
        private System.Windows.Forms.Panel panLeft;
        private System.Windows.Forms.Panel panRight;
        private System.Windows.Forms.Panel panDealer;
        private System.Windows.Forms.PictureBox pbDealerDeck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pbPickedCard;
        private System.Windows.Forms.Label lblCurrentPlayer;
    }
}