using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.SpeelStuk.DobbelSteen.Eerlijke
{
    public class DobbelSteen : MensErgerJeNiet.SpeelStuk.DobbelSteen.BaseDobbelSteen
    {

        #region public constructors
        public DobbelSteen()
        {
            //zorg dat je 6 vlakken hebt met 1 tm 6
            for(int i=1;i<=6;i++)
            {
                this._vlakken.Add(new DobbelsteenVlak(i));
            }


        }

        #endregion

        #region abstracte methodes to overide
        internal override void _changeLiging(Random rnd)
        {
            this._vlakken = this._vlakken.OrderBy(x => rnd.Next() ).ToList();
        }

        #endregion
    }
}
