namespace GUIWinForm.Screen
{
    partial class Game
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.player1 = new System.Windows.Forms.Label();
            this.player2 = new System.Windows.Forms.Label();
            this.player3 = new System.Windows.Forms.Label();
            this.player4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BeurtSpeler = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DobbelsteenImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DobbelsteenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // player1
            // 
            this.player1.AutoSize = true;
            this.player1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(182)))), ((int)(((byte)(137)))));
            this.player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1.ForeColor = System.Drawing.Color.Yellow;
            this.player1.Location = new System.Drawing.Point(117, 199);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(0, 16);
            this.player1.TabIndex = 1;
            // 
            // player2
            // 
            this.player2.AutoSize = true;
            this.player2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(182)))), ((int)(((byte)(137)))));
            this.player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2.ForeColor = System.Drawing.Color.Green;
            this.player2.Location = new System.Drawing.Point(701, 199);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(0, 16);
            this.player2.TabIndex = 2;
            // 
            // player3
            // 
            this.player3.AutoSize = true;
            this.player3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(182)))), ((int)(((byte)(137)))));
            this.player3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player3.ForeColor = System.Drawing.Color.Blue;
            this.player3.Location = new System.Drawing.Point(117, 589);
            this.player3.Name = "player3";
            this.player3.Size = new System.Drawing.Size(0, 16);
            this.player3.TabIndex = 3;
            // 
            // player4
            // 
            this.player4.AutoSize = true;
            this.player4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(182)))), ((int)(((byte)(137)))));
            this.player4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player4.ForeColor = System.Drawing.Color.Red;
            this.player4.Location = new System.Drawing.Point(701, 589);
            this.player4.Name = "player4";
            this.player4.Size = new System.Drawing.Size(0, 16);
            this.player4.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(879, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Klik op de dobbelsteen";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(903, 539);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Eindig Beurt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BeurtSpeler
            // 
            this.BeurtSpeler.AutoSize = true;
            this.BeurtSpeler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeurtSpeler.Location = new System.Drawing.Point(888, 42);
            this.BeurtSpeler.Name = "BeurtSpeler";
            this.BeurtSpeler.Size = new System.Drawing.Size(172, 20);
            this.BeurtSpeler.TabIndex = 9;
            this.BeurtSpeler.Text = "Boot is aan de beurt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(957, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(945, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(886, 170);
            this.trackBar1.Maximum = 71;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(235, 45);
            this.trackBar1.TabIndex = 72;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUIWinForm.Properties.Resources.pion_groen;
            this.pictureBox2.Location = new System.Drawing.Point(453, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // DobbelsteenImage
            // 
            this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_1;
            this.DobbelsteenImage.Location = new System.Drawing.Point(903, 360);
            this.DobbelsteenImage.Name = "DobbelsteenImage";
            this.DobbelsteenImage.Size = new System.Drawing.Size(132, 132);
            this.DobbelsteenImage.TabIndex = 5;
            this.DobbelsteenImage.TabStop = false;
            this.DobbelsteenImage.Click += new System.EventHandler(this.DobbelsteenImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(182)))), ((int)(((byte)(137)))));
            this.pictureBox1.Image = global::GUIWinForm.Properties.Resources.EigenBord2;
            this.pictureBox1.Location = new System.Drawing.Point(52, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(828, 743);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BeurtSpeler);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DobbelsteenImage);
            this.Controls.Add(this.player4);
            this.Controls.Add(this.player3);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Game";
            this.Size = new System.Drawing.Size(1124, 863);
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DobbelsteenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label player1;
        private System.Windows.Forms.Label player2;
        private System.Windows.Forms.Label player3;
        private System.Windows.Forms.Label player4;
        private System.Windows.Forms.PictureBox DobbelsteenImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label BeurtSpeler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}
