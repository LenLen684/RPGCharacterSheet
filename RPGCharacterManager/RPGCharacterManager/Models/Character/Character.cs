using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class Character
    {
        public static int IDCounter = 0;

        public int CharacterID { get; set; } = 0;

        //Character Basic Info
        public CharacterInfo CharInfo { get; set; }

        //Inventory
        public Inventory CharInventory { get; set; }

        //Features
        public FeatureList Features { get; set; }

        public Skills CharSkills { get; set; }

        //Saving Throws
        public SaveThrows SavingThrows { get; set; }

        //Known Spells
        public SpellBook Spells { get; set; }

        //Character's Main Stats
        public Stats CharStats { get; set; }

        //Wallet
        public Wallet CharWallet { get; set; }

        //Proficiencies
        public List<string> Proficiencies { get; set; }

        public void CreateRandomCharacter()
        {
            CharInventory = new Inventory();
            Features = new FeatureList();
            Spells = new SpellBook();
            CharWallet = new Wallet();
            Proficiencies = new List<string>();
            
            if(CharStats == null)
            {
                CharStats = new Stats();
            }
            if(CharInfo == null)
            {
                CharInfo = new CharacterInfo();
            }
            if(CharSkills == null)
            {
                CharSkills = new Skills();
            }
            if(SavingThrows == null)
            {
                SavingThrows = new SaveThrows();
            }

            CharStats.RollRandomStats();
            CharInfo.GenerateRandomCharacterInfo(this);
            CharStats.CalculateModifiers();
        }
    }
}
