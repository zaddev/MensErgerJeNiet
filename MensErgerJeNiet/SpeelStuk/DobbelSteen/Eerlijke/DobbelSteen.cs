using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.SpeelStuk.DobbelSteen.Eerlijke
{
    public class DobbelSteen : MensErgerJeNiet.SpeelStuk.DobbelSteen.BaseDobbelSteen
    {
        
        #region abstracte methodes to overide
        internal override void _changeLiging()
        {
            var rnd = new Random();
            this._vlakken = this._vlakken.OrderBy(x => rnd.Next() ).ToList();
        }

        #endregion
    }
}
