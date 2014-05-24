using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet
{
    public class Player
    {
        public event EventHandler OnSet;

        public string Name
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<MensErgerJeNiet.SpeelStuk.Pion> Pionen
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Kleur Kleur
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
