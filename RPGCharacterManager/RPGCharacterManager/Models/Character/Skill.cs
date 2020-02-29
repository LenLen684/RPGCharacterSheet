using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public enum eModTypes
    {
        STRENGTH,
        DEXTERITY,
        CONSTITUTION,
        INTELLIGENCE,
        WISDOM,
        CHARISMA
    }

    public class Skill
    {
        public string SkillName { get; set; } = "";

        public int Bonus { get; set; }

        public bool IsProficient { get; set; } = false;

        public eModTypes Mod { get; set; }
    }
}
