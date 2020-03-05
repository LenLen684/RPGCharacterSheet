using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RPGCharacterManager.Models.Character
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public uint itemAmount { get; set; }

    }
}
