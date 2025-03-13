using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    public class Dice
    {
        private readonly Random rnd = new();
        const int sides = 6;
        private int value;

        public event EventHandler Rolled;

        internal Dice()
        {
        }
    
        public int Value
        {
            get => this.value;
            set
            {
                this.value = value;
                Rolled?.Invoke(this, new EventArgs());
            }
        }

        internal void Roll() => this.Value = this.rnd.Next(1, sides + 1);
    }
}
