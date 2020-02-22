using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public enum eCastingAbility
    {
        STRENGTH,
        DEXTERITY,
        CONSTITUTION,
        INTELLIGENCE,
        WISDOM,
        CHARISMA
    }

    public class SpellBook
    {
        //List of known spells
        public List<Spell> Spells { get; set; }

        //Total number of spell slots available
        public int[] SpellSlotsTotal { get; set; } = new int[9];

        //Number of spell slots available for use
        public int[] SpellSlotsRemaining { get; set; } = new int[9];

        public int SpellSaveDC { get; set; }

        public int SpellAttackBonus { get; set; }

        public eCastingAbility SpellCastingAbility { get; set; }
    }
}