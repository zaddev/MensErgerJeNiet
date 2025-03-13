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
        List<Label> ListNameLabels = new();
        public Game()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);   

            ListNameLabels = new List<Label>() { player1, player2, player3, player4 };       
        }

        void Game_EndGame(object sender, EventArgs e)
        {
            var player = sender as MensErgerJeNietLogic.Player;

            if (player != null)
            {
                var clickedAnswer = MessageBox.Show(player.Name + " has won \n Do you want to start a new game", "Congratulations", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == clickedAnswer)
                {
                    Global.MainScreen.StartNewGame();
                }
                else 
                {
                    Global.MainScreen.Close();
                }
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Global.Game.NewActPlayer += Game_NewActPlayer;
            this.BeurtSpeler.Text = string.Format("{0} is up", Global.Game.Players[0].Name);

            foreach(var player in Global.Game.Players)
            {
                ListNameLabels[player.ID].Text = player.Name;
                
                foreach(var pawn in player.Hand)
                {
                    var pawnImage = new PawnImage((Color)pawn.Color, pawn);
                    this.pictureBox1.Controls.Add(pawnImage);
                    MovePawnTo(pawnImage, pawn.Location);         
                }
            }

            Global.Game.StartGame();
            Global.Game.CanRoll += Game_CanRoll;
            Global.Game.EndGame += Game_EndGame;
            Global.Game.Dice.Rolled += Dice_Rolled;
        }

        void Dice_Rolled(object sender, EventArgs e)
        {
            var rolledValue = (Global.Game.Dice.Value);

            switch (rolledValue)
            {
                case 1:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dice_1;
                    break;

                case 2:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dice_2;
                    break;

                case 3:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dice_3;
                    break;

                case 4:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dice_4;
                    break;

                case 5:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dice_5;
                    break;

                case 6:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dice_6;
                    break;

            }
            DobbelsteenImage.Click -= this.DobbelsteenImage_Click;
        }

        /// <summary>
        /// make the dice available again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Game_CanRoll(object sender, EventArgs e)
        {
            DobbelsteenImage.Click += this.DobbelsteenImage_Click;
            label1.Text = "Click on the dice";
        }

        void Game_NewActPlayer(object sender, EventArgs e)
        {
            var actPlayer = sender as MensErgerJeNietLogic.Player;
            
            this.BeurtSpeler.Text = string.Format("{0} is up", actPlayer.Name);
        }

        private void DobbelsteenImage_Click(object sender, EventArgs e)
        {
            // logic to roll the dice
            label1.Text = "Choose a pawn";  
            Global.Game.RollDice();
        }

        /// <summary>
        /// Move the pawn to a new location.
        /// </summary>
        /// <param name="pawn"></param>
        /// <param name="newLocation"></param>
        private void MovePawnTo(PawnImage pawn, int newLocation)
        {
            pawn.Location = new Point(
                    (new BoardPositions()).GetPosition(newLocation).X * 65 + 453, -1 * 
                    (new BoardPositions()).GetPosition(newLocation).Y * 58 + 26);
        }
    }
}
