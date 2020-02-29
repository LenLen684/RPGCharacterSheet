using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPGCharacterManager.Models.OscarsDatabaseTestingModels;
using RPGCharacterManager.Models.User;

namespace RPGCharacterManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly Class database;

        public HomeController( Class db ) : base()
        {
            database = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult testingPage()
        {
            /*TestingModel m = new TestingModel();
            m.Id = 2;
            m.name = "OscarChan";
            m.age = 1000;
            //m.secret = enumss.b;
            //m.specialList = new List<special>();
            //special s = new special();
            //s.name = "ragnaros";
            //m.specialList.Add(s);
            database.AddAsync(m);
            //database.AddAsync<TestingModel>(m);
            database.SaveChangesAsync();
            TestingModel model = m;*/
            if ( database.Testings != null && database.Testings.Any())
            {
                return View(database.Testings);
                /*
                if ( database.Testings.Any() )
                {
                    bool o = false;
                    //if ( database.Testings.Count<TestingModel>() > 0 )
                    //{
                        //model = database.Testings.FirstOrDefault(a => a.name == "len");
                    //}
                }*/
            }
            return View();
        }

        [HttpPost]
        public IActionResult testingPage( User u )
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
