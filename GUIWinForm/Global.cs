using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIWinForm
{
    public static class Global
    {
        public static MensErgerJeNiet MainScreen = new();
        public static MensErgerJeNietLogic.MensErgerJeNiet Spel;

        internal static void Start()
        {
            MainScreen = new();
            Spel = new MensErgerJeNietLogic.MensErgerJeNiet();
        }
    }
}
