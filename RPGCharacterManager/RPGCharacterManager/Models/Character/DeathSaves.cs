using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class DeathSaves
    {
        //
        public bool[] SuccessfulSaves { get; set; } = new bool[3];
        public bool[] FailedSaves { get; set; } = new bool[3];
    }
}
