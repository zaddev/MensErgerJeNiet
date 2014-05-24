using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet
{
    public class PlaygroundPossition
    {
        public PlaygroundPossitionType PlaygroundPossitionType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// alleen maar ingevuld bij de speciale vakjes waar maar een speler mag komen
        /// </summary>
        public Player Eigenaar
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal MensErgerJeNiet.SpeelStuk.IPion Pion
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool HasPion
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
