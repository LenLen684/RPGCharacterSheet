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
                CharName = "Ruby",
                Class = "Sorcerer",
                Level = 3,
                Background = "Unknown",
                PlayerName = "Lane",
                Race = "Flintspark Goblin",
                Alignment = "Chaotic Neutral",
                CurrentEXP = 0,
                GoalEXP = 350,
                BackgroundInfo = new List<string>() { "Loves fire", "Fire", "A lot of fire", "Is easily distracted by fire" }
            },
            CharInventory = new Inventory()
            {
                items = new List<Item>()
                {
                    new Item() { itemName = "Red Gem", itemAmount = 20, itemDescription = "A basic red gem" },
                    new Item() { itemName = "Yellow Gem", itemAmount = 10, itemDescription = "A basic yellow gem" }
                },
                weapons = new List<Weapon>()
                {
                    new Weapon() { weaponName = "Spiked Gauntlet", weaponDescription = "A gauntlet with spikes", weaponMod = eWeaponMod.STRENGTH },
                    new Weapon() { weaponName = "Torch", weaponDescription = "A basic torch", weaponMod = eWeaponMod.STRENGTH }
                }
            },
            Features = new FeatureList() {
                Features = new List<Feature>()
                { 
                    new Feature(){featureName = "Dark Vision", featureDescription = "See up to 60 ft in the dark"},
                    new Feature(){featureName = "Never Learning Always Burning", featureDescription = "Use charisma instead of wisdom on class features"}
                }
            },
            SavingThrows = new SaveThrows() { },
            Spells = new SpellBook()
            {
                Spells = new List<Spell>()
                {
                    new Spell() { SpellName = "Burning Hands", SpellDescription = "Hands burn", SpellLevel = 0 },
                    new Spell() { SpellName = "Detect Magic", SpellDescription = "Find magic if any", SpellLevel = 0 },
                    new Spell() { SpellName = "Fireball", SpellDescription = "Big fire", SpellLevel = 1 }
                },
                SpellSlotsTotal = new int[9] { 6, 6, 0, 0, 0, 0, 0, 0, 0 },
                SpellSlotsRemaining = new int[9] { 5, 3, 0, 0, 0, 0, 0, 0, 0 },
                SpellSaveDC = 11,
                SpellAttackBonus = 6,
                SpellCastingAbility = eCastingAbility.CHARISMA
            },
            CharStats = new Stats()
            {
                Strength = 11,
                Dexterity = 13,
                Constitution = 11,
                Intelligence = 11,
                Wisdom = 12,
                Charisma = 16,
                StrengthMod = 0,
                DexterityMod = 1,
                ConstitutionMod = 0,
                IntelligenceMod = 0,
                WisdomMod = 1,
                CharismaMod = 3,
                Inspiration = 0,
                PassivePerception = 1,
                ArmorClass = 12,
                Initiative = 1,
                Speed = 30,
                MaxHP = 14,
                CurrentHP = 12,
                TempHP = 0,
                HitDie = eHitDice.D6,
                DeathSaveRolls = new DeathSaves()
            },
            CharWallet = new Wallet() { copper = 7, silver = 12, gold = 50, electrum = 0, platinum = 0 },
            Proficiencies = new List<string>() { "Common", "Ignus", "Goblin", "Torches", "Fire attacks" },
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