﻿using DnD.Enums.ClassSpecials;

namespace DnD.Classes.HeroSpecials
{
    /// <summary>
    /// The DetectEvil Special.
    /// </summary>
    public class DetectEvil : BaseSpecial
    {
        /// <summary>
        /// The minimum class level required for the ability to acquire DetectEvil.
        /// </summary>
        public override int? MinimumLevelRequirement => 1;

        /// <summary>
        /// The associated Description tag for the string, found within the respective UserStrings files.
        /// </summary>
        public override string Description => UserStrings.SpecialStrings.DetectEvil;

        /// <summary>
        /// Returns the ClassSpecial Enumeration type represented by this Special.
        /// </summary>
        public override ClassSpecial SpecialType => ClassSpecial.DetectEvil;
    }
}
