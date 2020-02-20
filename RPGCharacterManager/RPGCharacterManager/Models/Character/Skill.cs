using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class Skill
    {
        //Name of the skill
        public string SkillName { get; set; }

        //Proficient
        public bool IsProficient { get; set; }

        //Bonus of the skill
        public int Bonus { get; set; }
    }
}
