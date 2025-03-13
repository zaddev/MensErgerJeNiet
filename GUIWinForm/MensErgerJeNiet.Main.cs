using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIWinForm
{
    public partial class DontGetAngry : Form
    {
        Screen.StartGame startScreen = new();
        Screen.Game gameScreen = new();

        Control currentScreen = new();

        public DontGetAngry()
        {
            InitializeComponent();

            this.currentScreen = this.startScreen;
            this.Controls.Add(this.startScreen);

        }

        private void DontGetAngry_Load(object sender, EventArgs e)
        {
        }


        internal void SetGameScreen()
        {
            this.Controls.Remove(this.currentScreen);
            this.currentScreen = this.gameScreen;

            this.Controls.Add(this.currentScreen);
        }


        internal void StartNewGame()
        {
            Global.Game = new DontGetAngryLogic.DontGetAngry();
            this.gameScreen = new();

            this.Controls.Remove(this.currentScreen);
            this.currentScreen = this.startScreen;

            this.Controls.Add(this.currentScreen);
        }
    }
}
