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

        Label lNaam = new();
        Label cBTitel = new();
        TextBox tNaam = new();
        CheckBox computerCheck = new();

        #endregion

        public string SpelersNaam => this.tNaam.Text;

        public bool IsBot => this.computerCheck.Checked;

        #region constructors
        /// <summary>
        /// maak een spelersInvoer controller aan
        /// </summary>
        /// <param name="nummer"></param>
        public NewPlayer(int nummer)
        {
            var kleur = (Color)nummer;
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
