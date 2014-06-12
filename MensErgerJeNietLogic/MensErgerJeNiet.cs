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
        #endregion

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

        public int DoeWorp()
        {
            this.Dobbelsteen.Rol();

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

        public void VerPlaatsPion(int id)
        {
            throw new System.NotImplementedException();
        }

        public void VerplaatsPion(Pion pion)
        {
            throw new System.NotImplementedException();
        }

        public void PlaatsNiewePion(string PionId)
        {
            throw new System.NotImplementedException();
        }

        public void PlaatNieuwePion(Pion Pion)
        {
            throw new System.NotImplementedException();
        }
    }
}
