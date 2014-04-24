using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.SpeelStuk.DobbelSteen.OnEerlijke
{
    public class DobbelSteen : MensErgerJeNiet.SpeelStuk.DobbelSteen.BaseDobbelSteen
    {
        
        #region abstracte methodes to overide
        internal override void _changeLiging()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
