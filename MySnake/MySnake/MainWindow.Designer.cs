namespace MySnake
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ScoreTitleLabel = new System.Windows.Forms.Label();
            this.ActualScoreLabel = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.GAmeOverLabel = new System.Windows.Forms.Label();
            this.SnakePictureBox = new System.Windows.Forms.PictureBox();
            this.SnakeBackgroundPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SnakePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnakeBackgroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ScoreTitleLabel
            // 
            this.ScoreTitleLabel.Font = new System.Drawing.Font("Stencil", 16.14953F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreTitleLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.ScoreTitleLabel.Location = new System.Drawing.Point(526, 12);
            this.ScoreTitleLabel.Name = "ScoreTitleLabel";
            this.ScoreTitleLabel.Size = new System.Drawing.Size(100, 45);
            this.ScoreTitleLabel.TabIndex = 1;
            this.ScoreTitleLabel.Text = "SCORE: ";
            this.ScoreTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActualScoreLabel
            // 
            this.ActualScoreLabel.Font = new System.Drawing.Font("Stencil", 16.14953F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActualScoreLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.ActualScoreLabel.Location = new System.Drawing.Point(656, 12);
            this.ActualScoreLabel.Name = "ActualScoreLabel";
            this.ActualScoreLabel.Size = new System.Drawing.Size(100, 45);
            this.ActualScoreLabel.TabIndex = 2;
            this.ActualScoreLabel.Text = "0";
            this.ActualScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            // 
            // GAmeOverLabel
            // 
            this.GAmeOverLabel.Font = new System.Drawing.Font("Stencil", 14.13084F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GAmeOverLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.GAmeOverLabel.Location = new System.Drawing.Point(140, 152);
            this.GAmeOverLabel.Name = "GAmeOverLabel";
            this.GAmeOverLabel.Size = new System.Drawing.Size(265, 163);
            this.GAmeOverLabel.TabIndex = 3;
            this.GAmeOverLabel.Text = "GAME OVER";
            this.GAmeOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GAmeOverLabel.Visible = false;
            // 
            // SnakePictureBox
            // 
            this.SnakePictureBox.Image = global::MySnake.Properties.Resources.snake;
            this.SnakePictureBox.Location = new System.Drawing.Point(531, 60);
            this.SnakePictureBox.Name = "SnakePictureBox";
            this.SnakePictureBox.Size = new System.Drawing.Size(238, 378);
            this.SnakePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SnakePictureBox.TabIndex = 4;
            this.SnakePictureBox.TabStop = false;
            // 
            // SnakeBackgroundPictureBox
            // 
            this.SnakeBackgroundPictureBox.BackColor = System.Drawing.Color.DarkGreen;
            this.SnakeBackgroundPictureBox.Location = new System.Drawing.Point(12, 12);
            this.SnakeBackgroundPictureBox.Name = "SnakeBackgroundPictureBox";
            this.SnakeBackgroundPictureBox.Size = new System.Drawing.Size(508, 426);
            this.SnakeBackgroundPictureBox.TabIndex = 0;
            this.SnakeBackgroundPictureBox.TabStop = false;
            this.SnakeBackgroundPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.SnakeBackgroundPictureBox_Paint);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(781, 450);
            this.Controls.Add(this.SnakePictureBox);
            this.Controls.Add(this.GAmeOverLabel);
            this.Controls.Add(this.ActualScoreLabel);
            this.Controls.Add(this.ScoreTitleLabel);
            this.Controls.Add(this.SnakeBackgroundPictureBox);
            this.MaximumSize = new System.Drawing.Size(797, 492);
            this.MinimumSize = new System.Drawing.Size(797, 492);
            this.Name = "MainWindow";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.SnakePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnakeBackgroundPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SnakeBackgroundPictureBox;
        private System.Windows.Forms.Label ScoreTitleLabel;
        private System.Windows.Forms.Label ActualScoreLabel;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label GAmeOverLabel;
        private System.Windows.Forms.PictureBox SnakePictureBox;
    }
}

