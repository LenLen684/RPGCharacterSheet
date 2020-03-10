using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class SaveThrows
    {
        [Key]
        public int Id {get; set;}
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

        public void CalculateSaveThrowModifiers(Character character)
        {
            strengthSaveMod     = (isProficientStrengthSave) ? character.CharStats.StrengthMod + character.CharStats.Proficiency : character.CharStats.StrengthMod;
            dexteritySaveMod     = (isProficientDexteritySave) ? character.CharStats.DexterityMod + character.CharStats.Proficiency : character.CharStats.DexterityMod;
            constitutionSaveMod     = (isProficientConstitutionSave) ? character.CharStats.ConstitutionMod + character.CharStats.Proficiency : character.CharStats.ConstitutionMod;
            intelligenceSaveMod     = (isProficientIntelligenceSave) ? character.CharStats.IntelligenceMod + character.CharStats.Proficiency : character.CharStats.IntelligenceMod;
            wisdomSaveMod     = (isProficientWisdomSave) ? character.CharStats.WisdomMod + character.CharStats.Proficiency : character.CharStats.WisdomMod;
            charismaSaveMod     = (isProficientCharismaSave) ? character.CharStats.CharismaMod + character.CharStats.Proficiency : character.CharStats.CharismaMod;
        }
    }
}
