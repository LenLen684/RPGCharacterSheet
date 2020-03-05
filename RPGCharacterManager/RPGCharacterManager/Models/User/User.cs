using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGCharacterManager.Models.Character;

namespace RPGCharacterManager.Models.User
{
    public class User
    {
        private static int currentID = 0;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private int userID;
        public int UserId
        {
            get { return userID; }
            set { userID = value; }
        }

        public List<Character.Character> Characters { get; set; } = new List<Character.Character>();
    }
}
