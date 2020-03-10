using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class BackgroundInfo
    {
        [Key]
        public int Id{get;set;}
        public string Value{get;set;}
        public int Character {get;set;}
    }
}
