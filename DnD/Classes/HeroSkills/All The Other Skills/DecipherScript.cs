﻿using DnD.Enums.ClassSkills;
using DnD.Enums.Stats;

namespace DnD.Classes.HeroSkills
{
    /// <summary>
    /// The DecipherScript Skill.
    /// </summary>
    public class DecipherScript : BaseSkill
    {
        /// <summary>
        /// Returns the type of <see cref="Stats"/> that helps boost DecipherScript.
        /// Null, if no actual stat benefits the skill.
        /// </summary>
        public override Stats? BenefitsFrom => Stats.Intellect;

        /// <summary>
        /// Returns the associated <see cref="UserStrings.FeatStrings"/> description tag for DecipherScript.
        /// </summary>  
        public override string Description => UserStrings.SkillStrings.DecipherScript;

        /// <summary>
        /// Returns the SkillType Enumeration value that represents this Skill.
        /// </summary>
        public override ClassSkills SkillType => ClassSkills.DecipherScript;
    }
}
