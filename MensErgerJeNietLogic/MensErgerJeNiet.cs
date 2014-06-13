using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    public class MensErgerJeNiet
    {
        #region private fields
        Dobbelsteen dobbelsteen = new Dobbelsteen();
        List<Speler> spelers = new List<Speler>();
        Bord bord = new Bord();
        int actspeler;
        #endregion

        public event EventHandler NewActSpeler;

        public Dobbelsteen Dobbelsteen
        {
            get
            {
                return this.dobbelsteen;
            }
        }

        public List<Speler> Spelers
        {
            get
            {
                return this.spelers;
            }
            private set
            {
                this.spelers = value;
            }
        }

        internal Bord Bord
        {
            get
            {
                return this.bord;
            }
            set
            {
                this.bord = value;
            }
        }

        public Speler ActueeleSpeler
        {
            get
            {
                return this.spelers[actspeler];
            }
        }

        /// <summary>
        /// Gooit de dobbelsteen en het spel weet de mogelijkheden die nodig zijn
        /// </summary>
        /// <returns></returns>
        public int DoeWorp()
        {
            this.Dobbelsteen.Rol();

            //tijdelijk is er bij iedere rol ook een nieuwe speler aan de beurt
            this.actspeler = (this.actspeler + 1) % this.spelers.Count;
            //event wordt getriggerd er is een nieuwe speler aan de beurt
            if(NewActSpeler!=null)NewActSpeler(this.ActueeleSpeler, new EventArgs());

            return this.Dobbelsteen.Value;
        }

        /// <summary>
        /// maak een nieuwe speler dit is de enige plek waarvandaan je een nieuwe speler mag aanmaken
        /// </summary>
        /// <param name="spelersNaam"></param>
        /// <returns></returns>
        public Speler AddNewSpeler(string spelersNaam)
        {
            //check of er een collectie met speler is
            if (this.Spelers == null) this.Spelers = new List<Speler>();
            if (this.Spelers.Count >= 4) throw new System.InvalidOperationException("er zijn al 4 spelers");

            Speler nieuweSpeler = new Speler(spelersNaam, this.Spelers.Count);
            this.Spelers.Add(nieuweSpeler);

            return nieuweSpeler;
        }

        public void VerplaatsPion(int id)
        {
            throw new System.NotImplementedException();
        }

        public void VerplaatsPion(Pion pion)
        {
            throw new System.NotImplementedException();
        }

        public void PlaatsNieuwePion(string PionId)
        {
            throw new System.NotImplementedException();
        }

        public void PlaatsNieuwePion(Pion Pion)
        {
            throw new System.NotImplementedException();
        }

        void SlaPion(int locatie)
        {
            throw new System.NotImplementedException();
        }

        private void SlaPion(Pion pion)
        {
            throw new System.NotImplementedException();
        }
    }
}
