using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class Spell
    {
        [Key]
        public int Id {get;set;}
        public string SpellName {get;set;}
        public string SpellDescription {get;set;}
        public int SpellLevel {get; set;}
    }
}
