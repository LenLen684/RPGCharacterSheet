using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterSheetManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using RPGCharacterManager.Models.Character;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPGCharacterManager.Controllers
{
    public class UpdateCharacterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateSpell(int Id)
        {
            Spell spell = CharacterSheetController.character.Spells.Spells.Where(s => s.Id == Id).FirstOrDefault();
            return View(spell);
        }

        [HttpPost]
        public IActionResult UpdateSpell(Spell spell, int Id)
        {
            CharacterSheetController.character.Spells.Spells.Where(s => s.Id == Id).FirstOrDefault().SpellName = spell.SpellName;
            CharacterSheetController.character.Spells.Spells.Where(s => s.Id == Id).FirstOrDefault().SpellDescription = spell.SpellDescription;
            CharacterSheetController.character.Spells.Spells.Where(s => s.Id == Id).FirstOrDefault().SpellLevel = spell.SpellLevel;
            return RedirectToAction("Spells", "CharacterSheet");
        }

        public IActionResult UpdateWeapon(int Id)
        {
            Weapon weapon = CharacterSheetController.character.CharInventory.weapons.Where(w => w.Id == Id).FirstOrDefault();
            return View(weapon);
        }

        [HttpPost]
        public IActionResult UpdateWeapon(Weapon weapon, int Id)
        {
            CharacterSheetController.character.CharInventory.weapons.Where(w => w.Id == Id).FirstOrDefault().weaponName = weapon.weaponName;
            CharacterSheetController.character.CharInventory.weapons.Where(w => w.Id == Id).FirstOrDefault().weaponDescription = weapon.weaponDescription;
            CharacterSheetController.character.CharInventory.weapons.Where(w => w.Id == Id).FirstOrDefault().weaponMod = weapon.weaponMod;
            return RedirectToAction("Inventory", "CharacterSheet");
        }

        public IActionResult UpdateItem(int Id)
        {
            Item item = CharacterSheetController.character.CharInventory.items.Where(i => i.Id == Id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        public IActionResult UpdateItem(Item item, int Id)
        {
            CharacterSheetController.character.CharInventory.items.Where(i => i.Id == Id).FirstOrDefault().itemName = item.itemName;
            CharacterSheetController.character.CharInventory.items.Where(i => i.Id == Id).FirstOrDefault().itemDescription = item.itemDescription;
            CharacterSheetController.character.CharInventory.items.Where(i => i.Id == Id).FirstOrDefault().itemAmount = item.itemAmount;
            return RedirectToAction("Inventory", "CharacterSheet");
        }
    }
}
