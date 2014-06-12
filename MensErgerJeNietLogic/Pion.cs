using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    public class Pion
    {
        #region private fields
        int id;
        int kleur;
        int gelopen;
        int locatie;
        #endregion

        internal Pion(int nummer, int kleur)
        {
            this.id = kleur * 4 + nummer;
            this.kleur = kleur;

            locatie = 56 + this.id;
        }

        public int ID
        {
            get
            {
                return this.id;
            }
        }

        public int Kleur
        {
            get
            {
                return this.kleur;
            }
        }

        public int Gelopen
        {
            get
            {
                return this.gelopen;
            }
            set
            {
                this.gelopen = value;
            }
        }

        public int Locatie
        {
            get
            {
                return this.locatie;
            }
            set
            {
                this.locatie = value;
            }
        }

        public void Verplaats(string stappen)
        {
            throw new System.NotImplementedException();
        }
    }
}
