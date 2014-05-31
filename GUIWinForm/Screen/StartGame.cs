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
        public StartGame()
        {
            InitializeComponent();

            this.splitContainer1.Panel2.Controls.Add(new NewPlayer());
        }
    }
}
