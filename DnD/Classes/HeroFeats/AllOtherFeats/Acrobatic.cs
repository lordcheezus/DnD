﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Classes.CharacterClass;
using DnD.Classes.Player;
using DnD.Enums.Feats;

namespace DnD.Classes.HeroFeats
{
    public class Acrobatic : BaseFeat
    {
        /// <summary>
        /// Returns the associated <see cref="UserStrings.FeatStrings"/> description tag for the particular feat in question.
        /// </summary>
        public override string Description
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Returns the associated List of required <see cref="FeatType"/> that this particular feat requires.
        /// Null if no required <see cref="FeatType"/>.
        /// </summary>
        public override List<Enum> FeatPrerequisites
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Returns a key value pair which corresponds to KEY = <see cref="BaseCharacterClass"/> and VALUE = the level of that KEY.
        /// Null if no required KEY/VALUE pair.
        /// </summary>
        public override Dictionary<BaseCharacterClass, int> ClassLevelPrerequisites
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Returns the value of required base attack that this particular feat requires.
        /// </summary>
        public override int AttackBonusPrerequisites
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Returns the type of Feat this object is: Either Generic, ItemCreation, or MetaMagic.
        /// </summary>
        public override FeatType TypeOfFeat
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Returns true if this Feat is of type <see cref="GenericFeat"/>, false otherwise.
        /// </summary>
        public override bool IsGenericFeatType
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Returns true if this Feat is of type <see cref="ItemCreationFeat"/>, false otherwise.
        /// </summary>
        public override bool IsCreationFeatType
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Returns true if this Feat is of type <see cref="MetaMagicFeat"/>, false otherwise.
        /// </summary>
        public override bool IsMetaMagicFeatType
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Returns true if the character meets the minimum required stat restriction for the talent, or false otherwise.
        /// </summary>
        public override bool MeetsPlayerStatPrerequisites(Hero hero)
        {
            throw new NotImplementedException();
        }
    }
}
