using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class Item
    {
        [Key]
        public int Id{get;set;}
        public string itemName {get;set;}
        public string itemDescription {get;set;}
        public int itemAmount {get;set;}
        public int Character {get;set;}
    }
}
