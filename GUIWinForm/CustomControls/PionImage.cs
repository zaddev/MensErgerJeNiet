using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GUIWinForm.Screen;
using System.ComponentModel;

namespace GUIWinForm
{
    public class PawnImage : PictureBox
    {
        private MensErgerJeNietLogic.Pawn lPawn;
        private BoardPositions boardPositions = new();
        BackgroundWorker animatedPawn = new();
        static bool isAnimating = false;

        #region constructors

        /// <summary>
        /// Create a pawn and determine its color
        /// </summary>
        /// <param name="color">color it gets in the game</param>
        public PawnImage(Color color, MensErgerJeNietLogic.Pawn logicPawn)
        {
            this.lPawn = logicPawn;
            this.SetColorImage(color);
            this.configPawn();

            // Add event listeners
            this.animatedPawn.DoWork += animatedPawn_DoWork;
            this.animatedPawn.WorkerReportsProgress = true;
            this.animatedPawn.ProgressChanged += animatedPawn_ProgressChanged;
            this.animatedPawn.RunWorkerCompleted += animatedPawn_RunWorkerCompleted;
            logicPawn.OnMoved += logicPawn_Moved;
            logicPawn.MovableChange += logicPawn_Movable;
        }

        void animatedPawn_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => PawnImage.isAnimating = false;

        void animatedPawn_ProgressChanged(object sender, ProgressChangedEventArgs e) => MoveTo(e.ProgressPercentage);

        void animatedPawn_DoWork(object sender, DoWorkEventArgs e)
        {
            // Keep waiting until it is no longer busy
            while (PawnImage.isAnimating)
            {
                System.Threading.Thread.Sleep(300);
            }
            PawnImage.isAnimating = true;
            var pawn = e.Argument as MensErgerJeNietLogic.Pawn;

            // There may have been another change in the meantime, which must also be implemented
            var stopLocation = 0;
            do
            {

                if (pawn.LastLocation > 55 || pawn.Location > 39)
                {
                    animatedPawn.ReportProgress(pawn.Location);
                    stopLocation = pawn.Location;
                }
                else if (pawn.Location < pawn.LastLocation)
                {
                    var steps = 40 + pawn.Location;
                    for (var i = pawn.LastLocation; i <= steps; i++)
                    {
                        animatedPawn.ReportProgress(i % 40);
                        System.Threading.Thread.Sleep(250);
                        stopLocation = i % 40;
                    }
                }
                else if (pawn.LastLocation < 40)
                {
                    var endLocation = pawn.Location; // Reserved here on purpose because the value can change while the loop is still running due to the asynchronous nature
                    for (var i = pawn.LastLocation; i <= endLocation; i++)
                    {
                        animatedPawn.ReportProgress(i);
                        System.Threading.Thread.Sleep(250);
                        stopLocation = i;
                    }
                }
            }
            while (stopLocation != pawn.Location);
        }

        public PawnImage(Color color)
        {
            this.SetColorImage(color);
            this.configPawn();
        }
        #endregion

        /// <summary>
        /// Ensures that the pawn changes so that the user knows the pawn is clickable. Happens as soon as "logicPawn_Movable" is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void logicPawn_Movable(object sender, EventArgs e)
        {
            if (this.lPawn.IsMovable)
                this.SetSelectedPawn();
            else
                this.SetSelectedPawnOff();
        }

        /// <summary>
        /// Automatically move the pawn when the event "logicPawn_Moved" is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void logicPawn_Moved(object sender, EventArgs e)
        {
            if (!animatedPawn.IsBusy)
            {
                animatedPawn.RunWorkerAsync(this.lPawn);
            }
        }

        /// <summary>
        /// Move the pawn to the specified location
        /// </summary>
        void MoveTo(int location)
        {
            var newLocation = boardPositions.GetPosition(location);
            // x operation and y operation
            newLocation.X = newLocation.X * 65 + 453;
            newLocation.Y = newLocation.Y * -1 * 58 + 26;
            this.Location = newLocation;
        }
        private void configPawn()
        {
            this.Size = new System.Drawing.Size(42, 60);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TabIndex = 8;
            this.TabStop = false;
            this.BackColor = System.Drawing.Color.Transparent;
        }

        void SetColorImage(Color color)
        {
            switch (color)
            {
                case Color.blue:
                    this.Image = global::GUIWinForm.Properties.Resources.pawn_blue;
                    break;
                case Color.yellow:
                    this.Image = global::GUIWinForm.Properties.Resources.pawn_yellow;
                    break;
                case Color.green:
                    this.Image = global::GUIWinForm.Properties.Resources.pawn_green;
                    break;
                case Color.red:
                    this.Image = global::GUIWinForm.Properties.Resources.pawn_red;
                    break;
            }
        }

        // Method to show the user that the pawn is selectable
        /// <summary>
        /// To show the user that the pawn is selectable
        /// </summary>
        private void SetSelectedPawn()
        {
            this.Click += PawnImage_Click;
            BorderStyle = BorderStyle.Fixed3D;
        }

        private void SetSelectedPawnOff()
        {
            this.Click -= PawnImage_Click;
            BorderStyle = BorderStyle.None;
        }

        void PawnImage_Click(object sender, EventArgs e) => Global.Game.ActionWithPawn(this.lPawn);
    }
}
