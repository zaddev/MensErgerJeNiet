using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.SpeelStuk.DobbelSteen
{
    /// <remarks>deze classe is het leven geroepen om in de toekomst makkelijk het factory design patern toe te voegen.</remarks>
    public abstract class BaseDobbelSteen
    {
        #region protected fields
        protected List<DobbelsteenVlak> _vlakken = new List<DobbelsteenVlak>();

        #endregion

        /// <summary>
        /// fixxed size zijn er voor een dobbelsteen altijd 6
        /// </summary>
        public List<DobbelsteenVlak> Vlakken
        {
            get
            {
                return this._vlakken;
            }
            set
            {
                this._vlakken = value;
            }
        }


        /// <summary>
        /// de eerste waarde in een lijst ligt bovenaan
        /// </summary>
        public DobbelsteenVlak TopWaarde
        {
            get
            {
                return this._vlakken.First();
            }
        }
    
        abstract internal void _changeLiging();
    }
}
