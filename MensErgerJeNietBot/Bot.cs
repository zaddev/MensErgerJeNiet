using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietBot
{
    public class Bot
    {
        private MensErgerJeNietLogic.Speler speler;
        private MensErgerJeNietLogic.MensErgerJeNiet spel;
        private Random rnd = new Random(); 

        /// <summary>
        /// configureren van het object.
        /// </summary>
        /// <param name="spel"></param>
        /// <param name="speler"></param>
        public Bot(MensErgerJeNietLogic.MensErgerJeNiet spel, MensErgerJeNietLogic.Speler speler)
        {
            this.spel = spel;
            this.speler = speler;
            // event oproepen als speler aan de beurt is 
            speler.AanDeBeurt += speler_AanDeBeurt;
        }

        /// <summary>
        /// dit event word getrigegrd wanneer de speler aan de beurt is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void speler_AanDeBeurt(object sender, EventArgs e)
        {
            if (speler.MagGooien)
            {
                do
                {
                    DoeWorp();
                    if (speler.Hand.Exists(pion => pion.IsVerplaatsbaar))
                    {
                        ActieMetRndPion();
                    }
                }
                while (this.spel.Dobbelsteen.Value == 6);   
            }       
        }

        /// <summary>
        /// speler doet een worp als de speler aan de beurt is 
        /// </summary>
        private void DoeWorp()
        {
            spel.DoeWorp();
        }

        private void ActieMetRndPion()
        {
           
            spel.ActieMetPion
                (
                    this.speler.Hand.Where(pion => pion.IsVerplaatsbaar) // selecteer pion die verplaatsbaar zijn
                    .OrderBy(pion => rnd.Next())    // sorteer de verplaatsbare pionnen willekeurig
                    .First()                        // Pak dan de eerste pion uit die reeks 
                );

        }

    }
}
