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

        public void AddWeapon(string weaponName, string weaponDescription, eWeaponMod weaponMod)
        {
            Weapon weapon = new Weapon();
            weapon.weaponName = weaponName;
            weapon.weaponDescription = weaponDescription;
            weapon.weaponMod = weaponMod;
            weapons.Add(weapon);
        }

        public void AddItem(string itemName, string itemDescription, uint itemAmount)
        {
            Item item = new Item();
            item.itemName = itemName;
            item.itemDescription = itemDescription;
            item.itemAmount = itemAmount;
            items.Add(item);
        }
    }
}
