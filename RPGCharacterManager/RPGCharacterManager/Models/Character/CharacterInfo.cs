using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class CharacterInfo
    {
        //Character name
        public string charName { get; set; }

        //Character class
        public string Class { get; set; }

        //Character level
        public int Level { get; set; }

        //Character background
        public string Background { get; set; }

        //Player name
        public string PlayerName { get; set; }

        //Character race
        public string Race { get; set; }

        //Character alignment
        public string Alignment { get; set; }

        //Character's experience points
        public int CurrentEXP { get; set; }

        //Character's experience needed to level up
        public int GoalEXP { get; set; }

        //Character's background In order:
        /* 
         * Personality Traits
         * Ideals
         * Bonds
         * Flaws
         */
        public List<string> BackgroundInfo { get; set; }
    }
}
