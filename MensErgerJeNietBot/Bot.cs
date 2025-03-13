using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietBot
{
    public class Bot
    {
        private MensErgerJeNietLogic.Player player;
        private MensErgerJeNietLogic.DontGetAngry game;
        private Random rnd = new();

        /// <summary>
        /// Configures the object.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="player"></param>
        public Bot(MensErgerJeNietLogic.DontGetAngry game, MensErgerJeNietLogic.Player player)
        {
            this.game = game;
            this.player = player;
            // Event is triggered when the player is up
            player.OnTurn += player_OnTurn;
        }

        /// <summary>
        /// This event is triggered when the player is up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void player_OnTurn(object sender, EventArgs e)
        {
            if (player.CanRoll)
            {
                do
                {
                    RollDice();
                    if (player.Hand.Exists(pawn => pawn.IsMovable))
                    {
                        ActionWithRandomPawn();
                    }
                }
                while (this.game.Dice.Value == 6);   
            }       
        }

        /// <summary>
        /// Player rolls the dice when it is their turn
        /// </summary>
        private void RollDice() => game.RollDice();

        private void ActionWithRandomPawn() =>
            game.ActionWithPawn
            (
                this.player.Hand.Where(pawn => pawn.IsMovable) // Select pawns that are movable
                .OrderBy(pawn => rnd.Next())    // Sort the movable pawns randomly
                .First()                        // Then take the first pawn from that sequence
            );
    }
}
