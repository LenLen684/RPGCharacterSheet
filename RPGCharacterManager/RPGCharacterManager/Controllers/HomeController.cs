﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPGCharacterManager.Models.OscarsDatabaseTestingModels;
using RPGCharacterManager.Models.User;
using Microsoft.AspNetCore.Http;
using RPGCharacterManager.Models.Character;
using RPGCharacterManager.Models.DatabaseContexts;
using BCrypt.Net;
using System.Text;

namespace RPGCharacterManager.Controllers
{
    public class HomeController : Controller
    {

        private Random rng = new Random();
        private readonly UsersDataContext database;
        //private string contextCookie = 

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
            //Cookie example
            HttpContext.Response.Cookies.Append("test_1", "Hi there");
            HttpContext.Session.TryGetValue("UserID", out byte[] id);
            if(id != null && id.Length != 0)
            {
                return View(database.Users.FirstOrDefault(u => u.UserId.ToString().Equals((Encoding.UTF8.GetString(id)))));
            }
            return View(null);
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
            //if ( database.Users != null && database.Users.Any())
            //{
            //    return View(database.Users);
            //    /*
            //    if ( database.Testings.Any() )
            //    {
            //        bool o = false;
            //        //if ( database.Testings.Count<TestingModel>() > 0 )
            //        //{
            //            //model = database.Testings.FirstOrDefault(a => a.name == "len");
            //        //}
            //    }*/
            //}
            return View(database.Users);
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
            bool IsEmail = username.Contains("@"); // Hey cowboy, get the users table by saying database.Users, It returns an Ienumerable<User> so it's a list of users, do as you please with it, ask oscar how to edit the database'
            if (IsEmail)
            {
                //InDatabase = Check database for emails that are similar
                foreach ( User user in database.Users )
                {
                    if ( user.Email.Equals(username) )
                    {
                        InDatabase = true;
                        break;
                    }
                }
            }
            else
            {
                //InDatabase = Check for usernames in the database
                foreach ( User user in database.Users )
                {
                    if ( user.Username.Equals(username) )
                    {
                        InDatabase = true;
                        break;
                    }
                }
            }

            if ( InDatabase )
            {
                User u = IsEmail? database.Users.FirstOrDefault(u => u.Email.Equals(username)) : database.Users.FirstOrDefault(u => u.Username.Equals(username));
                if ( BCrypt.Net.BCrypt.Verify(password, u.Password))
                {
                    if (HttpContext.Session.IsAvailable)
                    {

                    HttpContext.Session.Set("UserID", Encoding.UTF8.GetBytes(u.UserId.ToString()));
                    Console.WriteLine(u.UserId);
                    Console.WriteLine(Encoding.UTF8.GetString(HttpContext.Session.Get("UserID")));

                    }
                    
                    return View("Index", database.Users.FirstOrDefault(u => u.UserId.ToString().Equals((Encoding.UTF8.GetString(HttpContext.Session.Get("UserID"))))));
                }
            }
            return RedirectToAction("Index", null);
        }

        
        public IActionResult SignUp(string email, string username, string password, string passwordverification)
        {
            SaltRevision salt = (SaltRevision)Enum.GetValues(typeof(SaltRevision)).GetValue(rng.Next(Enum.GetValues(typeof(SaltRevision)).Length));
            if ( password.Equals(passwordverification) )
            {
                User u = new User();
                u.Username = username;
                u.Email = email;
                u.Password = BCrypt.Net.BCrypt.HashPassword(password,12,salt);
                u.UserId = database.Users.Count() + 1;
                database.AddAsync(u);
                database.SaveChangesAsync();
                //HttpContext.Session.Set("UserID", Encoding.UTF8.GetBytes(u.UserId.ToString()));
                //return to the index with the user
                return View("Index", null);
            }
            else
            {
                return View("Index");
            }
            //return RedirectToAction("Characters");
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

        public IActionResult LogOut()
        {
                HttpContext.Session.Remove("UserID");
                return RedirectToAction("Index", null);
        }
    }
}
