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
        MensErgerJeNiet spel;
        #endregion

        #region eventhandlers
        /// <summary>
        /// de pion is verplaatst naar een andere locatie het geeft zijn eigen object mee
        /// </summary>
        public event EventHandler OnVerplaatst;

        public event EventHandler OnVerplaatsbaar;
        #endregion

        internal Pion(int nummer, int kleur, MensErgerJeNiet spel)
        {
            this.id = kleur * 4 + nummer;
            this.kleur = kleur;
            this.spel = spel;

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
            private set
            {
                this.gelopen = value;
            }
        }

        public int LaatsteLocatie { get; private set; }
        public bool IsVerplaatsbaar { get; internal set; }

        /// <summary>
        /// unieke locatie op het bord die de pion heeft
        /// </summary>
        public int Locatie
        {
            get
            {
                return this.locatie;
            }
            private set
            {
                this.locatie = value;
                //trigger event dat de pion op een nieuwe locatie staat
                if (this.OnVerplaatst != null) this.OnVerplaatst(this, null);
            }
        }

        /// <summary>
        /// veplaats de pion de gewenste aantal stappen binnen het spel
        /// </summary>
        /// <param name="stappen"></param>
        internal void Verplaats(int stappen)
        {
            //men kan later terug vinden waar hij stond en kan die plek vrij maken
            this.LaatsteLocatie = this.Locatie;
            this.gelopen += stappen;
            int nieuweLocatie=0;
            if (this.gelopen < 40)
            {
                nieuweLocatie = this.gelopen - this.kleur * 10;
            }
            else if (this.gelopen > 39)
            {
                nieuweLocatie = this.spel.GeefVrijThuisHavenVlak(this.kleur);
            }
            //kijk of op nieuweLocatie Geen Pion aanwezig is
            Pion pionOmTeSlaan = spel.PionOpLocation(nieuweLocatie);

            //als er een pion op locatie waar hij naar toe gaat een pion staat wordt er eerst een opdracht gegeven om deze er af te slaan
            if (pionOmTeSlaan != null)
                spel.SlaPion(pionOmTeSlaan);

        }

        /// <summary>
        /// verplaatt de pion naar hun eige start veld
        /// </summary>
        internal void VerplaatsNaarStartVeld()
        {
            this.LaatsteLocatie = this.Locatie;
            this.Locatie = 10 * this.Kleur;
        }

        internal void VerplaatsNaarDeadposition()
        {
            spel.GeefVrijDeadPosition(this);
        }
    }
}
