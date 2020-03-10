using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class CharacterInfo
    {
        [Key]
        public int Id {get; set;}
        public string CharName{get;set;}
        public string Class{get;set;}
        public int Level {get;set;}

        public string Background {get;set;}
        public string PlayerName{get;set;}
        public string Race {get;set;}
        public string Alignment {get;set;}
        public int CurrentEXP{get;set;}
        public int GoalEXP {get;set;}
        public string BackgroundInfo{get;set;}
    }
}
