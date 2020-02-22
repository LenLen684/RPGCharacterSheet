using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public enum eWeaponMod
    {
        STRENGTH,
        DEXTERITY,
        CONSTITUTION,
        INTELLIGENCE,
        WISDOM,
        CHARISMA
    }
    public class Weapon
    {
        public string weaponName { get; set; }
        public string weaponDescription { get; set; }
        public eWeaponMod weaponMod { get; set; }
    }
}
