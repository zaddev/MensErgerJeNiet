using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GUIWinForm
{
    public class BoardPositions
    {
        private List<posDeviation> deviations = new List<posDeviation>();

        public BoardPositions()
        {
            this.SetDeviations();
        }

        /// <summary>
        /// Called once by the constructor
        /// </summary>
        void SetDeviations()
        {
            #region turningPoints
            //define list with 4 players board
            deviations = new List<posDeviation>
            {
                new posDeviation("y", -4),
                new posDeviation("x", 4),
                new posDeviation("y", -2),
                new posDeviation("x", -4),
                new posDeviation("y", -4),
                new posDeviation("x", -2),
                new posDeviation("y", 4),
                new posDeviation("x", -4),
                new posDeviation("y", 2),
                new posDeviation("x", 4),
                new posDeviation("y", 4),
                new posDeviation("x", 1)
            };
            #endregion
        }

        /// <summary>
        /// Returns the coordinates of a requested square on the board
        /// </summary>
        /// <param name="pos">position on board</param>
        /// <returns>coordinates relative to 0</returns>
        public Point GetPosition(int pos)
        {
            var y = 0;
            var x = 0;

            #region PlayPositions
            //square in playfield
            if (pos < 40)
            {
                var item = 0;
                while (pos > 0)
                {
                    if (Math.Abs(this.deviations[item].deviation) > pos)
                    {
                        var positive = 1;
                        if (this.deviations[item].deviation < 0)
                            positive = -1;

                        if (this.deviations[item].shape == "x")
                        {
                            x += pos * positive;
                        }
                        else
                        {
                            y += pos * positive;
                        }
                        pos = 0;
                        break;
                    }
                    else
                    {
                        if (this.deviations[item].shape == "x")
                        {
                            x += this.deviations[item].deviation;
                        }
                        else
                        {
                            y += this.deviations[item].deviation;
                        }
                        pos -= (int)Math.Abs(this.deviations[item].deviation);
                    }
                    item++;
                }
            }
            #endregion
            #region HomePositions
            else if (pos > 39 && pos < 56)
            {
                if (pos > 39 && pos < 44)
                {
                    y = 39 - pos;
                    x = -1;
                }
                else if (pos > 43 && pos < 48)
                {
                    y = -5;
                    x = 47 - pos;
                }
                else if (pos > 47 && pos < 52)
                {
                    y = pos - 57;
                    x = -1;
                }
                else if (pos > 51 && pos < 56)
                {
                    y = -5;
                    x = pos - 57;
                }
            }
            #endregion
            #region BasePositions
            else
            {
                var tempPos = pos % 4;

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
            return new Point(x, y);
        }
    }

    class posDeviation
    {
        public string shape;
        public int deviation;

        public posDeviation(string shape, int deviation)
        {
            this.shape = shape;
            this.deviation = deviation;
        }
    }
}
