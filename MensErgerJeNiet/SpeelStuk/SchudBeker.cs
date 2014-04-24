using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.SpeelStuk
{
    public class SchudBeker
    {
        #region private fields
        private List<MensErgerJeNiet.SpeelStuk.DobbelSteen.BaseDobbelSteen> _dobbelstenen;

        #endregion

        #region public properties
        public List<MensErgerJeNiet.SpeelStuk.DobbelSteen.BaseDobbelSteen> Dobbelstenen
        {
            get
            {
                return this._dobbelstenen;
            }
            set
            {
                this._dobbelstenen = value;
            }
        }

        #endregion

        public List<MensErgerJeNiet.SpeelStuk.DobbelSteen.BaseDobbelSteen> SchudDobbelstenen()
        {
            if(this._dobbelstenen != null && this._dobbelstenen.Count>0)
            {
                //geef ze allemaal een wisselcommando
                //logica wordt in het object zelf uitgevoerd om dat de berekening voor ieder soort dobbelsteen kan verschillen
                this._dobbelstenen.ForEach(dobbelsteen => dobbelsteen._changeLiging());

                //de stenen zijn geschud
                return this.Dobbelstenen;
            }
            else
            {
                throw new Exception("er zijn geen dobbelstenen aanwezig");
            }

            
        }
    }
}
