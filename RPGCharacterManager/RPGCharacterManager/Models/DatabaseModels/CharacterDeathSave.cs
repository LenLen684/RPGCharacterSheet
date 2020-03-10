using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class CharacterDeathSave
    {
        [Key]
        public int Id{get;set;}
        public int Success {get;set;}
        public int Fails {get;set;}
        public int Character {get;set;}
    }
}