using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RPGCharacterManager.Models.Character
{
    public class Spell
    {
        [Key]
        public int Id { get; set; }

        //Name of spell
        public string SpellName { get; set; }

        //Description of spell
        public string SpellDescription { get; set; }

        //Level of the spell
        public int SpellLevel { get; set; }
    }
}
