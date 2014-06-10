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
    public partial class MensErgerJeNiet : Form
    {
        Screen.StartGame startScreen = new Screen.StartGame();
        Screen.Game gameScreen = new Screen.Game();

        Control currentScreen = new Control();

        public MensErgerJeNiet()
        {
            InitializeComponent();

            this.currentScreen = this.startScreen;
            this.Controls.Add(this.startScreen);
        }

        private void MensErgerJeNiet_Load(object sender, EventArgs e)
        {
        }


        internal void SetGameScreen()
        {
            this.Controls.Remove(this.currentScreen);
            this.currentScreen = this.gameScreen;

            this.Controls.Add(this.currentScreen);
        }

    }
}
