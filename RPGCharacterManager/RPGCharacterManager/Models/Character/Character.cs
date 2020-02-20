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

        //Features

        //Saving Throws

        public SpellBook Spells { get; set; }

        public Stats CharacterStats { get; set; }

        //Wallet

        public List<string> Proficiencies { get; set; }
    }
}
