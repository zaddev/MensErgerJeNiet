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

namespace GUIWinForm.Screen
{
    public partial class StartGame : UserControl
    {
        List<NewPlayer> NewPlayers = new List<NewPlayer>();

        public StartGame()
        {
            InitializeComponent();

            setPlayers(2);
        }

        private void AantalSpelers_TextChanged(object sender, EventArgs e)
        {
            setPlayers(int.Parse(this.AantalSpelers.Text));
        }

        private void setPlayers(int spelers)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            for(int i = 0; i<spelers;i++)
            {
                NewPlayer t = new NewPlayer(i);
                t.Top += i * 55;
                this.splitContainer1.Panel2.Controls.Add(t);
            }
        }
    }
}
