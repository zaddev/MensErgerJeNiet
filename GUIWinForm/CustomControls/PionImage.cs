﻿using System;
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
    public class PionImage : PictureBox
    {
        private MensErgerJeNietLogic.Pion lPion;
        private BordPositions bordPositions = new();
        BackgroundWorker animatedPion = new();
        static bool isAnimating = false;

        #region constructors

        /// <summary>
        /// maak een pion en bepaal de kleur
        /// </summary>
        /// <param name="kleur">kleur die hij in het spel krijgt</param>
        public PionImage(Color kleur, MensErgerJeNietLogic.Pion logicPion)
        {
            this.lPion = logicPion;
            this.SetCollorImage(kleur);
            this.configPion();

            // Eventlisteners toevoegen
            this.animatedPion.DoWork += animatedPion_DoWork;
            this.animatedPion.WorkerReportsProgress = true;
            this.animatedPion.ProgressChanged += animatedPion_ProgressChanged;
            this.animatedPion.RunWorkerCompleted += animatedPion_RunWorkerCompleted;
            logicPion.OnVerplaatst += logicPion_Verplaatst;
            logicPion.VerplaatsbaarChange += logicPion_Verplaatsbaar;
        }

        void animatedPion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => PionImage.isAnimating = false;

        void animatedPion_ProgressChanged(object sender, ProgressChangedEventArgs e) => VerplaatsNaar(e.ProgressPercentage);

        void animatedPion_DoWork(object sender, DoWorkEventArgs e)
        {
            //blijf wachten toch hij niet meer bezig is
            while (PionImage.isAnimating)
            {
                System.Threading.Thread.Sleep(300);
            }
            PionImage.isAnimating = true;
            var pion = e.Argument as MensErgerJeNietLogic.Pion;

            //er kan ondertussen nog een verandering zijn deze moet dus ook nog worden doorgevoerd
            var stoplocatie = 0;
            do
            {

                if (pion.LaatsteLocatie > 55 || pion.Locatie > 39)
                {
                    animatedPion.ReportProgress(pion.Locatie);
                    stoplocatie = pion.Locatie;
                }
                else if (pion.Locatie < pion.LaatsteLocatie)
                {
                    var stappen = 40 + pion.Locatie;
                    for (var i = pion.LaatsteLocatie; i <= stappen; i++)
                    {
                        animatedPion.ReportProgress(i % 40);
                        System.Threading.Thread.Sleep(250);
                        stoplocatie = i % 40;
                    }
                }
                else if (pion.LaatsteLocatie < 40)
                {
                    var eindlocatie = pion.Locatie;//expres hier gereseveerd omdat door het asynchrone karakter de value terwijl de loop nog wordt uitgevoerd kan wijzigen
                    for (var i = pion.LaatsteLocatie; i <= eindlocatie; i++)
                    {
                        animatedPion.ReportProgress(i);
                        System.Threading.Thread.Sleep(250);
                        stoplocatie = i;
                    }
                }
            }
            while (stoplocatie != pion.Locatie);
        }

        public PionImage(Color kleur)
        {
            this.SetCollorImage(kleur);
            this.configPion();
        }
        #endregion

        /// <summary>
        /// Zorgt dat de pion verandert zodat de gebruiker weet dat de pion klikbaar is. Gebeurt zodra "logicgpion_verplaatsbaar" wordt aangeroepen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void logicPion_Verplaatsbaar(object sender, EventArgs e)
        {
            if (this.lPion.IsVerplaatsbaar)
                this.SetSelectedPion();
            else
                this.SetSelectedPionOff();
        }

        /// <summary>
        /// Verplaats de pion automatisch zodra het event "logicPion_Verplaatst" word aangeroepen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void logicPion_Verplaatst(object sender, EventArgs e)
        {
            if (!animatedPion.IsBusy)
            {
                animatedPion.RunWorkerAsync(this.lPion);
            }
        }

        /// <summary>
        /// verplaats de pion naar de des betreffende lokatie
        /// </summary>
        void VerplaatsNaar(int locatie)
        {
            var nieuwelocatie = bordPositions.GetPosition(locatie);
            // x bewerking en y bewerking
            nieuwelocatie.X = nieuwelocatie.X * 65 + 453;
            nieuwelocatie.Y = nieuwelocatie.Y * -1 * 58 + 26;
            this.Location = nieuwelocatie;
        }
        private void configPion()
        {
            this.Size = new System.Drawing.Size(42, 60);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TabIndex = 8;
            this.TabStop = false;
            this.BackColor = System.Drawing.Color.Transparent;
        }

        void SetCollorImage(Color kleur)
        {
            switch (kleur)
            {
                case Color.blauw:
                    this.Image = global::GUIWinForm.Properties.Resources.pion_blauw;
                    break;
                case Color.geel:
                    this.Image = global::GUIWinForm.Properties.Resources.pion_geel;
                    break;
                case Color.groen:
                    this.Image = global::GUIWinForm.Properties.Resources.pion_groen;
                    break;
                case Color.rood:
                    this.Image = global::GUIWinForm.Properties.Resources.pion_rood;
                    break;
            }
        }

        // methode om de gebruiker te laten zien dat de pion selecteerbaar is 
        /// <summary>
        /// Om de gebruiker te laten zien dat de pion selecteerbaar is 
        /// </summary>
        private void SetSelectedPion()
        {
            this.Click += PionImage_Click;
            BorderStyle = BorderStyle.Fixed3D;
        }

        private void SetSelectedPionOff()
        {
            this.Click -= PionImage_Click;
            BorderStyle = BorderStyle.None;
        }

        void PionImage_Click(object sender, EventArgs e) => Global.Spel.ActieMetPion(this.lPion);
    }
}
