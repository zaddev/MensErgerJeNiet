using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIWinForm.Screen
{
    public partial class Game : UserControl
    {
        public Game()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.pictureBox2.Parent = this.pictureBox1;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;

            PionImage pa1 = new PionImage(Color.rood);
            //pa1.Parent = this.pictureBox1;//dit is niet nodig om dat je hem aan de controlls van de picturebox
            //let op de verhoudingen hierdoor zijn afhankelijk van de image

            this.pictureBox1.Controls.Add(pa1);

        }

        private void Game_VisibleChanged(object sender, EventArgs e)
        {
            //spel benaderen voor namen

            //tijdelijke namen
            string[] namen = new string[]{ "jantje", "gerrit", "henk", "pietje" };

            this.player1.Text = namen[0];
            this.player2.Text = namen[1];
            this.player3.Text = namen[2];
            this.player4.Text = namen[3];
        }

        private void Game_Load(object sender, EventArgs e)
        {
            string[] namen = new string[] { "jantje", "gerrit", "henk", "pietje" };

            this.player1.Text = namen[0];
            this.player2.Text = namen[1];
            this.player3.Text = namen[2];
            this.player4.Text = namen[3];
        }

        private void DobbelsteenImage_Click(object sender, EventArgs e)
        {
            //logica gooi dobbelsteen
            int gegooidewaard = (new Random()).Next(1, 7);

            switch (gegooidewaard)
            {
                case 1:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_1;
                    break;

                case 2:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_2;
                    break;

                case 3:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_3;
                    break;

                case 4:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_4;
                    break;

                case 5:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_5;
                    break;

                case 6:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_6;
                    break;

            }

            DobbelsteenImage.Click -= this.DobbelsteenImage_Click;              
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DobbelsteenImage.Click += this.DobbelsteenImage_Click;
        }

   
    }
}
