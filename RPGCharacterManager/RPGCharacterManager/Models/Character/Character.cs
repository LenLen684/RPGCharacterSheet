using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class Character
    {
        public CharacterInfo CharInfo { get; set; }

        //Inventory
        public Inventory CharInventory { get; set; }

        //Features
        public List<Feature> Features { get; set; }

        //Saving Throws
        public SaveThrows SavingThrows { get; set; }

        public SpellBook Spells { get; set; }

        public Stats CharStats { get; set; }

        //Wallet
        public Wallet CharWallet { get; set; }

        public List<string> Proficiencies { get; set; }
    }
}
