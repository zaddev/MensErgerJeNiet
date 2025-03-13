using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNietLogic
{
    /// <summary>
    /// The object that bridges all logic, allowing communication between the GUI and the backend logic.
    /// </summary>
    public class DontGetAngry
    {
        #region private fields
        readonly Dice dice = new();
        List<Player> players = new();
        Board board;
        int currentPlayer;
        bool gameStarted = false;
        #endregion

        /// <summary>
        /// A new player is up.
        /// </summary>
        public event EventHandler NewCurrentPlayer;

        public event EventHandler CanRoll;

        public event EventHandler EndGame;

        /// <summary>
        /// A new empty game is created.
        /// </summary>
        public DontGetAngry()
        {
            this.board = new Board(this);
        }

        /// <summary>
        /// The dice, only the value can be read from outside the library.
        /// </summary>
        public Dice Dice => this.dice;

        /// <summary>
        /// A list of all players participating in the game.
        /// </summary>
        public List<Player> Players
        {
            get => this.players;
            private set => this.players = value;
        }

        /// <summary>
        /// The board with all fields.
        /// </summary>
        internal Board Board
        {
            get => this.board;
            set => this.board = value;
        }

        /// <summary>
        /// The player who is currently up.
        /// </summary>
        public Player CurrentPlayer
        {
            get
            {
                // The game must be started.
                if (!this.gameStarted) throw new InvalidOperationException("The game has not started yet.");
                return this.players[currentPlayer];
            }
        }

        /// <summary>
        /// Rolls the dice and the game knows the necessary possibilities.
        /// </summary>
        /// <returns>The number of eyes rolled.</returns>
        public int RollDice()
        {
            // The game must be started.
            if (!this.gameStarted) throw new InvalidOperationException("The game has not started yet.");
            if(!this.CurrentPlayer.CanRoll) throw new InvalidOperationException("Rolling is not allowed at this moment.");
            this.Dice.Roll();

            // The player is initially not allowed to roll because they either cannot roll anymore or they need to do something with a pawn first.
            this.CurrentPlayer.CanRoll = false;

            if (this.CurrentPlayer.Hand.Exists(pawn => pawn.Location == pawn.Color * 10) && this.CurrentPlayer.Hand.Exists(pawn => pawn.Location > 55))
            {
                this.CurrentPlayer.Hand.First(pawn => pawn.Location == pawn.Color * 10).IsMovable = true;
            }
            // Check which pawns can be placed.
            // A 6 is rolled and there are still pawns that can be placed on the board.
            else if (this.CurrentPlayer.Hand.Count(x => x.Location > 55) >= 1 && Dice.Value == 6)
            {
                // Make pawns available to move that are on the dead positions.
                this.CurrentPlayer.Hand.ForEach(x =>
                {
                    if (x.Location > 55)
                    {
                        x.IsMovable = true;
                    }
                });
            }
            // It is possible that the turn is already over.
            // Chosen for greater than 39 because it also includes pawns that are already on the home position.
            else if(this.CurrentPlayer.Hand.Count(x => x.Location > 39) == 4)
            {
                this.NewPlayer();
            }
            // If this is not true, the pawns in the game can be made available.
            else
            {
                this.CurrentPlayer.Hand.ForEach(x =>
                    {
                        if (x.Location <= 39)
                            x.IsMovable = true;
                    }
                    );
            }

            return this.Dice.Value;
        }

        private void NewPlayer()
        {
            this.CurrentPlayer.Hand.ForEach(x => x.IsMovable = false);
            this.CurrentPlayer.IsUp = false;

            this.currentPlayer = (this.currentPlayer + 1) % this.players.Count;
            // This player can roll again.
            this.CurrentPlayer.CanRoll = true;
            if (CanRoll != null) CanRoll(this.Dice, new EventArgs());
            if (NewCurrentPlayer != null) NewCurrentPlayer(this.CurrentPlayer, new EventArgs());
            this.CurrentPlayer.IsUp = true;
        }

        /// <summary>
        /// Creates a new player, this is the only place where a new player can be created.
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public Player AddNewPlayer(string playerName)
        {
            // The game must not be started yet.
            if (this.gameStarted) throw new InvalidOperationException("The game has already started, you cannot add more players.");

            // Check if there is a collection of players.
            if (this.Players == null) 
                this.Players = new List<Player>();
            // Check if there are no more than 4 players.
            if (this.Players.Count >= 4) 
                throw new System.InvalidOperationException("There are already 4 players.");

            Player newPlayer = new(playerName, this.Players.Count, this);
            this.Players.Add(newPlayer);

            this.board.AddPawns(newPlayer);

            return newPlayer;
        }

        /// <summary>
        /// This pawn is chosen to perform the action that is possible at this moment.
        /// </summary>
        /// <param name="pawn"></param>
        public void ActionWithPawn(Pawn pawn)
        {
            // The game must be started.
            if (!this.gameStarted) throw new InvalidOperationException("The game has not started yet.");

            // Check if the pawn can be played with.
            if(pawn.IsMovable)
            {
                if(pawn.Location > 55) // 56 is the first location that is a dead position.
                {
                    this.PlaceNewPawn(pawn);
                }
                else
                {
                    this.MovePawn(pawn);
                }

                // Check if the player has won.
                this.CheckForWin(this.CurrentPlayer);

                // Check if the player can roll again.
                this.CurrentPlayer.CanRoll = this.Dice.Value == 6;
                // If the player cannot roll again, the next player is up.
                if(!this.CurrentPlayer.CanRoll)
                {
                    this.NewPlayer();
                }
                else
                {
                    if (CanRoll != null) CanRoll(this.Dice, new EventArgs());
                }

                // Ensure that the current player cannot do anything with their pawns anymore.
                this.CurrentPlayer.Hand.ForEach(x => x.IsMovable = false);
            }
        }

        /// <summary>
        /// Check if this player might have already won.
        /// </summary>
        /// <param name="player"></param>
        private void CheckForWin(Player player)
        {
            // All home positions are from 40 to 55, so if all your pawns are between those positions, you have won.
            if(player.Hand.Count(x => x.Location > 39 && x.Location < 56) == 4)
            {
                // All pawns are home, the player has won.
                if (this.EndGame != null) 
                    EndGame(player, new EventArgs());

            }
        }

        /// <summary>
        /// Move a pawn a number of steps forward if it has just been rolled.
        /// </summary>
        /// <param name="pawn"></param>
        private void MovePawn(Pawn pawn)
        {
            pawn.Move(this.dice.Value);
        }

        /// <summary>
        /// Move a pawn from the dead positions to the starting field.
        /// </summary>
        /// <param name="pawn"></param>
        private void PlaceNewPawn(Pawn pawn)
        {
            if(pawn.IsMovable)
            {
                pawn.MoveToStartField();
            }
        }

        // Move the pawn back to the dead positions.
        internal void HitPawn(Pawn pawn)
        {
            pawn.MoveToDeadPosition();
        }

        /// <summary>
        /// Checks for the highest free position in the home area.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        internal int GetFreeHomeAreaField(int color)
        {
            // Checks for the highest free position in the home area.
            // It is 40 + 4 * color from + 3.
            for(int i = 40 + 4 * color + 3; i >= 40 + 4 * color; i--)
            {
                if(this.board.Fields[i] == FieldStatus.free)
                {
                    return i;
                }
            }
            return 0;
        }

        /// <summary>
        /// Returns a pawn found by its ID.
        /// </summary>
        /// <param name="pawnId"></param>
        /// <returns></returns>
        private Pawn GetPawnById(int pawnId)
        {
            if (pawnId > 15) throw new ArgumentOutOfRangeException("There are not that many pawns.");
            return players.First(
                player =>
                    player.Hand.Exists
                    (pawn =>
                        pawn.ID == pawnId
                        )
                        ).Hand.First(x =>
                            x.ID == pawnId
                            );
        }

        /// <summary>
        /// Returns the pawn at a certain location if present.
        /// </summary>
        /// <param name="newLocation"></param>
        /// <returns>Can return null if not present.</returns>
        internal Pawn PawnAtLocation(int newLocation)
        {
            // First quickly check if it might be free.
            if(board.Fields[newLocation] == FieldStatus.free)
            {
                return null;
            }
            // It comes here, so there is a pawn at the place.
            return this.players.First(player => player.Hand.Exists(pawn => pawn.Location == newLocation)).Hand.First(x => x.Location == newLocation);

        }

        /// <summary>
        /// Returns the first available position for this pawn to go back to.
        /// </summary>
        /// <param name="pawn"></param>
        /// <returns></returns>
        internal int GetFreeDeadPosition(Pawn pawn)
        {
            for (int i = 56 + 4 * pawn.Color; i < 56 + 4 * pawn.Color + 4; i++)
            {
                if(this.Board.Fields[i] == FieldStatus.free)
                {
                    return i;
                }
            }
            throw new InvalidOperationException("There is no free position.");
        }

        /// <summary>
        /// After this command, the game is officially started and, for example, no more players can be added, but things like rolling can be done.
        /// </summary>
        public void StartGame()
        {
            this.gameStarted = true;

            // The first player is up.
            this.currentPlayer = 0;
            this.CurrentPlayer.CanRoll = true;
            this.CurrentPlayer.IsUp = true;
            if (NewCurrentPlayer != null) NewCurrentPlayer(this.CurrentPlayer, new EventArgs());
        }
    }
}
