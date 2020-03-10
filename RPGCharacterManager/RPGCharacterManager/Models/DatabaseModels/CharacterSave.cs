using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class CharacterSave
    {
        [Key]
        public int Id {get;set;}
        public bool Strength {get;set;}
        public bool Dexterity {get;set;}
        public bool Constitution {get;set;}
        public bool Intelligence {get;set;}
        public bool Wisdom {get;set;}
        public bool Charisma {get;set;}
    }
}
