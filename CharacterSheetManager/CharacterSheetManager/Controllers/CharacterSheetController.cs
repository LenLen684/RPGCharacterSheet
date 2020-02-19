using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CharacterSheetManager.Controllers
{
    public class CharacterSheetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}