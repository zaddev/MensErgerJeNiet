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
            throw new System.NotImplementedException();
        }
    
        public int Value
        {
            get
            {
                return this.value;
            }
        }

        internal void Rol()
        {
            this.value = this.rnd.Next(1, vlakken + 1);
        }
    }
}
