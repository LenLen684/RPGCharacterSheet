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

        public IActionResult Features(int id)
        {
            return View(CharacterSheetController.character);
        }

        [HttpPost]
        public IActionResult Features(Feature feature, int Id)
        {
            Feature f = CharacterSheetController.character.Features.Features.Where(f => f.Id == Id).FirstOrDefault();
            if (f != null)
            {
                f.featureName = feature.featureName;
                f.featureDescription = feature.featureDescription;
            }
            return RedirectToAction("Features", "CharacterSheet");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Feature f = CharacterSheetController.character.Features.Features.Where(f => f.Id == Id).FirstOrDefault();
            CharacterSheetController.character.Features.Features.Remove(f);
            return RedirectToAction("Features", "CharacterSheet");
        }

        public IActionResult NewFeature()
        {
            return View();
        }
    }
}
