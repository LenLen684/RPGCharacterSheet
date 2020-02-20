using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class Spell
    {
        //Name of spell
        public string SpellName { get; set; }

        //Description of spell
        public string SpellDescription { get; set; }

        //Level of the spell
        public int SpellLevel { get; set; }
    }
}
