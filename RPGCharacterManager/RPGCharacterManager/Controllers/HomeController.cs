using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPGCharacterManager.Models.OscarsDatabaseTestingModels;
using RPGCharacterManager.Models.User;
using RPGCharacterManager.Models.Character;
using RPGCharacterManager.Models.DatabaseContexts;

namespace RPGCharacterManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersDataContext database;

        public HomeController( UsersDataContext db ) : base()
        {
            database = db;
        }

        static User user = new User()
        {
            UserId = 0,
            Username = "TestUser",
            Email = "MyTeamName@Mailinator.com",
            Password = "Password!",
            /*Characters = new List<Character>()
            {
                new Character(),
                new Character(),
                new Character()
            }*/
        };

        public IActionResult Index()
        {
            return View(UsersDataContext.currentUser);
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
            if ( database.Users != null && database.Users.Any())
            {
                return View(database.Users);
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

        public IActionResult Login(string username, string password)
        {
            username = username.ToLower();
            bool InDatabase = false;
            bool IsUsername = username.Contains("@"); // Hey cowboy, get the users table by saying database.Users, It returns an Ienumerable<User> so it's a list of users, do as you please with it, ask oscar how to edit the database'
            if (IsUsername)
            {
                foreach ( User user in database.Users )
                {
                    if ( user.Email.Equals(username) )
                    {
                        InDatabase = true;
                        break;
                    }
                }
                //InDatabase = Check database for emails that are similar
            }
            else
            {
                foreach ( User user in database.Users )
                {
                    if ( user.Username.Equals(username) )
                    {
                        InDatabase = true;
                        break;
                    }
                }
                //InDatabase = Check for usernames in the database
            }

            if ( InDatabase )
            {
                User u = database.Users.FirstOrDefault(u => u.Username.Equals(username));
                if ( u.Password.Equals(password) )
                {
                    UsersDataContext.currentUser = u;
                    return View("Index", u);
                }
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

            return RedirectToAction("Index",UsersDataContext.currentUser);
        }

        
        public IActionResult SignUp(string email, string username, string password, string passwordverification)
        {
            if ( password.Equals(passwordverification) )
            {
                User u = new User();
                u.Username = username;
                u.Email = email;
                u.Password = password;
                u.UserId = database.Users.Count() + 2;
                database.Users.AddAsync(u);
                database.SaveChangesAsync();
                UsersDataContext.currentUser = u;
                return View("Index", u);
            }
            else
            {
                return View("Index");
            }
            return RedirectToAction("Characters");
        }

        public IActionResult Characters()
        {
            /*
            foreach(Character c in user.Characters)
            {
                c.CreateRandomCharacter();
                c.CharacterID = Character.IDCounter++;
            }*/

            return View(user);
        }
    }
}
