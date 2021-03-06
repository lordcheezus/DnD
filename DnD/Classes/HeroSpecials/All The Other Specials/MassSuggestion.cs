﻿using DnD.Enums.ClassSpecials;

namespace DnD.Classes.HeroSpecials
{
    /// <summary>
    /// The MassSuggestion Special.
    /// </summary>
    public class MassSuggestion : BaseSpecial
    {
        /// <summary>
        /// The minimum class level required for the ability to acquire MassSuggestion.
        /// </summary>
        public override int? MinimumLevelRequirement => 18;

        /// <summary>
        /// The associated Description tag for the string, found within the respective UserStrings files.
        /// </summary>
        public override string Description => UserStrings.SpecialStrings.MassSuggestion;

        /// <summary>
        /// Returns the ClassSpecial Enumeration type represented by this Special.
        /// </summary>
        public override ClassSpecial SpecialType => ClassSpecial.MassSuggestion;
    }
}
