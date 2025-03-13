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
using MensErgerJeNietLogic;

namespace GUIWinForm.Screen
{
    public partial class StartGame : UserControl
    {
        List<NewPlayer> NewPlayers = new();
        List<MensErgerJeNietBot.Bot> bots = new();

        public StartGame()
        {
            InitializeComponent();

            setPlayers(2);
        }

        private void AantalSpelers_TextChanged(object sender, EventArgs e) => setPlayers(int.Parse(this.AantalSpelers.Text));

        private void setPlayers(int spelers)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            for (var i = 0; i < spelers; i++)
            {
                var t = new NewPlayer(i);
                t.Top += i * 70;
                this.splitContainer1.Panel2.Controls.Add(t);
            }
        }

        /// <summary>
        /// het af vangen van de button click er wordt gekeken of je een game mag starten en als alles klopt mag je verder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            var aantalBots = 0;
            foreach (NewPlayer speler in this.splitContainer1.Panel2.Controls)
            {
                if (string.IsNullOrWhiteSpace(speler.SpelersNaam))
                {
                    MessageBox.Show("Één of meerdere velden zijn niet goed ingevuld");
                    return;
                }

                if (speler.IsBot)
                {
                    aantalBots += 1;
                }
            }

            if (aantalBots == this.splitContainer1.Panel2.Controls.Count)
            {
                MessageBox.Show("Er moet minimaal 1 speler zijn");
                return;
            }

            if (Global.Spel == null) Global.Spel = new MensErgerJeNietLogic.MensErgerJeNiet();
            //logica voor toevoegen spelers
            //TODO: Spelers werkelijk toevoegen
            foreach (NewPlayer speler in this.splitContainer1.Panel2.Controls)
            {
                var logicSpeler = Global.Spel.AddNewSpeler(speler.SpelersNaam);
                if (speler.IsBot)
                {
                    bots.Add(new MensErgerJeNietBot.Bot(Global.Spel, logicSpeler));
                }
            }

            //Wisselen van scherm
            Global.MainScreen.SetGameScreen();

            //Start het spel
            Global.Spel.StartSpel();
        }
    }
}
