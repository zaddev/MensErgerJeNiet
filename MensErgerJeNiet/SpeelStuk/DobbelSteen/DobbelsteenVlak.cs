using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.SpeelStuk.DobbelSteen
{
    public class DobbelsteenVlak
    {
        #region private fields
        private List<DobbelSteenVlakOog> _ogen = new List<DobbelSteenVlakOog>();

        #endregion

        /// <summary>
        /// stel een basis vlak in met een antal ogen
        /// </summary>
        /// <param name="vlakken"></param>
        public DobbelsteenVlak(int vlakken)
        {
            for(;vlakken>0;vlakken--)
            {
                this._ogen.Add(new DobbelSteenVlakOog());
            }
        }
        public List<DobbelSteenVlakOog> Ogen
        {
            get
            {
                return this._ogen;
            }
        }

        public Size Size
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
