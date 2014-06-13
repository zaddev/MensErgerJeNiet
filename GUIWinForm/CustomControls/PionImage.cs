using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GUIWinForm
{
    public class PionImage : PictureBox
    {
        private MensErgerJeNietLogic.Pion lPion;

        #region constructors
        
        /// <summary>
        /// maak een pion en bepaal de kleur
        /// </summary>
        /// <param name="kleur">kleur die hij in het spel krijgt</param>
        public PionImage(Color kleur, MensErgerJeNietLogic.Pion logicPion)
        {
            this.lPion = logicPion;
            this.SetCollorImage(kleur);
            this.configPion();

            // Eventlisteners toevoegen
            logicPion.OnVerplaatst += logicPion_Verplaatst;
        }

        /// <summary>
        /// Verplaats de pion automatisch zodra het event "logicPion_Verplaatst" word aangeroepen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void logicPion_Verplaatst(object sender, EventArgs e)
        {
            BordPositions bordPositions = new BordPositions();
            Point nieuwelocatie = bordPositions.GetPosition(lPion.Locatie);

            // x bewerking en y bewerking
            nieuwelocatie.X *= 65 + 453;
            nieuwelocatie.Y *= -1* 58 + 26;
            this.Location = nieuwelocatie;
        }

        #endregion


        private void configPion()
        {
            this.Size = new System.Drawing.Size(42, 60);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TabIndex = 8;
            this.TabStop = false;
            this.BackColor = System.Drawing.Color.Transparent;

        }

        void SetCollorImage(Color kleur)
        {
            switch(kleur)
            {
                case Color.blauw:
                    this.Image = global::GUIWinForm.Properties.Resources.pion_blauw;
                    break;
                case Color.geel:
                    this.Image = global::GUIWinForm.Properties.Resources.pion_geel;
                    break;
                case Color.groen:
                    this.Image = global::GUIWinForm.Properties.Resources.pion_groen;
                    break;
                case Color.rood:
                    this.Image = global::GUIWinForm.Properties.Resources.pion_rood;
                    break;
            }
        }

        // methode om de gebruiker te laten zien dat de pion selecteerbaar is 

    }
}

/*
this.pictureBox2.Image = global::GUIWinForm.Properties.Resources.pion_rood;
            this.pictureBox2.Location = new System.Drawing.Point(679, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
*/