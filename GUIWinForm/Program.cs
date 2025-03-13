using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Global.MainScreen = new DontGetAngry();
            Global.Game = new DontGetAngryLogic.DontGetAngry();
            Application.Run(Global.MainScreen);
            //Global.Start();
        }
    }
}
