﻿using DnD.Classes.CharacterClass;
using DnD.Classes.Player;
using DnD.Enums.Feats;
using System;
using System.Collections.Generic;

namespace DnD.Classes.HeroFeats
{
    /// <summary>
    /// The Base Feat class is an abstract entity which satisfies the required generic prerequisites for any type of feat.
    /// Whether it be a list of Feat type enums, Particular character class levels, or minimum stat requirements.
    /// Also supports a description of the feat.
    /// </summary>
    public abstract class BaseFeat
    {
        /// <summary>
        /// Returns the associated <see cref="UserStrings.FeatStrings"/> description tag for the particular feat in question.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Returns the associated List of required <see cref="FeatType"/> that this particular feat requires.
        /// Null if no required <see cref="FeatType"/>.
        /// </summary>
        public abstract List<Enum> FeatPrerequisites { get; }

        /// <summary>
        /// Returns a key value pair which corresponds to KEY = <see cref="BaseCharacterClass"/> and VALUE = the level of that KEY.
        /// Null if no required KEY/VALUE pair.
        /// </summary>
        public abstract Dictionary<BaseCharacterClass, int> ClassLevelPrerequisites { get; }

        /// <summary>
        /// Returns the value of required base attack that this particular feat requires.
        /// </summary>
        public abstract int AttackBonusPrerequisites { get; }

        /// <summary>
        /// Returns the type of Feat this object is: Either Generic, ItemCreation, or MetaMagic.
        /// </summary>
        public abstract FeatType TypeOfFeat { get; }

        /// <summary>
        /// Returns true if this Feat is of type <see cref="GenericFeat"/>, false otherwise.
        /// </summary>
        public abstract bool IsGenericFeatType { get; }

        /// <summary>
        /// Returns true if this Feat is of type <see cref="ItemCreationFeat"/>, false otherwise.
        /// </summary>
        public abstract bool IsCreationFeatType { get; }

        /// <summary>
        /// Returns true if this Feat is of type <see cref="MetaMagicFeat"/>, false otherwise.
        /// </summary>
        public abstract bool IsMetaMagicFeatType { get; }

        /// <summary>
        /// Returns true if the character meets the minimum required stat restriction for the talent, or false otherwise.
        /// </summary>
        public abstract bool MeetsPlayerStatPrerequisites(Hero hero);
    }
}
