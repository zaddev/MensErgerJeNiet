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
        List<Label> LijstNaamLabels = new();
        public Game()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);   

            LijstNaamLabels = new List<Label>() { player1, player2, player3, player4 };       
        }

        void Spel_EindeSpel(object sender, EventArgs e)
        {
            var speler = sender as MensErgerJeNietLogic.Speler;

            if (speler != null)
            {
                var clickedAnswer = MessageBox.Show(speler.Naam + " heeft gewonnen \n Wilt u een nieuwe spel starten", "Gefeliciteerd", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == clickedAnswer)
                {
                    Global.MainScreen.StartNieuwSpel();
                }
                else 
                {
                    Global.MainScreen.Close();
                }
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Global.Spel.NewActSpeler += Spel_NewActSpeler;
            this.BeurtSpeler.Text = string.Format("{0} is aan de beurt", Global.Spel.Spelers[0].Naam);

            foreach(var speler in Global.Spel.Spelers)
            {
                LijstNaamLabels[speler.ID].Text = speler.Naam;
                
                foreach(var pion in speler.Hand)
                {
                    //pion.Locatie.
                    var pionImage = new PionImage((Color)pion.Kleur, pion);
                    this.pictureBox1.Controls.Add(pionImage);
                    VerplaatsPionNaar(pionImage, pion.Locatie);         
                }
            }

            Global.Spel.StartSpel();
            Global.Spel.MagGooien += Spel_MagGooien;
            Global.Spel.EindeSpel += Spel_EindeSpel;
            Global.Spel.Dobbelsteen.Gegooid += Dobbelsteen_Gegooid;
        }

        void Dobbelsteen_Gegooid(object sender, EventArgs e)
        {
            var gegooidewaard = (Global.Spel.Dobbelsteen.Value);

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

        /// <summary>
        /// maak de dobbelsteen weer beschikbaar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Spel_MagGooien(object sender, EventArgs e)
        {
            DobbelsteenImage.Click += this.DobbelsteenImage_Click;
            label1.Text = "Klik op de dobbelsteen";
        }

        void Spel_NewActSpeler(object sender, EventArgs e)
        {
            var actspeler = sender as MensErgerJeNietLogic.Speler;
            
            this.BeurtSpeler.Text = string.Format("{0} is aan de beurt", actspeler.Naam);
        }

        private void DobbelsteenImage_Click(object sender, EventArgs e)
        {
            //logica gooi dobbelsteen
            label1.Text = "Kies een pion";  
            Global.Spel.DoeWorp();
            
            
             
        }

       
        /// <summary>
        /// Verplaats de pion naar een nieuwe locatie.
        /// </summary>
        /// <param name="pion"></param>
        /// <param name="nieuweLocatie"></param>
        private void VerplaatsPionNaar(PionImage pion, int nieuweLocatie)
        {
            pion.Location = new Point(
                    (new BordPositions()).GetPosition(nieuweLocatie).X * 65 + 453, -1 * 
                    (new BordPositions()).GetPosition(nieuweLocatie).Y * 58 + 26);
        }
   
    }
}
