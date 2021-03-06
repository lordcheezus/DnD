﻿using System;
using System.Text;
using System.Windows.Forms;
using DnD.Classes.CharacterClasses;
using DnD.Classes.HeroFeats;
using HeroMaker.Enums;

namespace HeroMaker.Forms
{
    /// <summary>
    /// The Feats form. We use this form to gather information about hero's desired Feats.
    /// </summary>
    public partial class Feat : Form
    {
        #region Form Essentials

        /// <summary>
        /// Upon form construction, this method is called. It is core to the construction of WinForm objects.
        /// </summary>
        public Feat()
        {
            InitializeComponent();
            PlayerFeats.PopulateContainer();
            featCountTextBox.Text = Player.GetHero.FeatsAvailable.ToString();
            bonusMonkFeatsMenuBox.Enabled = Player.GetHero.TypeOfCharacter is Monk;
            bonusFighterFeatsMenuBox.Enabled = Player.GetHero.TypeOfCharacter is Fighter;
            featsMenuBox.Text = "SELECT A FEAT!";
            bonusMonkFeatsMenuBox.Text = bonusMonkFeatsMenuBox.Enabled ? "SELECT A FEAT!" : null;
            bonusFighterFeatsMenuBox.Text = bonusFighterFeatsMenuBox.Enabled ? "SELECT A FEAT!" : null;
        }

        /// <summary>
        /// A failsafe for the user. If the user clicks the exit button on the top right of the application, signal that
        /// we are done using the app and want it closed.
        /// </summary>
        private void Feat_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormControl.Gs = GameState.Final;
            this.Dispose();
        }

        /// <summary>
        /// When we are ready to move on to the next form, the button click signals the FormControl object to change states.
        /// </summary>
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            PlayerFeats.TrimContainer();
            FormControl.Gs = GameState.Detail;
            this.Dispose();
        }


        #endregion

        #region Menu Item Click Events

        /// <summary>
        /// When the user clicks on the Bonus Fighters feat menu box this event is fired.
        /// </summary>
        private void bonusFighterFeatsMenuBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            featsMenuBox.Text = string.Empty;
            bonusMonkFeatsMenuBox.Text = string.Empty;
            learnFeatButton.Enabled = false;
            removeFeatButton.Enabled = false;
            learnMonkFeatButton.Enabled = false;
            removeMonkFeatButton.Enabled = false;
            descriptionTextBox.Clear();

            string selectedFeat = (string)bonusFighterFeatsMenuBox.SelectedItem;

            foreach (BaseFeat bf in PlayerFeats.FeatsContainer)
            {
                if (FeatInformation.GetEnumFromString(selectedFeat) == bf.FeatType)
                {
                    descriptionTextBox.Text = "(" + bf.FeatType + ")\r\n";
                    descriptionTextBox.Text += FeatInformation.GetDescription(bf.FeatType);
                    descriptionTextBox.Text += "\r\n\r\n\r\nThis Feat Requires the following:\r\n";
                    descriptionTextBox.Text += FeatInformation.GetPrerequisitesString(bf.FeatType);
                    FeatRequirementCheck.CheckIfFeatCanBeAcquired(Player.GetHero, bf);
                    learnFighterFeatButton.Enabled = bf.CanAcquire && Player.GetHero.BonusFeatsAvailable;
                    removeFighterFeatButton.Enabled = bf.IsAcquired;
                    break;
                }
            }
        }

        /// <summary>
        /// When the user clicks on the Bonus Monks feat menu box this event is fired.
        /// </summary>
        private void bonusMonkFeatsMenuBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            featsMenuBox.Text = string.Empty;
            bonusFighterFeatsMenuBox.Text = string.Empty;
            learnFeatButton.Enabled = false;
            removeFeatButton.Enabled = false;
            learnFighterFeatButton.Enabled = false;
            removeFighterFeatButton.Enabled = false;
            descriptionTextBox.Clear();
            
            string selectedFeat = (string)bonusMonkFeatsMenuBox.SelectedItem;

            foreach (BaseFeat bf in PlayerFeats.FeatsContainer)
            {
                if (FeatInformation.GetEnumFromString(selectedFeat) == bf.FeatType)
                {
                    descriptionTextBox.Text = "(" + bf.FeatType + ")\r\n";
                    descriptionTextBox.Text += FeatInformation.GetDescription(bf.FeatType);
                    descriptionTextBox.Text += "\r\n\r\n\r\nThis Feat Requires the following:\r\n";
                    descriptionTextBox.Text += FeatInformation.GetPrerequisitesString(bf.FeatType);
                    bf.CanAcquire = !bf.IsAcquired;
                    learnMonkFeatButton.Enabled = bf.CanAcquire && Player.GetHero.BonusFeatsAvailable;
                    removeMonkFeatButton.Enabled = bf.IsAcquired;
                    break;
                }
            }
        }

        /// <summary>
        /// When the user clicks on the Feat menu box this event is fired.
        /// </summary>
        private void featsMenuBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bonusFighterFeatsMenuBox.Text = string.Empty;
            bonusMonkFeatsMenuBox.Text = string.Empty;
            learnFighterFeatButton.Enabled = false;
            removeFighterFeatButton.Enabled = false;
            learnMonkFeatButton.Enabled = false;
            removeMonkFeatButton.Enabled = false;
            descriptionTextBox.Clear();
            
            string selectedFeat = (string)featsMenuBox.SelectedItem;

            foreach (BaseFeat bf in PlayerFeats.FeatsContainer)
            {
                if (FeatInformation.GetEnumFromString(selectedFeat) == bf.FeatType)
                {
                    descriptionTextBox.Text = "(" + bf.FeatType + ")\r\n";
                    descriptionTextBox.Text += FeatInformation.GetDescription(bf.FeatType);
                    descriptionTextBox.Text += "\r\n\r\n\r\nThis Feat Requires the following:\r\n";
                    descriptionTextBox.Text += FeatInformation.GetPrerequisitesString(bf.FeatType);
                    FeatRequirementCheck.CheckIfFeatCanBeAcquired(Player.GetHero, bf);
                    learnFeatButton.Enabled = bf.CanAcquire && Player.GetHero.FeatsAvailable > 0;
                    removeFeatButton.Enabled = bf.IsAcquired;
                    break;
                }
            }
        }


        #endregion

        #region Learn and Unlearn Feat Button Events

        /// <summary>
        /// Helper method responsible for managing the state of whether or not we can close this form gracefully.
        /// </summary>
        private void UpdateSaveButton()
        {
            saveChangesButton.Enabled = !Player.GetHero.BonusFeatsAvailable && Player.GetHero.FeatsAvailable == 0;
        }

        /// <summary>
        /// Helper method for the necessary updating of the known list of Feats
        /// </summary>
        private void UpdateFeatsBox()
        {
            StringBuilder sb = new StringBuilder();

            if (PlayerFeats.FeatsContainer != null)
            {
                foreach (BaseFeat bf in PlayerFeats.FeatsContainer)
                {
                    if (bf.IsAcquired)
                    {
                        sb.AppendLine(bf.FeatType.ToString());
                    }
                }
            }

            Player.GetHero.PlayerFeats = PlayerFeats.FeatsContainer;

            knownFeatsTextBox.Clear();
            knownFeatsTextBox.Text = sb.ToString();
        }
        
        /// <summary>
        /// When the user clicks on the Standard Learn Feat button the logic behind feat acquisition is ran.
        /// </summary>
        private void learnFeatButton_Click(object sender, EventArgs e)
        {
            if (Player.GetHero.FeatsAvailable > 0)
            {
                string selectedFeat = (string) featsMenuBox.SelectedItem;

                foreach (BaseFeat bf in PlayerFeats.FeatsContainer)
                {
                    if (FeatInformation.GetEnumFromString(selectedFeat) == bf.FeatType)
                    {
                        FeatRequirementCheck.CheckIfFeatCanBeAcquired(Player.GetHero, bf);
                        if (bf.CanAcquire && !bf.IsAcquired)
                        {
                            Player.GetHero.FeatsAvailable--;
                            FeatRequirementCheck.AcquireTheFeat(bf);
                            learnFeatButton.Enabled = false;
                            removeFeatButton.Enabled = true;
                            break;
                        }
                    }
                }
            }

            UpdateSaveButton();
            featCountTextBox.Text = Player.GetHero.FeatsAvailable.ToString();
            UpdateFeatsBox();
        }

        /// <summary>
        /// When the user clicks on the Standard Remove Feat button the logic behind feat removal is ran.
        /// </summary>
        private void removeFeatButton_Click(object sender, EventArgs e)
        {
            string selectedFeat = (string)featsMenuBox.SelectedItem;

            foreach (BaseFeat bf in PlayerFeats.FeatsContainer)
            {
                if (FeatInformation.GetEnumFromString(selectedFeat) == bf.FeatType)
                {
                    if (bf.IsAcquired)
                    {
                        if (!Player.GetHero.BonusFeatsAvailable && (!(Player.GetHero.TypeOfCharacter is Monk) && !(Player.GetHero.TypeOfCharacter is Fighter)))
                        {
                            Player.GetHero.FeatsAvailable++;
                            FeatRequirementCheck.RemoveTheFeat(bf);
                            learnFeatButton.Enabled = true;
                            removeFeatButton.Enabled = false;
                        }
                        else if (Player.GetHero.BonusFeatsAvailable && ((Player.GetHero.TypeOfCharacter is Monk) || (Player.GetHero.TypeOfCharacter is Fighter)))
                        {
                            Player.GetHero.FeatsAvailable++;
                            FeatRequirementCheck.RemoveTheFeat(bf);
                            learnFeatButton.Enabled = true;
                            removeFeatButton.Enabled = false;
                        }
                        else
                        {
                            Player.GetHero.BonusFeatsAvailable = true;
                            FeatRequirementCheck.RemoveTheFeat(bf);
                        }

                        foreach (BaseFeat check in PlayerFeats.FeatsContainer)
                        {
                            FeatRequirementCheck.CheckIfFeatCanBeAcquired(Player.GetHero, check);

                            if (check.IsAcquired && !check.CanAcquire)
                            {
                                if (!Player.GetHero.BonusFeatsAvailable && (!(Player.GetHero.TypeOfCharacter is Monk) && !(Player.GetHero.TypeOfCharacter is Fighter)))
                                {
                                    Player.GetHero.FeatsAvailable++;
                                    FeatRequirementCheck.RemoveTheFeat(check);
                                    learnFeatButton.Enabled = false;
                                    removeFeatButton.Enabled = false;
                                }
                                else if (Player.GetHero.BonusFeatsAvailable && ((Player.GetHero.TypeOfCharacter is Monk) || (Player.GetHero.TypeOfCharacter is Fighter)))
                                {
                                    Player.GetHero.FeatsAvailable++;
                                    FeatRequirementCheck.RemoveTheFeat(check);
                                    learnFeatButton.Enabled = false;
                                    removeFeatButton.Enabled = false;
                                }
                                else
                                {
                                    Player.GetHero.BonusFeatsAvailable = true;
                                    FeatRequirementCheck.RemoveTheFeat(check);
                                    learnFeatButton.Enabled = false;
                                    removeFeatButton.Enabled = false;
                                }
                            }
                        }

                        break;
                    }
                }
            }

            UpdateSaveButton();
            featCountTextBox.Text = Player.GetHero.FeatsAvailable.ToString();
            UpdateFeatsBox();
        }

        /// <summary>
        /// When the user clicks on the Fighter's Learn Feat button the logic behind feat acquisition is ran.
        /// </summary>
        private void learnFighterFeatButton_Click(object sender, EventArgs e)
        {
            if (Player.GetHero.BonusFeatsAvailable)
            {
                string selectedFeat = (string)bonusFighterFeatsMenuBox.SelectedItem;

                foreach (BaseFeat bf in PlayerFeats.FeatsContainer)
                {
                    if (FeatInformation.GetEnumFromString(selectedFeat) == bf.FeatType)
                    {
                        FeatRequirementCheck.CheckIfFeatCanBeAcquired(Player.GetHero, bf);
                        if (bf.CanAcquire && !bf.IsAcquired)
                        {
                            Player.GetHero.BonusFeatsAvailable = false;
                            FeatRequirementCheck.AcquireTheFeat(bf);
                            learnFighterFeatButton.Enabled = false;
                            removeFighterFeatButton.Enabled = true;
                        }
                    }
                }
            }

            UpdateSaveButton();
            featCountTextBox.Text = Player.GetHero.FeatsAvailable.ToString();
            UpdateFeatsBox();
        }

        /// <summary>
        /// When the user clicks on the Fighter's Remove Feat button the logic behind feat removal is ran.
        /// </summary>
        private void removeFighterFeatButton_Click(object sender, EventArgs e)
        {
            string selectedFeat = (string)bonusFighterFeatsMenuBox.SelectedItem;

            foreach (BaseFeat bf in PlayerFeats.FeatsContainer)
            {

                if (FeatInformation.GetEnumFromString(selectedFeat) == bf.FeatType)
                {
                    if (bf.IsAcquired)
                    {
                        if (Player.GetHero.BonusFeatsAvailable && ((Player.GetHero.TypeOfCharacter is Monk) || (Player.GetHero.TypeOfCharacter is Fighter)))
                        {
                            Player.GetHero.FeatsAvailable++;
                            FeatRequirementCheck.RemoveTheFeat(bf);
                            learnFeatButton.Enabled = true;
                            removeFeatButton.Enabled = false;
                        }
                        else
                        {
                            Player.GetHero.FeatsAvailable++;
                            FeatRequirementCheck.RemoveTheFeat(bf);
                            learnFeatButton.Enabled = true;
                            removeFeatButton.Enabled = false;
                        }

                        foreach (BaseFeat check in PlayerFeats.FeatsContainer)
                        {
                            FeatRequirementCheck.CheckIfFeatCanBeAcquired(Player.GetHero, check);

                            if (check.IsAcquired && !check.CanAcquire)
                            {
                                Player.GetHero.BonusFeatsAvailable = true;
                                FeatRequirementCheck.RemoveTheFeat(check);
                                learnFeatButton.Enabled = false;
                                removeFeatButton.Enabled = false;
                            }
                        }

                        break;
                    }
                }
            }

            UpdateSaveButton();
            featCountTextBox.Text = Player.GetHero.FeatsAvailable.ToString();
            UpdateFeatsBox();
        }

        /// <summary>
        /// When the user clicks on the  Monk's Learn Feat button the logic behind feat acquisition is ran.
        /// </summary>
        private void learnMonkFeatButton_Click(object sender, EventArgs e)
        {
            if (Player.GetHero.BonusFeatsAvailable)
            {
                string selectedFeat = (string)bonusMonkFeatsMenuBox.SelectedItem;

                foreach (BaseFeat bf in PlayerFeats.FeatsContainer)
                {
                    if (FeatInformation.GetEnumFromString(selectedFeat) == bf.FeatType)
                    {
                        // in the rule book it states that the monk does not need to meet the prerequisites for this bonus feat!
                        bf.CanAcquire = !bf.IsAcquired;
                        if (bf.CanAcquire && !bf.IsAcquired)
                        {
                            Player.GetHero.BonusFeatsAvailable = false;
                            FeatRequirementCheck.AcquireTheFeat(bf);
                            learnMonkFeatButton.Enabled = false;
                            removeMonkFeatButton.Enabled = true;
                        }
                    }
                }
            }

            UpdateSaveButton();
            featCountTextBox.Text = Player.GetHero.FeatsAvailable.ToString();
            UpdateFeatsBox();
        }

        /// <summary>
        /// When the user clicks on the Monk's Remove Feat button the logic behind feat removal is ran.
        /// </summary>
        private void removeMonkFeatButton_Click(object sender, EventArgs e)
        {
            string selectedFeat = (string)bonusMonkFeatsMenuBox.SelectedItem;

            foreach (BaseFeat bf in PlayerFeats.FeatsContainer)
            {
                if (FeatInformation.GetEnumFromString(selectedFeat) == bf.FeatType)
                {
                    if (bf.IsAcquired)
                    {
                        if (Player.GetHero.BonusFeatsAvailable && ((Player.GetHero.TypeOfCharacter is Monk) || (Player.GetHero.TypeOfCharacter is Fighter)))
                        {
                            Player.GetHero.FeatsAvailable++;
                            FeatRequirementCheck.RemoveTheFeat(bf);
                            learnFeatButton.Enabled = true;
                            removeFeatButton.Enabled = false;
                        }
                        else
                        {
                            Player.GetHero.FeatsAvailable++;
                            FeatRequirementCheck.RemoveTheFeat(bf);
                            learnFeatButton.Enabled = true;
                            removeFeatButton.Enabled = false;
                        }

                        foreach (BaseFeat check in PlayerFeats.FeatsContainer)
                        {
                            FeatRequirementCheck.CheckIfFeatCanBeAcquired(Player.GetHero, check);

                            if (check.IsAcquired && !check.CanAcquire)
                            {
                                Player.GetHero.BonusFeatsAvailable = true;
                                FeatRequirementCheck.RemoveTheFeat(check);
                                learnFeatButton.Enabled = false;
                                removeFeatButton.Enabled = false;
                            }
                        }

                        break;
                    }
                }
            }

            UpdateSaveButton();
            featCountTextBox.Text = Player.GetHero.FeatsAvailable.ToString();
            UpdateFeatsBox();
        }

        #endregion
    }
}
