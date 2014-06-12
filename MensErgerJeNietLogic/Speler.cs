using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    public class Speler
    {
        #region private fields
        string naam;
        int id;
        List<Pion> hand = new List<Pion>();
        #endregion

        internal Speler(string spelersNaam, int id)
        {
            this.naam = spelersNaam;
            this.id = id;
            
            for(int i = 0; i<4;i++)
            {
                this.hand.Add(new Pion());
            }
        }
    
        public List<Pion> Hand
        {
            get
            {
                return this.hand;
            }
        }

        public string Naam
        {
            get
            {
                return this.naam;
            }
        }

        /// <summary>
        /// gelijk aan kleur
        /// </summary>
        public int ID
        {
            get
            {
                return this.id;
            }
        }
    }
}
