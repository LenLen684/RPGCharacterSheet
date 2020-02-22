using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public enum eSkill
    {
        ACROBATICS,
        ANIMALHANDLING,
        ARCANA,
        ATHLETICS,
        DECEPTION,
        HISTORY,
        INSIGHT,
        INTIMIDATION,
        INVESTIGATION,
        MEDICINE,
        NATURE,
        PERCEPTION,
        PERFORMANCE,
        PERSUASION,
        RELIGION,
        SLEIGHTOFHAND,
        STEALTH,
        SURVIVAL
    }

    public class Skills
    {
        public bool AcrobaticsIsProficient { get; set; }
        public bool AnimalHandlingIsProficient { get; set; }
        public bool ArcanaIsProficient { get; set; }
        public bool AthleticsIsProficient { get; set; }
        public bool DeceptionIsProficient { get; set; }
        public bool HistoryIsProficient { get; set; }
        public bool InsightIsProficient { get; set; }
        public bool IntimidationIsProficient { get; set; }
        public bool InvestigationIsProficient { get; set; }
        public bool MedicineIsProficient { get; set; }
        public bool NatureIsProficient { get; set; }
        public bool PerceptionIsProficient { get; set; }
        public bool PerformanceIsProficient { get; set; }
        public bool PersuasionIsProficient { get; set; }
        public bool ReligionIsProficient { get; set; }
        public bool SleightOfHandIsProficient { get; set; }
        public bool StealthIsProficient { get; set; }
        public bool SurvivalIsProficient { get; set; }

        public int AcrobaticsBonus { get; set; }
        public int AnimalHandlingBonus { get; set; }
        public int ArcanaBonus { get; set; }
        public int AthleticsBonus { get; set; }
        public int DeceptionBonus { get; set; }
        public int HistoryBonus { get; set; }
        public int InsightBonus { get; set; }
        public int IntimidationBonus { get; set; }
        public int InvestigationBonus { get; set; }
        public int MedicineBonus { get; set; }
        public int NatureBonus { get; set; }
        public int PerceptionBonus { get; set; }
        public int PerformanceBonus { get; set; }
        public int PersuasionBonus { get; set; }
        public int ReligionBonus { get; set; }
        public int SleightOfHandBonus { get; set; }
        public int StealthBonus { get; set; }
        public int SurvivalBonus { get; set; }

        public void CalculateSkillModifiers(Character character)
        {
            AcrobaticsBonus     += (AcrobaticsIsProficient) ? character.CharStats.DexterityMod + character.CharStats.Proficiency : character.CharStats.DexterityMod;
            SleightOfHandBonus  += (SleightOfHandIsProficient) ? character.CharStats.DexterityMod + character.CharStats.Proficiency : character.CharStats.DexterityMod;
            StealthBonus        += (StealthIsProficient) ? character.CharStats.DexterityMod + character.CharStats.Proficiency : character.CharStats.DexterityMod;
            AnimalHandlingBonus += (AnimalHandlingIsProficient) ? character.CharStats.WisdomMod + character.CharStats.Proficiency : character.CharStats.WisdomMod;
            InsightBonus        += (InsightIsProficient) ? character.CharStats.WisdomMod + character.CharStats.Proficiency : character.CharStats.WisdomMod;
            PerceptionBonus     += (PerceptionIsProficient) ? character.CharStats.WisdomMod + character.CharStats.Proficiency : character.CharStats.WisdomMod;
            MedicineBonus       += (MedicineIsProficient) ? character.CharStats.WisdomMod + character.CharStats.Proficiency : character.CharStats.WisdomMod;
            SurvivalBonus       += (SurvivalIsProficient) ? character.CharStats.WisdomMod + character.CharStats.Proficiency : character.CharStats.WisdomMod;
            ArcanaBonus         += (ArcanaIsProficient) ? character.CharStats.IntelligenceMod + character.CharStats.Proficiency : character.CharStats.IntelligenceMod;
            HistoryBonus        += (HistoryIsProficient) ? character.CharStats.IntelligenceMod + character.CharStats.Proficiency : character.CharStats.IntelligenceMod;
            InvestigationBonus  += (InvestigationIsProficient) ? character.CharStats.IntelligenceMod + character.CharStats.Proficiency : character.CharStats.IntelligenceMod;
            NatureBonus         += (NatureIsProficient) ? character.CharStats.IntelligenceMod + character.CharStats.Proficiency : character.CharStats.IntelligenceMod;
            ReligionBonus       += (ReligionIsProficient) ? character.CharStats.IntelligenceMod + character.CharStats.Proficiency : character.CharStats.IntelligenceMod;
            DeceptionBonus      += (DeceptionIsProficient) ? character.CharStats.CharismaMod + character.CharStats.Proficiency : character.CharStats.CharismaMod;
            IntimidationBonus   += (IntimidationIsProficient) ? character.CharStats.CharismaMod + character.CharStats.Proficiency : character.CharStats.CharismaMod;
            PerformanceBonus    += (PerformanceIsProficient) ? character.CharStats.CharismaMod + character.CharStats.Proficiency : character.CharStats.CharismaMod;
            PersuasionBonus     += (PersuasionIsProficient) ? character.CharStats.CharismaMod + character.CharStats.Proficiency : character.CharStats.CharismaMod;
            AthleticsBonus      += (AthleticsIsProficient) ? character.CharStats.StrengthMod + character.CharStats.Proficiency : character.CharStats.StrengthMod;
        }
    }
}
