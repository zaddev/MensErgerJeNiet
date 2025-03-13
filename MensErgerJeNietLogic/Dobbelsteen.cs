using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    public class Dobbelsteen
    {
        private readonly Random rnd = new();
        const int vlakken = 6;
        private int value;

        public event EventHandler Gegooid;

        internal Dobbelsteen()
        {
        }
    
        public int Value
        {
            get => this.value;
            set
            {
                this.value = value;
                Gegooid?.Invoke(this, new EventArgs());
            }
        }

        internal void Rol() => this.Value = this.rnd.Next(1, vlakken + 1);
    }
}
