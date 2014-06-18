using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    public class Dobbelsteen
    {
        private Random rnd = new Random();
        const int vlakken = 6;
        private int value;

        public event EventHandler Gegooid;

        internal Dobbelsteen()
        {
        }
    
        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                if (Gegooid != null) Gegooid(this, new EventArgs());
            }
        }

        internal void Rol()
        {
            this.Value = this.rnd.Next(1, vlakken + 1);
        }
    }
}
