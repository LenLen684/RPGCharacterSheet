using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RPGCharacterManager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn(string username, string password)
        {
            bool InDatabase = false;
            bool IsUsername = username.Contains("@");
            if (IsUsername)
            {
                //InDatabase = Check database for emails that are similar
            }
            else
            {
                //InDatabase = Check for usernames in the database
            }
            /*
             * if(InDatabase)
             * {    
             *       if(IsUsername){
             *          if(--Check if password matches username--)
             *          {
             *              return RedirectToAction("Characters", --UserID--);
             *          } else {
             *              break;
             *          }
             *       }
             *       else
             *       {
             *          if(--Check if password matches email--)
             *          {
             *              return RedirectToAction("Characters", --UserID--);
             *          } else {
             *              break;
             *          }
             *       }
             * } 
             * else
             * {
             * 
             * }
             */

            return RedirectToAction("Index");
        }

        public IActionResult SignUp(string email, string username, string password, string passwordverification)
        {
            return RedirectToAction("Characters");
        }
    }
}
