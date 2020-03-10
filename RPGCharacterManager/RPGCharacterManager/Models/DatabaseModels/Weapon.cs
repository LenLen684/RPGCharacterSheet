using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class Weapon
    {
        [Key]
        public int Id{get;set;}
        public string WeaponName {get;set;}
        public string WeaponDescription {get;set;}
        public int eWeaponMod {get;set;}
    }
}
