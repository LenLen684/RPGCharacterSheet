using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class CharacterWallet
    {
        [Key]
        public int Id{get;set;}
        public int Copper {get;set;}
        public int Silver {get;set;}
        public int Electrum {get;set;}
        public int Gold {get;set;}
        public int Platinum {get;set;}
    }
}
