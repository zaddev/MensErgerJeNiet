using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    public class Player
    {
        #region private fields
        string name;
        int id;
        List<Pawn> hand = new List<Pawn>();
        #endregion

        public event EventHandler OnTurn;
        private DontGetAngry game;

        /// <summary>
        /// Creates a virtual player who has pawns
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="id"></param>
        /// <param name="game"></param>
        internal Player(string playerName, int id, DontGetAngry game)
        {
            this.name = playerName;
            this.id = id;
            
            for(int i = 0; i<4;i++)
            {
                this.hand.Add(new Pawn(i, id, game));
            }

            this.CanRoll = false;
        }
    
        public List<Pawn> Hand
        {
            get
            {
                return this.hand;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Equal to color
        /// </summary>
        public int ID
        {
            get
            {
                return this.id;
            }
        }

        bool isUp;
        internal bool IsUp
        {
            get
            {
                return this.isUp;
            }
            set
            {
                this.isUp = value;
                if(value==true)
                {
                    if (this.OnTurn != null) this.OnTurn(this, null);
                }
            }
        }

        //to keep track of whether someone can still roll
        public bool CanRoll { get; internal set; }
    }
}
