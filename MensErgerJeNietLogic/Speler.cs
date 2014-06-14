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

        public event EventHandler AanDeBeurt;
        private MensErgerJeNiet spel;

        /// <summary>
        /// maakt een virtueele speler aan die pionnen heeft
        /// </summary>
        /// <param name="spelersNaam"></param>
        /// <param name="id"></param>
        /// <param name="spel"></param>
        internal Speler(string spelersNaam, int id, MensErgerJeNiet spel)
        {
            this.naam = spelersNaam;
            this.id = id;
            
            for(int i = 0; i<4;i++)
            {
                this.hand.Add(new Pion(i, id, spel));
            }

            this.MagGooien = false;
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

        bool isAanDeBeurt;
        internal bool IsAanDeBeurt
        {
            get
            {
                return this.isAanDeBeurt;
            }
            set
            {
                this.isAanDeBeurt = value;
                if(value==true)
                {
                    if (this.AanDeBeurt != null) this.AanDeBeurt(this, null);
                }
            }
        }

        //om bij te houden of iemand nog mag gooien
        public bool MagGooien { get; internal set; }
    }
}
