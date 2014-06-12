using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIWinForm
{
    public static class Global
    {
        public static MensErgerJeNiet MainScreen = new MensErgerJeNiet();
        public static MensErgerJeNietLogic.MensErgerJeNiet Spel;// = new MensErgerJeNietLogic.MensErgerJeNiet();

        internal static void Start()
        {
            Global.MainScreen = new MensErgerJeNiet();
            Global.Spel = new MensErgerJeNietLogic.MensErgerJeNiet();
        }
    }
}
