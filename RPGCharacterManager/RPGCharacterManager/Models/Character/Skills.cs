using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public enum eSkill
    {
        ACROBATICS,
        ANIMALHANDLING,
        ARCANA,
        ATHLETICS,
        DECEPTION,
        HISTORY,
        INSIGHT,
        INTIMIDATION,
        INVESTIGATION,
        MEDICINE,
        NATURE,
        PERCEPTION,
        PERFORMANCE,
        PERSUASION,
        RELIGION,
        SLEIGHTOFHAND,
        STEALTH,
        SURVIVAL
    }

    public class Skills
    {
        [Key]
        public int Id {get; set;}
        //Initialize skills
        public Skill[] CharSkills { get; set; } = new Skill[18]
        { 
            new Skill() { SkillName="Acrobatics", Bonus = 0, IsProficient = false, Mod = eModTypes.DEXTERITY},
            new Skill() { SkillName="Animal Handling", Bonus = 0, IsProficient = false, Mod = eModTypes.WISDOM },
            new Skill() { SkillName="Arcana", Bonus = 0, IsProficient = false, Mod = eModTypes.INTELLIGENCE },
            new Skill() { SkillName="Athletics", Bonus = 0, IsProficient = false, Mod = eModTypes.STRENGTH },
            new Skill() { SkillName="Deception", Bonus = 0, IsProficient = false, Mod = eModTypes.CHARISMA },
            new Skill() { SkillName="History", Bonus = 0, IsProficient = false, Mod = eModTypes.INTELLIGENCE },
            new Skill() { SkillName="Insight", Bonus = 0, IsProficient = false, Mod = eModTypes.WISDOM },
            new Skill() { SkillName="Intimidation", Bonus = 0, IsProficient = false, Mod = eModTypes.CHARISMA },
            new Skill() { SkillName="Investigation", Bonus = 0, IsProficient = false, Mod = eModTypes.INTELLIGENCE },
            new Skill() { SkillName="Medicine", Bonus = 0, IsProficient = false, Mod = eModTypes.WISDOM },
            new Skill() { SkillName="Nature", Bonus = 0, IsProficient = false, Mod = eModTypes.INTELLIGENCE },
            new Skill() { SkillName="Perception", Bonus = 0, IsProficient = false, Mod = eModTypes.WISDOM },
            new Skill() { SkillName="Performance", Bonus = 0, IsProficient = false, Mod = eModTypes.CHARISMA },
            new Skill() { SkillName="Persuassion", Bonus = 0, IsProficient = false, Mod = eModTypes.CHARISMA },
            new Skill() { SkillName="Religion", Bonus = 0, IsProficient = false, Mod = eModTypes.INTELLIGENCE },
            new Skill() { SkillName="Sleight of Hand", Bonus = 0, IsProficient = false, Mod = eModTypes.DEXTERITY },
            new Skill() { SkillName="Stealth", Bonus = 0, IsProficient = false, Mod = eModTypes.DEXTERITY },
            new Skill() { SkillName="Survival", Bonus = 0, IsProficient = false, Mod = eModTypes.WISDOM }
        };

        public void CalculateSkillModifiers(Character character)
        {
            //Evaluate each skill's modifier type and set it's modifier
            for (int i = 0; i < CharSkills.Length; i++)
            {
                int modifier = 0;
                switch (CharSkills[i].Mod)
                {
                    case eModTypes.STRENGTH:
                        modifier = character.CharStats.StrengthMod;
                        break;
                    case eModTypes.DEXTERITY:
                        modifier = character.CharStats.DexterityMod;
                        break;
                    case eModTypes.CONSTITUTION:
                        modifier = character.CharStats.ConstitutionMod;
                        break;
                    case eModTypes.INTELLIGENCE:
                        modifier = character.CharStats.IntelligenceMod;
                        break;
                    case eModTypes.WISDOM:
                        modifier = character.CharStats.WisdomMod;
                        break;
                    case eModTypes.CHARISMA:
                        modifier = character.CharStats.CharismaMod;
                        break;
                }
                CharSkills[i].Bonus += (CharSkills[0].IsProficient) ? modifier + character.CharStats.Proficiency : modifier;
            }
        }
        public void SetSkill(Skill skill)
        {
            for(int i = 0; i < CharSkills.Length; i++)
            {
                if(CharSkills[i].SkillName == skill.SkillName)
                {
                    CharSkills[i].Mod = skill.Mod;
                    CharSkills[i].Bonus = skill.Bonus;
                    CharSkills[i].IsProficient = skill.IsProficient;
                }
            }
        }
    }
}
