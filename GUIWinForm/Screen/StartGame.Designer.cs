namespace GUIWinForm.Screen
{
    partial class StartGame
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
            this.labelAantalSpelers = new System.Windows.Forms.Label();
            this.AantalSpelers = new System.Windows.Forms.ComboBox();
            this.ButtonStartGame = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAantalSpelers
            // 
            this.labelAantalSpelers.AutoSize = true;
            this.labelAantalSpelers.Location = new System.Drawing.Point(41, 49);
            this.labelAantalSpelers.Name = "labelAantalSpelers";
            this.labelAantalSpelers.Size = new System.Drawing.Size(73, 13);
            this.labelAantalSpelers.TabIndex = 2;
            this.labelAantalSpelers.Text = "Aantal spelers";
            // 
            // AantalSpelers
            // 
            this.AantalSpelers.FormattingEnabled = true;
            this.AantalSpelers.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.AantalSpelers.Location = new System.Drawing.Point(136, 46);
            this.AantalSpelers.Name = "AantalSpelers";
            this.AantalSpelers.Size = new System.Drawing.Size(65, 21);
            this.AantalSpelers.TabIndex = 3;
            this.AantalSpelers.Text = "2";
            this.AantalSpelers.TextChanged += new System.EventHandler(this.AantalSpelers_TextChanged);
            // 
            // ButtonStartGame
            // 
            this.ButtonStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonStartGame.Location = new System.Drawing.Point(44, 428);
            this.ButtonStartGame.Name = "ButtonStartGame";
            this.ButtonStartGame.Size = new System.Drawing.Size(211, 73);
            this.ButtonStartGame.TabIndex = 4;
            this.ButtonStartGame.Text = "Start Spel";
            this.ButtonStartGame.UseVisualStyleBackColor = true;
            this.ButtonStartGame.Click += new System.EventHandler(this.ButtonStartGame_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ButtonStartGame);
            this.splitContainer1.Panel1.Controls.Add(this.AantalSpelers);
            this.splitContainer1.Panel1.Controls.Add(this.labelAantalSpelers);
            this.splitContainer1.Size = new System.Drawing.Size(1355, 688);
            this.splitContainer1.SplitterDistance = 409;
            this.splitContainer1.TabIndex = 0;
            // 
            // StartGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "StartGame";
            this.Size = new System.Drawing.Size(1355, 688);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAantalSpelers;
        private System.Windows.Forms.ComboBox AantalSpelers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.Button ButtonStartGame;

    }
}
