using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class SaveThrows
    {
        public int strengthSaveMod { get; set; }
        public int dexteritySaveMod { get; set; }
        public int constitutionSaveMod { get; set; }
        public int intelligenceSaveMod { get; set; }
        public int wisdomSaveMod { get; set; }
        public int charismaSaveMod { get; set; }

        public bool isProficientStrengthSave { get; set; }
        public bool isProficientDexteritySave { get; set; }
        public bool isProficientConstitutionSave { get; set; }
        public bool isProficientIntelligenceSave { get; set; }
        public bool isProficientWisdomSave { get; set; }
        public bool isProficientCharismaSave { get; set; }
    }
}
