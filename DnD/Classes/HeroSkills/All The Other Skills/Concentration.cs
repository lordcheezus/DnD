﻿using DnD.Enums.ClassSkills;
using DnD.Enums.Stats;

namespace DnD.Classes.HeroSkills
{
    /// <summary>
    /// The Concentration Skill.
    /// </summary>
    public class Concentration : BaseSkill
    {
        /// <summary>
        /// Returns the type of <see cref="Stats"/> that helps boost Concentration.
        /// Null, if no actual stat benefits the skill.
        /// </summary>
        public override Stats? BenefitsFrom => Stats.Constitution;

        /// <summary>
        /// Returns the associated <see cref="UserStrings.FeatStrings"/> description tag for Concentration.
        /// </summary>  
        public override string Description => UserStrings.SkillStrings.Concentration;

        /// <summary>
        /// Returns the SkillType Enumeration value that represents this Skill.
        /// </summary>
        public override ClassSkills SkillType => ClassSkills.Concentration;
    }
}
