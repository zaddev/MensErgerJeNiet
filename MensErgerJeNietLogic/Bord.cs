using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    public class Bord
    {
        private List<VeldStatus> fields = new();
        /// <summahy>
        /// het bord heeft als belangerijkste funtionaliteit een collectie van speelvelden opgeslagen als Enum veldstatus
        /// </summary>
        internal Bord(MensErgerJeNiet spel)
        {
            //vul alle velden
            for (var i = 0; i < 72; i++)
            {
                //in eerste instatie zijn ze leeg omdat er op dit moment nog geen spelers zijn
                this.fields.Add(VeldStatus.vrij);
            }
        }

        public List<VeldStatus> Fields => this.fields;

        /// <summary>
        /// voegt de pionnen toe zodat het bord kan opletten of er een pion zich verplaatst
        /// </summary>
        /// <param name="speler">speler heeft een hand met 4 pionnen</param>
        internal void p(Speler speler)
        {
            speler.Hand.ForEach(pion =>
            {
                pion.OnVerplaatst += pion_Verplaatst;
                Fields[pion.Locatie] = (VeldStatus)pion.Kleur;
            }
            );
        }

        /// <summary>
        /// er is een pion verplaats op het bord word er geregeld dat het bord weer de juiste status heeft op de vlakken
        /// </summary>
        /// <param name="sender">is de pion die verplaatst is en het event getriggerd heeft</param>
        /// <param name="e"></param>
        void pion_Verplaatst(object sender, EventArgs e)
        {
            var pion = sender as Pion;
            //oude positie is weer vrij
            this.ChangeStatus(pion.LaatsteLocatie, VeldStatus.vrij);
            //verander nu de nieuwe locatie van de pion naar bezet met de kleur van de pion
            this.ChangeStatus(pion.Locatie, (VeldStatus)pion.Kleur);

        }

        /// <summary>
        /// geef de opdracht om een van de velden 0 tm 71 te wijzigen
        /// </summary>
        /// <param name="positie"></param>
        /// <param name="status"></param>
        internal void ChangeStatus(int positie, VeldStatus status)
        {
            this.fields[positie] = status;
        }
    }
}
