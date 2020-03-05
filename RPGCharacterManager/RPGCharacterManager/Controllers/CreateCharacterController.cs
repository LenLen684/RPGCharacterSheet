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
            c.Features = new FeatureList();
            c.Features.FeatureField = new Feature();
            return View(c);
        }

        [HttpPost]
        public IActionResult Features(Character c)
        {
            CharacterSheetController.character.Features.AddFeature(c.Features.FeatureField.featureName, c.Features.FeatureField.featureDescription);
            CharacterSheetController.character.Proficiencies.Add(c.ProficiencyField);
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

        

        public IActionResult Spells()
        {
            Character c = new Character();
            c.Spells = new SpellBook();
            c.Spells.SpellField = new Spell();
            return View(c);
        }

        [HttpPost]
        public IActionResult Spells(Character c)
        {
            CharacterSheetController.character.Spells.AddSpell(c.Spells.SpellField.SpellName, c.Spells.SpellField.SpellDescription, c.Spells.SpellField.SpellLevel);
            return RedirectToAction("Spells", "CharacterSheet");
        }

        public IActionResult Skills()
        {
            Character c = new Character();
            c.CharSkills = new Skills();
            return View(c);
        }

        [HttpPost]
        public IActionResult Skills(Character c)
        {
            for(int i = 0; i < CharacterSheetController.character.CharSkills.CharSkills.Length; i++)
            {
                CharacterSheetController.character.CharSkills.CharSkills[i].IsProficient = c.CharSkills.CharSkills[i].IsProficient;
                CharacterSheetController.character.CharSkills.CharSkills[i].Bonus = c.CharSkills.CharSkills[i].Bonus;
            }
            return RedirectToAction("Skills", "CharacterSheet");
        }
    }
}
