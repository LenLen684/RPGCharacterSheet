using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class Inventory
    {
        public List<Item> items { get; set; }

        public List<Weapon> weapons { get; set; }

    }
}
