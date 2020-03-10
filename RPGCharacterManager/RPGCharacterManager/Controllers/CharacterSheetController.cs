using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPGCharacterManager.Models.Character;

namespace CharacterSheetManager.Controllers
{
    public class CharacterSheetController : Controller
    {
        //Testing character
        public static Character character = new Character()
        {
            CharInfo = new CharacterInfo()
            {
                CharName = "",
                Class = "",
                Level = 1,
                Background = "",
                PlayerName = "",
                Race = "",
                Alignment = "",
                CurrentEXP = 0,
                GoalEXP = 350,
                BackgroundInfo = new List<string>() { "", "", "", "" }
            },
            CharInventory = new Inventory()
            {
                items = new List<Item>(),
                weapons = new List<Weapon>()
            },
            Features = new FeatureList(),
            SavingThrows = new SaveThrows() { },
            Spells = new SpellBook()
            {
                Spells = new List<Spell>(),
                SpellSlotsTotal = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                SpellSlotsRemaining = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                SpellSaveDC = 0,
                SpellAttackBonus = 0,
                SpellCastingAbility = eCastingAbility.NONE
            },
            CharStats = new Stats()
            {
                Strength = 0,
                Dexterity = 0,
                Constitution = 0,
                Intelligence = 0,
                Wisdom = 0,
                Charisma = 0,
                StrengthMod = 0,
                DexterityMod = 0,
                ConstitutionMod = 0,
                IntelligenceMod = 0,
                WisdomMod = 0,
                CharismaMod = 0,
                Inspiration = 0,
                PassivePerception = 0,
                ArmorClass = 0,
                Initiative = 0,
                Speed = 0,
                MaxHP = 0,
                CurrentHP = 0,
                TempHP = 0,
                HitDie = eHitDice.D6,
                DeathSaveRolls = new DeathSaves()
            },
            CharWallet = new Wallet() { copper = 0, silver = 0, gold = 0, electrum = 0, platinum = 0 },
            Proficiencies = new List<string>(),
            CharSkills = new Skills()
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CharacterInfo()
        {
            //character.CreateRandomCharacter();
            return View(character);
        }

        public IActionResult Features()
        {
            return View(character);
        }

        public IActionResult Inventory()
        {
            return View(character);
        }

        public IActionResult Skills()
        {
            return View(character);
        }

        public IActionResult Spells()
        {
            return View(character);
        }

        public IActionResult RollForm()
        {
            int[] rolls = new int[3] { 0, 0, 0 };

            return View(rolls);
        }

        [HttpPost]
        public IActionResult RollForm(int[] rolls)
        {
            bool tooLarge = false;
            foreach(int i in rolls)
            {
                if(i > 9999)
                {
                    tooLarge = true;
                }
            }
            if (!tooLarge)
            {
                rolls.ToList();
                return RedirectToAction("RollSum", "CharacterSheet", new { rolls = rolls });
            }
            else
            {
                return RedirectToAction("RollForm", "CharacterSheet");
            }
        }

        public IActionResult RollSum(List<int> rolls)
        {
            return View(rolls);
        }

        [HttpPost]
        public IActionResult DeleteSpell(int Id)
        {
            character.Spells.Spells.Remove(character.Spells.Spells.Where(s => s.Id == Id).FirstOrDefault());
            return RedirectToAction("Spells", "CharacterSheet");
        }










        public IActionResult AddSucc()
        {
            CharacterSheetController.character.CharStats.DeathSaveRolls.AddSuccessfulSave();

            return RedirectToAction("CharacterInfo", "CharacterSheet");
        }

        public IActionResult RemoveSucc()
        {
            CharacterSheetController.character.CharStats.DeathSaveRolls.RemoveSuccessfulSave();

            return RedirectToAction("CharacterInfo", "CharacterSheet");
        }

        public IActionResult ClearSucc()
        {
            CharacterSheetController.character.CharStats.DeathSaveRolls.ResetSuccessfulSaves();

            return RedirectToAction("CharacterInfo", "CharacterSheet");
        }

        public IActionResult AddFail()
        {
            CharacterSheetController.character.CharStats.DeathSaveRolls.AddFailedSave();

            return RedirectToAction("CharacterInfo", "CharacterSheet");
        }

        public IActionResult RemoveFail()
        {
            CharacterSheetController.character.CharStats.DeathSaveRolls.RemoveFailedSave();

            return RedirectToAction("CharacterInfo", "CharacterSheet");
        }

        public IActionResult ClearFail()
        {
            CharacterSheetController.character.CharStats.DeathSaveRolls.ResetFailedSaves();

            return RedirectToAction("CharacterInfo", "CharacterSheet");
        }
    }
}