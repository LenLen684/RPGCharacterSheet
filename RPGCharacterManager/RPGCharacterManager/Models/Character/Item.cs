using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class Item
    {
        public string itemName { get; set; } = "";
        public string itemDescription { get; set; } = "";
        public uint itemAmount { get; set; } = 0;

    }
}
