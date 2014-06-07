using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIWinForm
{
    public class PionImage : PictureBox
    {

        #region constructors
        
        /// <summary>
        /// maak een pion en bepaal de kleur
        /// </summary>
        /// <param name="kleur">kleur die hij in het spel krijgt</param>
        public PionImage(Color kleur)
        {

            this.SetCollorImage(kleur);
            this.configPion();
        }

        #endregion


        private void configPion()
        {
            this.Size = new System.Drawing.Size(42, 65);
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