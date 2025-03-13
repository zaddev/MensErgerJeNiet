using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    public class Pawn
    {
        #region private fields
        int id;
        int color;
        int steps;
        int location;
        DontGetAngry game;
        bool isMovable = false;
        #endregion

        #region eventhandlers
        /// <summary>
        /// The pawn has moved to a different location, it passes its own object
        /// </summary>
        public event EventHandler OnMoved;

        /// <summary>
        /// It must be checked whether it has changed to movable or not
        /// </summary>
        public event EventHandler MovableChange;
        #endregion

        /// <summary>
        /// Object can only be created by the game so that it directly belongs to a game
        /// </summary>
        /// <param name="number"></param>
        /// <param name="color"></param>
        /// <param name="game"></param>
        internal Pawn(int number, int color, DontGetAngry game)
        {
            this.id = color * 4 + number;
            this.color = color;
            this.game = game;

            location = 56 + this.id;
        }

        public int ID => this.id;

        public int Color => this.color;

        public int Steps
        {
            get => this.steps;
            private set => this.steps = value;
        }

        public int LastLocation { get; private set; }
        public bool IsMovable { 
            get => this.isMovable;
            internal set
            {
                // Check if the value has changed
                if(isMovable != value)
                {
                    isMovable = value;
                    // Check if there is something attached to the event
                    MovableChange?.Invoke(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Unique location on the board that the pawn has
        /// </summary>
        public int Location
        {
            get => this.location;
            private set
            {
                this.location = value;
                // Trigger event that the pawn is at a new location
                OnMoved?.Invoke(this, null);
            }
        }

        /// <summary>
        /// Move the pawn the desired number of steps within the game
        /// </summary>
        /// <param name="steps"></param>
        internal void Move(int steps)
        {
            // One can later find out where it stood and can free that spot
            this.LastLocation = this.Location;
            this.steps += steps;
            int newLocation = 0;
            if (this.steps < 40)
            {
                newLocation = (this.steps + this.color * 10) % 40;
            }
            else if (this.steps > 39)
            {
                newLocation = this.game.GetFreeHomeAreaField(this.color);
            }
            // Check if there is no pawn at the new location
            this.CheckToHit(newLocation);

            this.Location = newLocation;
        }

        /// <summary>
        /// Check if there are any pawns that need to be hit
        /// </summary>
        /// <param name="location"></param>
        private void CheckToHit(int location)
        {
            Pawn pawnToHit = game.PawnAtLocation(location);

            // If there is a pawn at the location it is going to, first give a command to hit it
            if (pawnToHit != null)
                game.HitPawn(pawnToHit);
        }

        /// <summary>
        /// Move the pawn to their own start field
        /// </summary>
        internal void MoveToStartField()
        {
            this.steps = 0; // Ensure that a pawn always has 0 steps, this is necessary because there is a chance that a pawn has already moved and this has not been reset
            this.LastLocation = this.Location;

            // Check if you need to hit a pawn
            this.CheckToHit(10 * this.Color);

            this.Location = 10 * this.Color;
        }

        /// <summary>
        /// Action that follows when someone is hit, it is moved all the way back
        /// </summary>
        internal void MoveToDeadPosition()
        {
            this.LastLocation = this.Location;
            this.Location = game.GetFreeDeadPosition(this);
        }
    }
}
