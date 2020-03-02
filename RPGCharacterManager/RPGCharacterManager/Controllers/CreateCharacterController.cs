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
            return View(c);
        }

        [HttpPost]
        public IActionResult Inventory(Character c)
        {
            ////Reset all of character's field to ensure they're not null
            //c.CharWallet = new Wallet();
            //c.CharInventory = new Inventory();
            //c.CharInventory.itemField = new Item();
            //c.CharInventory.weaponField = new Weapon();

            //Store item to reduce clutter
            Item item = c.CharInventory.itemField;
            c.CharInventory.AddItem(item.itemName, item.itemDescription, item.itemAmount);

            //Set static character information in main page to display new information
            CharacterSheetController.character.CharInventory = c.CharInventory;
            CharacterSheetController.character.CharWallet = c.CharWallet;
            return RedirectToAction("Inventory", "CharacterSheet");
        }

    }
}