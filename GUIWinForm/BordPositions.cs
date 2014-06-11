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

        public BordPositions()
        {
            this.SetAfwijkingen();
        }

        /// <summary>
        /// word een keer door de constructor aangeroepen
        /// </summary>
        void SetAfwijkingen()
        {
            #region omslagpunten
            //defineer lijst met 4 spelers bord
            lafwijkingen = new List<posafwijking>
            {
                new posafwijking("y", -4),
                new posafwijking("x", 4),
                new posafwijking("y", -2),
                new posafwijking("x", -4),
                new posafwijking("y", -4),
                new posafwijking("x", -2),
                new posafwijking("y", 4),
                new posafwijking("x", -4),
                new posafwijking("y", 2),
                new posafwijking("x", 4),
                new posafwijking("y", 4),
                new posafwijking("x", 1)
            };
            #endregion
        }

        public System.Drawing.Point GetPosition(int pos)
        {
            int y = 0;
            int x = 0;
            #region SpeelPositities
            //hokje in speelveld
            if (pos < 40)
            {
                int item = 0;
                while (pos > 0)
                {
                    if (Math.Abs(this.lafwijkingen[item].afwijking) > pos)
                    {
                        int positief = 1;
                        if (this.lafwijkingen[item].afwijking < 0)
                            positief = -1;

                        if (this.lafwijkingen[item].vorm == "x")
                        {
                            x += pos * positief;
                        }
                        else
                        {
                            y += pos * positief;
                        }
                        pos = 0;
                        break;
                    }
                    else
                    {
                        if (this.lafwijkingen[item].vorm == "x")
                        {
                            x += this.lafwijkingen[item].afwijking;
                        }
                        else
                        {
                            y += this.lafwijkingen[item].afwijking;
                        }
                        pos -= (int)Math.Abs(this.lafwijkingen[item].afwijking);
                    }
                    item++;
                }
            }
            #endregion
            #region ThuishavenPosities
            else if (pos > 39 && pos < 56)
            {
                if (pos > 39 && pos < 44)
                {
                    y = 39 -pos;
                    x = -1;
                }
                else if (pos > 43 && pos < 48)
                {
                    y = -5;
                    x = 47 -pos;
                }
                else if (pos > 47 && pos < 52)
                {
                    y = pos -57;
                    x = -1;
                }
                else if (pos > 51 && pos < 56)
                {
                    y = -5;
                    x = pos - 57;
                }
            }
            #endregion
            #region BasePosities
            else
            {
                int tempPos = pos % 4;

                if (pos > 59 && pos < 68)
                {
                    y = tempPos / -2 - 9; //-9
                }
                else
                {
                    y = tempPos / -2;
                }

                if (pos > 63 && pos < 72)
                {
                    x = tempPos % 2 - 6;
                }
                else
                {
                    x = tempPos % 2 + 3;
                }
            }
            #endregion
            return new System.Drawing.Point(x, y);
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
