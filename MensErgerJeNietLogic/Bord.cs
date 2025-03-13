using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    public class Board
    {
        private List<FieldStatus> fields = new();
        /// <summary>
        /// The board has as its main functionality a collection of playing fields stored as Enum field status
        /// </summary>
        internal Board(DontGetAngry game)
        {
            // Fill all fields
            for (var i = 0; i < 72; i++)
            {
                // Initially they are empty because there are no players yet
                this.fields.Add(FieldStatus.free);
            }
        }

        public List<FieldStatus> Fields => this.fields;

        /// <summary>
        /// Adds the pawns so that the board can keep track of whether a pawn is moving
        /// </summary>
        /// <param name="player">player has a hand with 4 pawns</param>
        internal void AddPawns(Player player)
        {
            player.Hand.ForEach(pawn =>
            {
                pawn.OnMoved += pawn_Moved;
                Fields[pawn.Location] = (FieldStatus)pawn.Color;
            }
            );
        }

        /// <summary>
        /// A pawn has moved on the board, it is ensured that the board has the correct status on the fields again
        /// </summary>
        /// <param name="sender">is the pawn that has moved and triggered the event</param>
        /// <param name="e"></param>
        void pawn_Moved(object sender, EventArgs e)
        {
            var pawn = sender as Pawn;
            // Old position is free again
            this.ChangeStatus(pawn.LastLocation, FieldStatus.free);
            // Now change the new location of the pawn to occupied with the color of the pawn
            this.ChangeStatus(pawn.Location, (FieldStatus)pawn.Color);

        }

        /// <summary>
        /// Give the command to change one of the fields 0 to 71
        /// </summary>
        /// <param name="position"></param>
        /// <param name="status"></param>
        internal void ChangeStatus(int position, FieldStatus status)
        {
            this.fields[position] = status;
        }
    }
}
