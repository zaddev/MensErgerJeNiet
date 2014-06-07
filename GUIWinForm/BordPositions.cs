using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIWinForm
{
    public class BordPositions
    {
        private List<posafwijking> lafwijkingen = new List<posafwijking>();


        public void SetAfwijkingen()
        {
            lafwijkingen = new List<posafwijking>
            {
                new posafwijking("y", -4),
                new posafwijking("x", 4),
                new posafwijking("y", -2),
                new posafwijking("x", -4),

            };
        }
    }

    class posafwijking
    {
        public string vorm;
        public int afwijking;

        public posafwijking(string vorm, int afwijking)
        {
            this.vorm = vorm;
            this.afwijking = afwijking;
        }
    }
}
