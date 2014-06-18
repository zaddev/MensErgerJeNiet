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
        bool gameStarted = false;
        #endregion

        /// <summary>
        /// er is een nieuwe speler aan de beurt
        /// </summary>
        public event EventHandler NewActSpeler;

        public event EventHandler MagGooien;

        public event EventHandler EindeSpel;

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
                //game moet wel gestart zijn
                if (!this.gameStarted) throw new InvalidOperationException("het spel is nog niet gestart");
                return this.spelers[actspeler];
            }
        }

        /// <summary>
        /// Gooit de dobbelsteen en het spel weet de mogelijkheden die nodig zijn
        /// </summary>
        /// <returns>het aantal ogen dat gegooid is</returns>
        public int DoeWorp()
        {
            //game moet wel gestart zijn
            if (!this.gameStarted) throw new InvalidOperationException("het spel is nog niet gestart");
            if(!this.ActueeleSpeler.MagGooien)throw new InvalidOperationException("er mag niet gegooid worden op dit moment");
            this.Dobbelsteen.Rol();

            //speler mag in eerste instantie niet gooien omdat hij zoiezo niet meer mag of dat hij eerst nog iets met een pion moet doen
            this.ActueeleSpeler.MagGooien = false;


            if (this.ActueeleSpeler.Hand.Exists(pion => pion.Locatie == pion.Kleur *10) && this.ActueeleSpeler.Hand.Exists(pion => pion.Locatie > 55))
            {
                this.ActueeleSpeler.Hand.First(pion => pion.Locatie == pion.Kleur * 10).IsVerplaatsbaar = true;
            }
            //kijk welke pionnen geplaatst mogen worden
            //er is 6 gegooid en er zijn nog pionnen die op het bord gezet kunnen worden
            else if (this.ActueeleSpeler.Hand.Count(x => x.Locatie > 55) >=1 && Dobbelsteen.Value == 6)
            {
                //zet pionnen beschikbaar om te verzetten die op de deadpositions staan
                this.ActueeleSpeler.Hand.ForEach(x =>
                {
                    if (x.Locatie > 55)
                    {
                        x.IsVerplaatsbaar = true;
                    }
                });
            }
            //het is mogelijk dat de beurt nu al direct over is
            //gekozen voor groter als 39 omdat je dan ook de pionnen die al op de thuisposite staan meeneemt
            else if(this.ActueeleSpeler.Hand.Count(x=>x.Locatie>39) == 4)
            {
                this.NieweSpeler();
            }
            //is dit niet waar dan mogen de pionnen in het spel beschikbaar worden gesteld
            else
            {
                this.ActueeleSpeler.Hand.ForEach(x =>
                    {
                        if (x.Locatie <= 39)
                            x.IsVerplaatsbaar = true;
                    }
                    );
            }

            return this.Dobbelsteen.Value;
        }

        private void NieweSpeler()
        {
            this.ActueeleSpeler.Hand.ForEach(x => x.IsVerplaatsbaar = false);
            this.ActueeleSpeler.IsAanDeBeurt = false;

            this.actspeler = (this.actspeler + 1) % this.spelers.Count;
            //deze speler mag weer gooien
            this.ActueeleSpeler.MagGooien = true;
            if (MagGooien != null) MagGooien(this.Dobbelsteen, new EventArgs());
            if (NewActSpeler != null) NewActSpeler(this.ActueeleSpeler, new EventArgs());
            this.ActueeleSpeler.IsAanDeBeurt = true;
        }

        /// <summary>
        /// maak een nieuwe speler dit is de enige plek waarvandaan je een nieuwe speler mag aanmaken
        /// </summary>
        /// <param name="spelersNaam"></param>
        /// <returns></returns>
        public Speler AddNewSpeler(string spelersNaam)
        {
            //spel mag nog niet gestart zijn
            if (this.gameStarted) throw new InvalidOperationException("het spel is al gestart je kan geen spelers meer toevoegen");

            //check of er een collectie met speler is
            if (this.Spelers == null) 
                this.Spelers = new List<Speler>();
            //check of er nie meer als 4 spelers zijn.
            if (this.Spelers.Count >= 4) 
                throw new System.InvalidOperationException("er zijn al 4 spelers");

            Speler nieuweSpeler = new Speler(spelersNaam, this.Spelers.Count, this);
            this.Spelers.Add(nieuweSpeler);

            this.bord.p(nieuweSpeler);

            return nieuweSpeler;
        }

        /// <summary>
        /// Deze Pion is gekozen om de actie uit te voeren die mogelijk is op dit moment
        /// </summary>
        /// <param name="pion"></param>
        public void ActieMetPion(Pion pion)
        {
            //game moet al wel gestart zijn
            if (!this.gameStarted) throw new InvalidOperationException("het spel is nog niet gestart");

            //kijk of er wel met de pion gespeeld mag worden
            if(pion.IsVerplaatsbaar )
            {
                if(pion.Locatie>55)//56 is de eerste locatie dat een deadposition is
                {
                    this.PlaatsNieuwePion(pion);
                }
                else
                {
                    this.VerplaatsPion(pion);
                }

                //check of speler gewonnen heeft
                this.CheckVoorWinst(this.ActueeleSpeler);

                //kijk of de persoon nog een keer mag gooien
                this.ActueeleSpeler.MagGooien = this.Dobbelsteen.Value == 6;
                //als de persoon niet meer mag gooien is de volgende speler aan de beurt
                if(!this.ActueeleSpeler.MagGooien)
                {
                    this.NieweSpeler();
                }
                else
                {
                    if (MagGooien != null) MagGooien(this.Dobbelsteen, new EventArgs());
                }

                //zorg dat de huidige speler niks meer met zijn pion mag doen
                this.ActueeleSpeler.Hand.ForEach(x => x.IsVerplaatsbaar = false);
            }
        }

        private void CheckVoorWinst(Speler speler)
        {
            if(speler.Hand.Count(x=>x.Locatie > 39 && x.Locatie < 56) == 4)
            {
                //alle pionnen staan thuis de speler heeft gewonnen
                if (this.EindeSpel != null) 
                    EindeSpel(speler, new EventArgs());

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
            for(int i = 40+4*kleur+3; i >= 40+4*kleur; i--)
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

        /// <summary>
        /// Nadit comando is het spel oficieel begonnen en mogen er bijvoorbeeld geen spelers toegevoegd worden. maar juist wel dingen als gooien
        /// </summary>
        public void StartSpel()
        {
            this.gameStarted = true;

            //eerste speler is aan de beurt
            this.actspeler = 0;
            this.ActueeleSpeler.MagGooien = true;
            this.ActueeleSpeler.IsAanDeBeurt = true;
            if (NewActSpeler != null) NewActSpeler(this.ActueeleSpeler, new EventArgs());
        }
    }
}
