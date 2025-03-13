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
        bool isVerplaatsbaar = false;
        #endregion

        #region eventhandlers
        /// <summary>
        /// de pion is verplaatst naar een andere locatie het geeft zijn eigen object mee
        /// </summary>
        public event EventHandler OnVerplaatst;

        /// <summary>
        /// er moet gecheckt worden of het verandert is in wel of niet verplaatsbaar
        /// </summary>
        public event EventHandler VerplaatsbaarChange;
        #endregion

        /// <summary>
        /// object mag alleen door het spel worden aangemaakt zodat het direct bij een pel behoort
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="kleur"></param>
        /// <param name="spel"></param>
        internal Pion(int nummer, int kleur, MensErgerJeNiet spel)
        {
            this.id = kleur * 4 + nummer;
            this.kleur = kleur;
            this.spel = spel;

            locatie = 56 + this.id;
        }

        public int ID => this.id;

        public int Kleur => this.kleur;

        public int Gelopen
        {
            get => this.gelopen;
            private set => this.gelopen = value;
        }

        public int LaatsteLocatie { get; private set; }
        public bool IsVerplaatsbaar { 
            get => this.isVerplaatsbaar;
            internal set
            {
                //kijken of de waarde wel verandert
                if(isVerplaatsbaar!=value)
                {
                    isVerplaatsbaar = value;
                    //kijk of er wel iets aan het event hangt
                    VerplaatsbaarChange?.Invoke(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// unieke locatie op het bord die de pion heeft
        /// </summary>
        public int Locatie
        {
            get => this.locatie;
            private set
            {
                this.locatie = value;
                //trigger event dat de pion op een nieuwe locatie staat
                OnVerplaatst?.Invoke(this, null);
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
                nieuweLocatie = (this.gelopen + this.kleur * 10)%40;
            }
            else if (this.gelopen > 39)
            {
                nieuweLocatie = this.spel.GeefVrijThuisHavenVlak(this.kleur);
            }
            //kijk of op nieuweLocatie Geen Pion aanwezig is
            this.CheckOmTeSlaan(nieuweLocatie);

            this.Locatie = nieuweLocatie;
        }

        /// <summary>
        /// kijkt of er nog pionnen geslagen moeten worden
        /// </summary>
        /// <param name="locatie"></param>
        private void CheckOmTeSlaan(int locatie)
        {
            Pion pionOmTeSlaan = spel.PionOpLocation(locatie);

            //als er een pion op locatie waar hij naar toe gaat een pion staat wordt er eerst een opdracht gegeven om deze er af te slaan
            if (pionOmTeSlaan != null)
                spel.SlaPion(pionOmTeSlaan);
        }

        /// <summary>
        /// verplaatt de pion naar hun eige start veld
        /// </summary>
        internal void VerplaatsNaarStartVeld()
        {
            this.gelopen = 0;//zorg ervoor dat een pion altijd 0 heeft gelopen dit moet omdat je kan hebt dat een pion al heeft gelopen en dit niet gewist heeft
            this.LaatsteLocatie = this.Locatie;

            //check of je een pion moet slaan
            this.CheckOmTeSlaan(10 * this.Kleur);

            this.Locatie = 10 * this.Kleur;
        }

        /// <summary>
        /// actie die Volgt als iemand geslagen wordt hij wordt weer helemaal terug geplaatst
        /// </summary>
        internal void VerplaatsNaarDeadposition()
        {
            this.LaatsteLocatie = this.Locatie;
            this.Locatie = spel.GeefVrijDeadPosition(this);
        }
    }
}
