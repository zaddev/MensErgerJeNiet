using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MensErgerJeNiet;

namespace MensErgerJeNietTests
{
    [TestClass]
    public class DobbelstenenTests
    {
        
        public DobbelstenenTests()
        {
            
        }

        
        /// <summary>
        /// in deze test worden de stenen heleboel keren gegooid met als doel om te kijken dat het dubbel 6 gooien ongeveer 1 op 36 met een niet te groote afwijking
        /// </summary>
        [TestMethod]
        public void TestEerlijkheidDobbelsten()
        {
            MensErgerJeNiet.SpeelStuk.SchudBeker<MensErgerJeNiet.SpeelStuk.DobbelSteen.Eerlijke.ZesVlaksDobbelSteen> beker = new MensErgerJeNiet.SpeelStuk.SchudBeker<MensErgerJeNiet.SpeelStuk.DobbelSteen.Eerlijke.ZesVlaksDobbelSteen>();

            beker.Dobbelstenen.Add(new MensErgerJeNiet.SpeelStuk.DobbelSteen.Eerlijke.ZesVlaksDobbelSteen());
            beker.Dobbelstenen.Add(new MensErgerJeNiet.SpeelStuk.DobbelSteen.Eerlijke.ZesVlaksDobbelSteen());

            beker.SchudDobbelstenen();
            int count = 0;
            for(int i=0;i<100000;i++)
            {
                beker.SchudDobbelstenen();

                if(beker.Dobbelstenen[0].TopWaarde.Ogen.Count==6&&beker.Dobbelstenen[1].TopWaarde.Ogen.Count==6)
                {
                    count++;
                }
            }

            /*
             * 100 000 / 36 = 2778
             * min waarde 2778 - 10% = 2500
             * max waarde 2778 + 10% = 3055
             * dit hou ik aan als maximaale waardes om eerlijkheid te garenderen
             */

            Assert.IsTrue(count > 2500 && count < 3055);
        }
    }
}
