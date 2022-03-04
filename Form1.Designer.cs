namespace SnakeBiteGame
{
    partial class SnakeGame
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
            this.components = new System.ComponentModel.Container();
            this.StartButton = new System.Windows.Forms.Button();
            this.SnapButton = new System.Windows.Forms.Button();
            this.PictureGameCanvas = new System.Windows.Forms.PictureBox();
            this.GameScore = new System.Windows.Forms.Label();
            this.GamesHighScore = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureGameCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.RosyBrown;
            this.StartButton.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(660, 45);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(107, 36);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartTheGame);
            // 
            // SnapButton
            // 
            this.SnapButton.BackColor = System.Drawing.Color.RosyBrown;
            this.SnapButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SnapButton.Location = new System.Drawing.Point(660, 110);
            this.SnapButton.Name = "SnapButton";
            this.SnapButton.Size = new System.Drawing.Size(107, 35);
            this.SnapButton.TabIndex = 1;
            this.SnapButton.Text = "Snap";
            this.SnapButton.UseVisualStyleBackColor = false;
            this.SnapButton.Click += new System.EventHandler(this.Takesnapshot);
            // 
            // PictureGameCanvas
            // 
            this.PictureGameCanvas.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PictureGameCanvas.Location = new System.Drawing.Point(54, 12);
            this.PictureGameCanvas.Name = "PictureGameCanvas";
            this.PictureGameCanvas.Size = new System.Drawing.Size(500, 450);
            this.PictureGameCanvas.TabIndex = 2;
            this.PictureGameCanvas.TabStop = false;
            this.PictureGameCanvas.Click += new System.EventHandler(this.PictureGameCanvas_Click);
            this.PictureGameCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGrphics);
            // 
            // GameScore
            // 
            this.GameScore.AutoSize = true;
            this.GameScore.BackColor = System.Drawing.Color.RosyBrown;
            this.GameScore.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameScore.Location = new System.Drawing.Point(693, 187);
            this.GameScore.Name = "GameScore";
            this.GameScore.Size = new System.Drawing.Size(64, 17);
            this.GameScore.TabIndex = 3;
            this.GameScore.Text = "Score 0";
            this.GameScore.Click += new System.EventHandler(this.GameScoreLabel_Click);
            // 
            // GamesHighScore
            // 
            this.GamesHighScore.AutoSize = true;
            this.GamesHighScore.BackColor = System.Drawing.Color.RosyBrown;
            this.GamesHighScore.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GamesHighScore.Location = new System.Drawing.Point(678, 235);
            this.GamesHighScore.Name = "GamesHighScore";
            this.GamesHighScore.Size = new System.Drawing.Size(88, 17);
            this.GamesHighScore.TabIndex = 4;
            this.GamesHighScore.Text = "High Score";
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 40;
            this.GameTimer.Tick += new System.EventHandler(this.Gametimerevent);
            // 
            // SnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 638);
            this.Controls.Add(this.GamesHighScore);
            this.Controls.Add(this.GameScore);
            this.Controls.Add(this.PictureGameCanvas);
            this.Controls.Add(this.SnapButton);
            this.Controls.Add(this.StartButton);
            this.Name = "SnakeGame";
            this.Text = "Snake Game Board";
            this.Click += new System.EventHandler(this.StartTheGame);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUP);
            ((System.ComponentModel.ISupportInitialize)(this.PictureGameCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button SnapButton;
        private System.Windows.Forms.PictureBox PictureGameCanvas;
        private System.Windows.Forms.Label GameScore;
        private System.Windows.Forms.Label GamesHighScore;
        private System.Windows.Forms.Timer GameTimer;
    }
}

