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
        public CharacterInfo CharInfo { get; set; } = new CharacterInfo();

        //Inventory
        public Inventory CharInventory { get; set; } = new Inventory();

        //Features
        public FeatureList Features { get; set; } = new FeatureList();

        public Skills CharSkills { get; set; } = new Skills();

        //Saving Throws
        public SaveThrows SavingThrows { get; set; } = new SaveThrows();

        //Known Spells
        public SpellBook Spells { get; set; } = new SpellBook();

        //Character's Main Stats
        public Stats CharStats { get; set; } = new Stats();

        //Wallet
        public Wallet CharWallet { get; set; } = new Wallet();

        //Proficiencies
        public List<string> Proficiencies { get; set; } = new List<string>();

        public string ProficiencyField { get; set; }

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
