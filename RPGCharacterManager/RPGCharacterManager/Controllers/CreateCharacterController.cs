using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CharacterSheetManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using RPGCharacterManager.Models.Character;
using RPGCharacterManager.Models.DatabaseContexts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPGCharacterManager.Controllers
{
    public class CreateCharacterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Features()
        {
            Character c = new Character();
            return View(c);
        }

        [HttpPost]
        public IActionResult Features(Character c)
        {
            c.Features = new FeatureList();
            return RedirectToAction("Features", "CharacterSheet");
        }

        public IActionResult Inventory()
        {
            Character c = new Character();
            c.CharWallet = new Wallet();
            c.CharInventory = new Inventory();
            c.CharInventory.itemField = new Item();
            c.CharInventory.weaponField = new Weapon();
            return View();
        }

        [HttpPost]
        public IActionResult Inventory(Character c)
        {
            CharacterSheetController.character.CharWallet = c.CharWallet;

            //Set static character information in main page to display new information
            //CharacterSheetController.character.CharInventory = new Inventory();
            //CharacterSheetController.character.CharInventory.AddItem(c.CharInventory.itemField.itemName, c.CharInventory.itemField.itemDescription, c.CharInventory.itemField.itemAmount);
            CharacterSheetController.character.CharInventory.items.Add(c.CharInventory.itemField);
            CharacterSheetController.character.CharInventory.weapons.Add(c.CharInventory.weaponField);
            return RedirectToAction("Inventory", "CharacterSheet");
        }

        public IActionResult CharacterInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CharacterInfo(Character character)
        {
            if (ModelState.IsValid)
            {
                character.CharStats.DeathSaveRolls = new DeathSaves();

                CharacterSheetController.character.CharInfo = character.CharInfo;
                CharacterSheetController.character.CharStats = character.CharStats;
                return RedirectToAction("CharacterInfo", "CharacterSheet");
            }
            else
            {
                return View();
            }
        }

        

    }
}
