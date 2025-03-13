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

        Label lName = new();
        Label cBTitle = new();
        TextBox tName = new();
        CheckBox computerCheck = new();

        #endregion

        public string PlayerName => this.tName.Text;

        public bool IsBot => this.computerCheck.Checked;

        #region constructors
        /// <summary>
        /// create a player input controller
        /// </summary>
        /// <param name="number"></param>
        public NewPlayer(int number)
        {
            var color = (Color)number;
            this.Top = 40;
            this.Text = string.Format("Player {0}", color);
            this.Size = new System.Drawing.Size(200, 65);

            // lName is a label with the text
            this.lName.Text = "Name:";
            this.lName.Top = 15;
            this.lName.Left = 10;
            this.lName.Width = 70;
            this.Controls.Add(this.lName);

            // tName
            this.tName.Left = 80;
            this.tName.Top = 15;
            this.Controls.Add(this.tName);
            
            // checkbox
            this.cBTitle.Text = "Bot: ";
            this.cBTitle.Top = 40;
            this.cBTitle.Left = 10;
            this.cBTitle.Width = 70;
            this.Controls.Add(this.cBTitle);
            this.computerCheck.Top = 35;
            this.computerCheck.Left = 80;
            this.Controls.Add(this.computerCheck);

            this.tName.Text = "bootstrap";
        }

        #endregion
    }
}
