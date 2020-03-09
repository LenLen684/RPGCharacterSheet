using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public enum eCastingAbility
    {
        NONE,
        STRENGTH,
        DEXTERITY,
        CONSTITUTION,
        INTELLIGENCE,
        WISDOM,
        CHARISMA
    }

    public class SpellBook
    {
        //Temporary spell for creation
        public Spell SpellField { get; set; } = new Spell();

        //List of known spells
        public List<Spell> Spells { get; set; } = new List<Spell>();

        //Total number of spell slots available
        public int[] SpellSlotsTotal { get; set; } = new int[9];

        //Number of spell slots available for use
        public int[] SpellSlotsRemaining { get; set; } = new int[9];

        public int SpellSaveDC { get; set; } = 0;

        public int SpellAttackBonus { get; set; } = 0;

        public eCastingAbility SpellCastingAbility { get; set; } = eCastingAbility.NONE;

        public void AddSpell(string spellName, string spellDescription, int spellLevel)
        {
            Spell spell = new Spell();
            spell.SpellName = spellName;
            spell.SpellDescription = spellDescription;
            spell.SpellLevel = spellLevel;
            Spells.Add(spell);
        }

        public void CalculateSpellcastingInfo(Character character)
        {
            switch (character.CharInfo.Class)
            {
                case "Barbarian":
                    SpellCastingAbility = eCastingAbility.NONE;
                    break;
                case "Bard":
                    SpellCastingAbility = eCastingAbility.CHARISMA;
                    break;
                case "Cleric":
                    SpellCastingAbility = eCastingAbility.WISDOM;
                    break;
                case "Druid":
                    SpellCastingAbility = eCastingAbility.WISDOM;
                    break;
                case "Fighter":
                    SpellCastingAbility = eCastingAbility.INTELLIGENCE;
                    break;
                case "Monk":
                    SpellCastingAbility = eCastingAbility.WISDOM;
                    break;
                case "Paladin":
                    SpellCastingAbility = eCastingAbility.CHARISMA;
                    break;
                case "Ranger":
                    SpellCastingAbility = eCastingAbility.WISDOM;
                    break;
                case "Rogue":
                    SpellCastingAbility = eCastingAbility.INTELLIGENCE;
                    break;
                case "Sorcerer":
                    SpellCastingAbility = eCastingAbility.CHARISMA;
                    break;
                case "Warlock":
                    SpellCastingAbility = eCastingAbility.CHARISMA;
                    break;
                case "Wizard":
                    SpellCastingAbility = eCastingAbility.INTELLIGENCE;
                    break;
                default:
                    break;
            }

            switch (SpellCastingAbility)
            {
                case eCastingAbility.NONE:
                    SpellAttackBonus = 0;
                    break;
                case eCastingAbility.STRENGTH:
                    SpellAttackBonus = character.CharStats.StrengthMod + character.CharStats.Proficiency;
                    break;
                case eCastingAbility.DEXTERITY:
                    SpellAttackBonus = character.CharStats.DexterityMod + character.CharStats.Proficiency;
                    break;
                case eCastingAbility.CONSTITUTION:
                    SpellAttackBonus = character.CharStats.ConstitutionMod + character.CharStats.Proficiency;
                    break;
                case eCastingAbility.INTELLIGENCE:
                    SpellAttackBonus = character.CharStats.IntelligenceMod + character.CharStats.Proficiency;
                    break;
                case eCastingAbility.WISDOM:
                    SpellAttackBonus = character.CharStats.WisdomMod + character.CharStats.Proficiency;
                    break;
                case eCastingAbility.CHARISMA:
                    SpellAttackBonus = character.CharStats.CharismaMod + character.CharStats.Proficiency;
                    break;
            }

            switch (SpellCastingAbility)
            {
                case eCastingAbility.NONE:
                    SpellSaveDC = 0;
                    break;
                case eCastingAbility.STRENGTH:
                    SpellSaveDC = 8 + character.CharStats.Proficiency + character.CharStats.StrengthMod;
                    break;
                case eCastingAbility.DEXTERITY:
                    SpellSaveDC = 8 + character.CharStats.Proficiency + character.CharStats.DexterityMod;
                    break;
                case eCastingAbility.CONSTITUTION:
                    SpellSaveDC = 8 + character.CharStats.Proficiency + character.CharStats.ConstitutionMod;
                    break;
                case eCastingAbility.INTELLIGENCE:
                    SpellSaveDC = 8 + character.CharStats.Proficiency + character.CharStats.IntelligenceMod;
                    break;
                case eCastingAbility.WISDOM:
                    SpellSaveDC = 8 + character.CharStats.Proficiency + character.CharStats.WisdomMod;
                    break;
                case eCastingAbility.CHARISMA:
                    SpellSaveDC = 8 + character.CharStats.Proficiency + character.CharStats.CharismaMod;
                    break;
            }
        }
    }
}