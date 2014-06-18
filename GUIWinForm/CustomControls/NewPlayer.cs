using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUIWinForm;

namespace GUIWinForm.CustomControls
{
    public class NewPlayer : GroupBox
    {
        #region private fields

        Label lNaam = new Label();
        Label cBTitel = new Label();
        TextBox tNaam = new TextBox();
        CheckBox computerCheck = new CheckBox();

        #endregion

        public string SpelersNaam
        {
            get
            {
                return this.tNaam.Text;
            }
        }

        public bool IsBot
        {
            get 
            { 
                return this.computerCheck.Checked; 
            }
        }


        #region constructors
        public NewPlayer(int nummer)
        {
            Color kleur = (Color)nummer;
            this.Top = 40;
            this.Text = string.Format("Speler {0}", kleur);
            this.Size = new System.Drawing.Size(200, 65);

            //lnaam is een label met de text
            this.lNaam.Text = "Naam:";
            this.lNaam.Top = 15;
            this.lNaam.Left = 10;
            this.lNaam.Width = 70;
            this.Controls.Add(this.lNaam);

            //tnaam
            this.tNaam.Left = 80;
            this.tNaam.Top = 15;
            this.Controls.Add(this.tNaam);
            
            //checkbox
            this.cBTitel.Text = "Bot: ";
            this.cBTitel.Top = 40;
            this.cBTitel.Left = 10;
            this.cBTitel.Width = 70;
            this.Controls.Add(this.cBTitel);
            this.computerCheck.Top = 35;
            this.computerCheck.Left = 80;
            this.Controls.Add(this.computerCheck);

            this.tNaam.Text = "bootstrap";
        }

        #endregion
    }
}
