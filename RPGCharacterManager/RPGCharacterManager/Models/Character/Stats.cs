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

        public void RollRandomStats()
        {
            Random rand = new Random();
            Strength = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
            Dexterity = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
            Constitution = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
            Intelligence = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
            Wisdom = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
            Charisma = (rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7));
        }

        #region Modifiers
        public int StrengthMod { get; set; }
        public int DexterityMod { get; set; }
        public int ConstitutionMod { get; set; }
        public int IntelligenceMod { get; set; }
        public int WisdomMod { get; set; }
        public int CharismaMod { get; set; }
        #endregion

        public void CalculateModifiers()
        {
            StrengthMod = (Strength - 10) / 2;
            DexterityMod = (Dexterity - 10) / 2;
            ConstitutionMod = (Constitution - 10) / 2;
            IntelligenceMod = (Intelligence - 10) / 2;
            WisdomMod = (Wisdom - 10) / 2;
            CharismaMod = (Charisma - 10) / 2;
        }

        #region MiscStats
        public int Inspiration { get; set; }
        public int PassivePerception { get; set; }

        public int Proficiency { get; set; }

        public int ArmorClass { get; set; }

        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }

        public eHitDice HitDie { get; set; }
        #endregion
    }
}
