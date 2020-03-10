using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class CharacterStat
    {
        [Key]
        public int Id{get;set;}
        public int Strength {get;set}
        public int Dexterity {get;set;}
        public int Constitution {get;set;}
        public int Intelligence {get;set;}
        public int Wisdom {get;set;}
        public int Charisma { get;set; }
        public int Inspiration {get;set;}
        public int PassivePerception {get;set;}
        public int ArmorClass {get;set;}
        public int Initiative {get;set;}
        public int Speed {get;set;}
        public int MaxHP {get;set;}
        public int CurrentHP { get; set; }
        public int TempHP{get;set;}
        public int HitDie{get;set;}

        public int Proficiencie{get;set;}
    }
}
