using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    /// <summary>
    /// Het object dat brug is tussen alle logica hiermee wordt gecomuniceerd met de GUI en de achterkant van alle logica
    /// </summary>
    public class MensErgerJeNiet
    {
        #region private fields
        Dobbelsteen dobbelsteen = new Dobbelsteen();
        List<Speler> spelers = new List<Speler>();
        Bord bord;
        int actspeler;
        #endregion

        /// <summary>
        /// er is een nieuwe speler aan de beurt
        /// </summary>
        public event EventHandler NewActSpeler;

        /// <summary>
        /// er wordt een nieuwe leeg spel aangemaakt
        /// </summary>
        public MensErgerJeNiet()
        {
            this.bord = new Bord(this);
        }

        /// <summary>
        /// De dobbelsteen buiten de libary is hiervan alleen maar de value uit te lezen
        /// </summary>
        public Dobbelsteen Dobbelsteen
        {
            get
            {
                return this.dobbelsteen;
            }
        }

        /// <summary>
        /// Een lijst met alle Spelers die aan spel meedoen
        /// </summary>
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

        /// <summary>
        /// Het bord met alle velden
        /// </summary>
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

        /// <summary>
        /// speler die nu aan de beurt is
        /// </summary>
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
        /// <returns>het aantal ogen dat gegooid is</returns>
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
            if (this.Spelers == null) 
                this.Spelers = new List<Speler>();
            //check of er nie meer als 4 spelers zijn.
            if (this.Spelers.Count >= 4) 
                throw new System.InvalidOperationException("er zijn al 4 spelers");

            Speler nieuweSpeler = new Speler(spelersNaam, this.Spelers.Count, this);
            this.Spelers.Add(nieuweSpeler);

            return nieuweSpeler;
        }

        /// <summary>
        /// Deze Pion is gekozen om de actie uit te voeren die mogelijk is op dit moment
        /// </summary>
        /// <param name="pion"></param>
        public void ActieMetPion(Pion pion)
        {
            //kijk of er wel met de pion gespeeld mag worden
            if(pion.IsVerplaatsbaar )
            {
                //kijk of de pion al mee doet in het spel
                if(pion.Locatie>55)//56 is de eerste locatie dat een deadposition is
                {
                    this.PlaatsNieuwePion(pion);
                }
                else
                {
                    this.VerplaatsPion(pion);
                }
            }
        }

        /// <summary>
        /// verplaats een Pion en aantal stappen vooruit als er net gegooid is
        /// </summary>
        /// <param name="pion"></param>
        private void VerplaatsPion(Pion pion)
        {
            pion.Verplaats(this.dobbelsteen.Value);
        }

        /// <summary>
        /// verplaats een pion de deadpositions naar het begin veld
        /// </summary>
        /// <param name="pion"></param>
        private void PlaatsNieuwePion(Pion pion)
        {
            if(pion.IsVerplaatsbaar)
            {
                pion.VerplaatsNaarStartVeld();
            }
        }

        //verplaats de pion weer naar de deadpositions
        internal void SlaPion(Pion pion)
        {
            pion.VerplaatsNaarDeadposition();
        }

        /// <summary>
        /// kijkt voor de hoogste vrije positie in de thuishaven
        /// </summary>
        /// <param name="kleur"></param>
        /// <returns></returns>
        internal int GeefVrijThuisHavenVlak(int kleur)
        {
            // kijkt voor de hoogste vrije positie in de thuishaven
            // is 40 + 4 * kleur vanaf + 3
            for(int i = 40+4*kleur+3; i >= 40+4*kleur; i++)
            {
                if(this.bord.Fields[i] == VeldStatus.vrij)
                {
                    return i;
                }
            }
            return 0;
        }

        /// <summary>
        /// geeft een Pion die met behulp van het id wordt teruggevonden
        /// </summary>
        /// <param name="PionId"></param>
        /// <returns></returns>
        private Pion GetPionById(int PionId)
        {
            if (PionId > 15) throw new ArgumentOutOfRangeException("er zijn niet zoveel pionnen");
            return spelers.First(
                speler =>
                    speler.Hand.Exists
                    (pion =>
                        pion.ID == PionId
                        )
                        ).Hand.First(x =>
                            x.ID == PionId
                            );
        }

        /// <summary>
        /// geeft de pion terug op een bepaalde locatie als die aanwezig is.
        /// </summary>
        /// <param name="nieuweLocatie"></param>
        /// <returns>kan null returnnen als het niet aanwezig is</returns>
        internal Pion PionOpLocation(int nieuweLocatie)
        {
            //kijk eerst even snel of hij mischien vrij is
            if(bord.Fields[nieuweLocatie] == VeldStatus.vrij)
            {
                return null;
            }
            //hij komt hier hij dus er is een pion de plaats
            return this.spelers.First(speler => speler.Hand.Exists(pion => pion.Locatie == nieuweLocatie)).Hand.First(x => x.Locatie == nieuweLocatie);

        }

        /// <summary>
        /// geef de eerste positie terug die bechikbaar is voor deze pion om terug te gaan
        /// </summary>
        /// <param name="pion"></param>
        /// <returns></returns>
        internal int GeefVrijDeadPosition(Pion pion)
        {
            for (int i = 56 + 4 * pion.Kleur; i < 56 + 4 * pion.Kleur + 4; i++)
            {
                if(this.Bord.Fields[i] == VeldStatus.vrij)
                {
                    return i;
                }
            }
            throw new InvalidOperationException("er is geen vrij positie");
        }
    }
}
