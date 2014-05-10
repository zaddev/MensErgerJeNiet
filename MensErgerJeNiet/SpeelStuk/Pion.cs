using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.SpeelStuk
{
    public class Pion : MensErgerJeNiet.SpeelStuk.IPion
    {
        public event EventHandler onmove;
    
        public Player Player
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public MensErgerJeNiet.Kleur Kleur
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
