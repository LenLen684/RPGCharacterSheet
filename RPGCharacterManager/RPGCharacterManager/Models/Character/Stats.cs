using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public enum eHitDice
    {
        D4,
        D6,
        D8,
        D10,
        D12,
        D20,
        D100
    }

    public class Stats
    {
        #region BaseStats
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        #endregion

        #region Modifiers
        public int StrengthMod { get; set; }
        public int DexterityMod { get; set; }
        public int ConstitutionMod { get; set; }
        public int IntelligenceMod { get; set; }
        public int WisdomMod { get; set; }
        public int CharismaMod { get; set; }
        #endregion

        #region MiscStats
        public int Inspiration { get; set; }
        public int PassivePerception { get; set; }

        public int ArmorClass { get; set; }

        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }

        public eHitDice HitDie { get; set; }
        #endregion
    }
}
