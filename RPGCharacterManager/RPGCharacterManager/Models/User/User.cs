using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class User
    {
        static int currentID = 0;
        public string Username { get; set; }

        public string Password { get; set; }

        private int userID;
        public int UserId
        {
            get { return userID; }
            set { userID = currentID++; }
        }

        public List<Character> Characters { get; set; }
    }
}
