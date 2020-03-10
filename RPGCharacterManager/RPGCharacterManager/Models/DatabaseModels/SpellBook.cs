using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class SpellBook
    {
        [Key]
        public int Id{get;set;}
        public string SpellsTotal {get;set;}
        public string SpellsRemaining {get;set;}
        public string SpellsKnown {get;set;}
    }
}
