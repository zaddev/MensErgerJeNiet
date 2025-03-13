using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUIWinForm.CustomControls;
using DontGetAngryLogic;

namespace GUIWinForm.Screen
{
    public partial class StartGame : UserControl
    {
        List<NewPlayer> NewPlayers = new();
        List<DontGetAngryBot.Bot> bots = new();

        public StartGame()
        {
            InitializeComponent();

            setPlayers(2);
        }

        private void NumberOfPlayers_TextChanged(object sender, EventArgs e) => setPlayers(int.Parse(this.NumberOfPlayers.Text));

        private void setPlayers(int players)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            for (var i = 0; i < players; i++)
            {
                var t = new NewPlayer(i);
                t.Top += i * 70;
                this.splitContainer1.Panel2.Controls.Add(t);
            }
        }

        /// <summary>
        /// Catching the button click, it is checked whether you can start a game and if everything is correct you can continue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            var numberOfBots = 0;
            foreach (NewPlayer player in this.splitContainer1.Panel2.Controls)
            {
                if (string.IsNullOrWhiteSpace(player.PlayerName))
                {
                    MessageBox.Show("One or more fields are not filled in correctly");
                    return;
                }

                if (player.IsBot)
                {
                    numberOfBots += 1;
                }
            }

            if (numberOfBots == this.splitContainer1.Panel2.Controls.Count)
            {
                MessageBox.Show("There must be at least 1 player");
                return;
            }

            if (Global.Game == null) Global.Game = new DontGetAngryLogic.DontGetAngry();
            // logic for adding players
            foreach (NewPlayer player in this.splitContainer1.Panel2.Controls)
            {
                var logicPlayer = Global.Game.AddNewPlayer(player.PlayerName);
                if (player.IsBot)
                {
                    bots.Add(new DontGetAngryBot.Bot(Global.Game, logicPlayer));
                }
            }

            // Switch screens
            Global.MainScreen.SetGameScreen();

            // Start the game
            Global.Game.StartGame();
        }
    }
}
