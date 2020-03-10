using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGCharacterManager.Models.DatabaseContexts;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public static class Converter
    {
        public static User.User user;
        public static Character.Character character;
        public static readonly UsersDataContext database;

        public static void addCharacter( User.User u, Character.Character c )
        {
            if ( user != null && character != null && database != null )
            {
                CharacterUser characterUser = new CharacterUser();
                if ( !database.CharacterUsers.Any() )
                {
                    characterUser.Id = database.CharacterUsers.Max(o => o.Id) + 1;
                    characterUser.Character = database.CharacterUsers.Max(o => o.Character) + 1;
                }
                else
                {
                    characterUser.Id = 0;
                    characterUser.Character = 0;
                }
                characterUser.user = u.UserId;

                database.AddAsync(characterUser);

                foreach ( string s in c.CharInfo.BackgroundInfo )
                {
                    BackgroundInfo backgroundInfo = new BackgroundInfo();
                    if ( database.BackgroundInfos.Any() )
                    {
                        backgroundInfo.Id = database.BackgroundInfos.Max(o => o.Id) + 1;
                    }
                    else
                    {
                        backgroundInfo.Id = database.BackgroundInfos.Count();
                    }
                    backgroundInfo.Value = s;
                    backgroundInfo.Character = characterUser.Character;
                    database.AddAsync(backgroundInfo);
                }

                CharacterDeathSave characterDeathSave = new CharacterDeathSave();
                characterDeathSave.Id = characterUser.Id;
                int success = 0;
                for(int i = 0;i < 3; i++ )
                {
                    success = (int) (c.CharStats.DeathSaveRolls.SuccessfulSaves[i] ? Math.Pow(2, i) : 0);
                }
                characterDeathSave.Success = success;
                int fails = 0;
                for ( int i = 0; i < 3; i++ )
                {
                    fails = (int) ( c.CharStats.DeathSaveRolls.FailedSaves[i] ? Math.Pow(2, i) : 0 );
                }
                characterDeathSave.Fails = fails;
                characterDeathSave.Character = characterUser.Id;

                database.AddAsync(characterDeathSave);

                foreach ( Character.Feature f in c.Features.Features )
                {
                    Feature feature = new Feature();
                    if ( database.Features.Any() )
                    {
                        feature.Id = database.Features.Max(o => o.Id) + 1;
                    }
                    else
                    {
                        feature.Id = 0;
                    }

                    feature.featureName = f.featureName;
                    feature.featureDescription = f.featureDescription;

                    database.AddAsync(feature);

                    CharacterFeature characterFeature = new CharacterFeature();
                    if ( database.Features.Any() )
                    {
                        characterFeature.Id = database.CharacterFeatures.Max(o=>o.Id) + 1;
                    }
                    else
                    {
                        characterFeature.Id = 0;
                    }
                    characterFeature.FeatureId = feature.Id;
                    characterFeature.Character = characterUser.Id;

                    database.AddAsync(characterFeature);
                }

                CharacterInfo characterInfo = new CharacterInfo();
                if ( database.CharacterInfos.Any() )
                {
                    characterInfo.Id = database.CharacterInfos.Max(o => o.Id);
                }
                else
                {
                    characterInfo.Id = 0;
                }

                characterInfo.CharName = c.CharInfo.CharName;
                characterInfo.Class = c.CharInfo.Class;
                characterInfo.Level = c.CharInfo.Level;
                characterInfo.Background = c.CharInfo.Background;
                characterInfo.PlayerName = c.CharInfo.PlayerName;
                characterInfo.Race = c.CharInfo.Race;
                characterInfo.Alignment = c.CharInfo.Alignment;
                characterInfo.CurrentEXP = c.CharInfo.CurrentEXP;
                characterInfo.GoalEXP = c.CharInfo.GoalEXP;
                characterInfo.BackgroundInfo = "default";

                database.AddAsync(characterInfo);

                foreach ( Character.Item i in c.CharInventory.items )
                {
                    Item item = new Item();
                    if ( database.Items.Any() )
                    {
                        item.Id = database.Items.Max(o => o.Id) + 1;
                    }
                    else
                    {
                        item.Id = 0;
                    }

                    item.itemName = i.itemName;
                    item.itemDescription = i.itemDescription;
                    item.itemAmount = (int) i.itemAmount;
                    item.Character = characterUser.Character;

                    database.AddAsync(item);

                    CharacterItem characterItem = new CharacterItem();
                    if ( database.CharacterItems.Any() )
                    {
                        characterItem.Id = database.CharacterItems.Max(o => o.Id) + 1;
                    }
                    else
                    {
                        characterItem.Id = 0;
                    }

                    characterItem.ItemValue = item.Id;
                    characterItem.Character = item.Character;
                    
                    database.AddAsync(characterItem);
                }

                foreach(string s in c.Proficiencies)
                {
                    Proficiencie proficiencie = new Proficiencie();
                    if (database.Proficiencies.Any())
                    {
                        proficiencie.Id = database.Proficiencies.Max(o => o.Id) + 1;
                    }
                    else
                    {
                        proficiencie.Id = 0;
                    }
                    proficiencie.Description = s;
                    proficiencie.Character = characterUser.Character;

                    CharacterProficiencie characterProficiencie = new CharacterProficiencie();
                    if ( database.CharacterProficiencies.Any() )
                    {
                        characterProficiencie.Id = database.CharacterProficiencies.Max(o => o.Id) + 1;
                    }
                    else
                    {
                        characterProficiencie.Id = 0;
                    }

                    characterProficiencie.ProficiencyId = proficiencie.Id;
                    characterProficiencie.Character = proficiencie.Character;
                    database.AddAsync(proficiencie);
                    database.AddAsync(characterProficiencie);
                }

                CharacterSave characterSave = new CharacterSave();
                if ( database.CharacterSaves.Any() )
                {
                    characterSave.Id = database.CharacterSaves.Max(o=>o.Id) + 1;
                }
                else
                {
                    characterSave.Id = 0;
                }

                characterSave.Strength = c.SavingThrows.isProficientStrengthSave;
                characterSave.Dexterity = c.SavingThrows.isProficientDexteritySave;
                characterSave.Constitution = c.SavingThrows.isProficientConstitutionSave;
                characterSave.Intelligence = c.SavingThrows.isProficientIntelligenceSave;
                characterSave.Wisdom = c.SavingThrows.isProficientWisdomSave;
                characterSave.Charisma = c.SavingThrows.isProficientCharismaSave;

                database.AddAsync(characterSave);

                CharacterSkill characterSkill = new CharacterSkill();
                characterSkill.IsProficient1 = c.CharSkills.CharSkills[0].IsProficient;
                characterSkill.IsProficient2 = c.CharSkills.CharSkills[1].IsProficient;
                characterSkill.IsProficient3 = c.CharSkills.CharSkills[2].IsProficient;
                characterSkill.IsProficient4 = c.CharSkills.CharSkills[3].IsProficient;
                characterSkill.IsProficient5 = c.CharSkills.CharSkills[4].IsProficient;
                characterSkill.IsProficient6 = c.CharSkills.CharSkills[5].IsProficient;
                characterSkill.IsProficient7 = c.CharSkills.CharSkills[6].IsProficient;
                characterSkill.IsProficient8 = c.CharSkills.CharSkills[7].IsProficient;
                characterSkill.IsProficient9 = c.CharSkills.CharSkills[8].IsProficient;
                characterSkill.IsProficient10 = c.CharSkills.CharSkills[9].IsProficient;
                characterSkill.IsProficient11 = c.CharSkills.CharSkills[10].IsProficient;
                characterSkill.IsProficient12 = c.CharSkills.CharSkills[11].IsProficient;
                characterSkill.IsProficient13 = c.CharSkills.CharSkills[12].IsProficient;
                characterSkill.IsProficient14 = c.CharSkills.CharSkills[13].IsProficient;
                characterSkill.IsProficient15 = c.CharSkills.CharSkills[14].IsProficient;
                characterSkill.IsProficient16 = c.CharSkills.CharSkills[15].IsProficient;
                characterSkill.IsProficient17 = c.CharSkills.CharSkills[16].IsProficient;
                characterSkill.IsProficient18 = c.CharSkills.CharSkills[17].IsProficient;
                
                database.AddAsync(characterSkill);

                CharacterStat characterStat = new CharacterStat();
                if (database.CharacterStats.Any())
                {
                    characterStat.Id = database.CharacterStats.Max(o => o.Id) + 1;
                }
                else
                {
                    characterStat.Id = 0;
                }

                characterStat.Strength = c.CharStats.Strength;
                characterStat.Dexterity = c.CharStats.Dexterity;
                characterStat.Constitution = c.CharStats.Constitution;
                characterStat.Intelligence = c.CharStats.Intelligence;
                characterStat.Wisdom = c.CharStats.Wisdom;
                characterStat.Charisma = c.CharStats.Charisma;
                characterStat.Inspiration = c.CharStats.Inspiration;
                characterStat.PassivePerception = c.CharStats.PassivePerception;
                characterStat.ArmorClass = c.CharStats.ArmorClass;
                characterStat.Inspiration = c.CharStats.Initiative;
                characterStat.Speed = c.CharStats.Speed;
                characterStat.MaxHP = c.CharStats.MaxHP;
                characterStat.CurrentHP = c.CharStats.CurrentHP;
                characterStat.TempHP = c.CharStats.TempHP;
                characterStat.HitDie = (int) c.CharStats.HitDie;
                characterStat.Proficiencie = c.CharStats.Proficiency;

                database.AddAsync(characterStat);

                CharacterWallet characterWallet = new CharacterWallet();
                if ( database.CharacterWallets.Any() )
                {
                    characterWallet.Id = database.CharacterWallets.Max(o => o.Id)+1;
                }
                else
                {
                    characterWallet.Id = 0;
                }

                characterWallet.Copper = c.CharWallet.copper;
                characterWallet.Silver = c.CharWallet.silver;
                characterWallet.Electrum = c.CharWallet.electrum;
                characterWallet.Gold = c.CharWallet.gold;
                characterWallet.Platinum = c.CharWallet.platinum;

                database.AddAsync(characterWallet);

                foreach ( Character.Weapon w in c.CharInventory.weapons )
                {
                    Weapon weapon = new Weapon();
                    if ( database.Weapons.Any() )
                    {
                        weapon.Id = database.Weapons.Max(o => o.Id)+1;
                    }
                    else
                    {
                        weapon.Id = 0;
                    }

                    weapon.WeaponName = w.weaponName;
                    weapon.WeaponDescription = w.weaponDescription;
                    weapon.eWeaponMod = (int)w.weaponMod;

                    database.AddAsync(weapon);

                    CharacterWeapon characterWeapon = new CharacterWeapon();
                    if ( database.CharacterWeapons.Any() )
                    {
                        characterWeapon.Id = database.CharacterWeapons.Max(o => o.Id) + 1;
                    }
                    else
                    {
                        characterWeapon.Id = 0;
                    }

                    characterWeapon.WeaponValue = weapon.Id;
                    characterWeapon.Character = characterUser.Character;

                    database.AddAsync(characterWeapon);

                    SpellBook spellBook = new SpellBook();
                    if (database.SpellBooks.Any())
                    {
                        spellBook.Id = database.SpellBooks.Max(o => o.Id) + 1;
                    }
                    else
                    {
                        spellBook.Id = 0;
                    }

                    string spellsTotal = "";
                    foreach ( int i in c.Spells.SpellSlotsTotal )
                    {
                        spellsTotal += i + ",";
                    }
                    spellBook.SpellsTotal = spellsTotal;

                    string spellsRemaining = "";
                    foreach ( int i in c.Spells.SpellSlotsRemaining )
                    {
                        spellsRemaining += i + ",";
                    }

                    spellBook.SpellsRemaining = spellsRemaining;

                    string spellsKnown = "";

                    foreach (Character.Spell spell in c.Spells.Spells)
                    {
                        Spell s = new Spell();
                        if ( database.Spells.Any() )
                        {
                            s.Id = database.Spells.Max(o => o.Id)+1;
                        }
                        else{
                            s.Id = 0;
                        }

                        s.SpellName = spell.SpellName;
                        s.SpellDescription = spell.SpellDescription;
                        s.SpellLevel = spell.SpellLevel;

                        database.AddAsync(s);

                        spellsKnown += s.Id + ",";
                    }

                    spellBook.SpellsKnown = spellsKnown;

                    database.AddAsync(spellBook);
                }

                database.SaveChanges();
            }
        }

        public static void updateCharacter( User.User u, Character.Character c )
        {
            if ( user != null && character != null && database != null )
            {

            }
        }

        public static void deleteCharacter( User.User u, Character.Character c )
        {
            if ( user != null && character != null && database != null )
            {

            }
        }

        public static Character.Character getCharacter(User.User u, int characterIndex)
        {
            Character.Character c = new Character.Character();

            IEnumerable<CharacterUser> chars = database.CharacterUsers.Where(o => o.user == u.UserId);
            CharacterUser charUser = chars.ElementAt(characterIndex);
            c.CharacterID = charUser.Character;

            CharacterInfo characterInfo = database.CharacterInfos.FirstOrDefault(o => o.Id == c.CharacterID);
            c.CharInfo.CharName = characterInfo.CharName;
            c.CharInfo.Class = characterInfo.Class;
            c.CharInfo.Level = characterInfo.Level;
            c.CharInfo.Background = characterInfo.Background;
            c.CharInfo.PlayerName = characterInfo.PlayerName;
            c.CharInfo.Race = characterInfo.Race;
            c.CharInfo.Alignment = characterInfo.Alignment;
            c.CharInfo.CurrentEXP = characterInfo.CurrentEXP;
            c.CharInfo.GoalEXP = characterInfo.GoalEXP;
            c.CharInfo.BackgroundInfo = new List<string>();

            foreach ( BackgroundInfo bi in database.BackgroundInfos.Where(o => o.Character == c.CharacterID) )
            {
                c.CharInfo.BackgroundInfo.Add(bi.Value);
            }

            IEnumerable<Item> items = database.Items.Where(o => o.Character == c.CharacterID);

            foreach ( Item i in items )
            {
                Character.Item item = new Character.Item();
                item.itemAmount = (uint)i.itemAmount;
                item.itemName = i.itemName;
                item.itemDescription = i.itemDescription;
                item.Id = i.Id;
                c.CharInventory.items.Add(item);
            }

            IEnumerable<CharacterWeapon> weapons = database.CharacterWeapons.Where(o => o.Character == c.CharacterID);
            
            foreach ( CharacterWeapon w in weapons )
            {
                Weapon weapon = database.Weapons.FirstOrDefault(o => o.Id == w.WeaponValue);
                Character.Weapon weapon1 = new Character.Weapon();
                weapon1.Id = weapon.Id;
                weapon1.weaponName = weapon.WeaponName;
                weapon1.weaponDescription = weapon.WeaponDescription;
                weapon1.weaponMod = (Character.eWeaponMod) weapon.eWeaponMod;

                c.CharInventory.weapons.Add(weapon1);
            }

            c.Features.Features = new List<Character.Feature>(); 
            IEnumerable<CharacterFeature> characterFeatures = database.CharacterFeatures.Where(o => o.Character == c.CharacterID);
            foreach ( CharacterFeature cf in characterFeatures )
            {
                Feature feature = database.Features.FirstOrDefault(o => o.Id == cf.FeatureId);
                Character.Feature feature1 = new Character.Feature();
                feature1.Id = feature.Id;
                feature1.featureName = feature.featureName;
                feature1.featureDescription = feature.featureDescription;
                c.Features.Features.Add(feature1);
            }

            CharacterSkill characterSkill = database.CharacterSkills.FirstOrDefault(o => o.Id == c.CharacterID);

            c.CharSkills.CharSkills[0].IsProficient = characterSkill.IsProficient1;
            c.CharSkills.CharSkills[1].IsProficient = characterSkill.IsProficient2;
            c.CharSkills.CharSkills[2].IsProficient = characterSkill.IsProficient3;
            c.CharSkills.CharSkills[3].IsProficient = characterSkill.IsProficient4;
            c.CharSkills.CharSkills[4].IsProficient = characterSkill.IsProficient5;
            c.CharSkills.CharSkills[5].IsProficient = characterSkill.IsProficient6;
            c.CharSkills.CharSkills[6].IsProficient = characterSkill.IsProficient7;
            c.CharSkills.CharSkills[7].IsProficient = characterSkill.IsProficient8;
            c.CharSkills.CharSkills[8].IsProficient = characterSkill.IsProficient9;
            c.CharSkills.CharSkills[9].IsProficient = characterSkill.IsProficient10;
            c.CharSkills.CharSkills[10].IsProficient = characterSkill.IsProficient11;
            c.CharSkills.CharSkills[11].IsProficient = characterSkill.IsProficient12;
            c.CharSkills.CharSkills[12].IsProficient = characterSkill.IsProficient13;
            c.CharSkills.CharSkills[13].IsProficient = characterSkill.IsProficient14;
            c.CharSkills.CharSkills[14].IsProficient = characterSkill.IsProficient15;
            c.CharSkills.CharSkills[15].IsProficient = characterSkill.IsProficient16;
            c.CharSkills.CharSkills[16].IsProficient = characterSkill.IsProficient17;
            c.CharSkills.CharSkills[17].IsProficient = characterSkill.IsProficient18;

            CharacterSave characterSave = database.CharacterSaves.FirstOrDefault(o => o.Id == c.CharacterID);

            c.SavingThrows.Id = c.CharacterID;
            c.SavingThrows.isProficientStrengthSave = characterSave.Strength;
            c.SavingThrows.isProficientDexteritySave = characterSave.Dexterity;
            c.SavingThrows.isProficientConstitutionSave = characterSave.Constitution;
            c.SavingThrows.isProficientIntelligenceSave = characterSave.Intelligence;
            c.SavingThrows.isProficientWisdomSave = characterSave.Wisdom;
            c.SavingThrows.isProficientCharismaSave = characterSave.Charisma;

            c.SavingThrows.CalculateSaveThrowModifiers(c);

            SpellBook spellBook = database.SpellBooks.FirstOrDefault(o => o.Id == c.CharacterID);
            int[] total = new int[9];
            string[] totals = spellBook.SpellsTotal.Split(',');
            for (int i = 0; i < 9; i++)
            {
                total[i] = int.Parse(totals[i]);
            }
            c.Spells.SpellSlotsTotal = total;

            int[] remaining = new int[9];
            string[] remainings = spellBook.SpellsRemaining.Split(',');
            for(int i = 0; i < 9; i++)
            {
                remaining[i] = int.Parse(remainings[i]);
            }
            c.Spells.SpellSlotsRemaining = remaining;

            List<int> spellsKnown = new List<int>();

            string[] spells = spellBook.SpellsKnown.Split(',');
            foreach (string s in spells)
            {
                Character.Spell spell1 = new Character.Spell();
                Spell spell = database.Spells.FirstOrDefault(o => o.Id == int.Parse(s));
                spell1.Id = spell.Id;
                spell1.SpellName = spell.SpellName;
                spell1.SpellDescription = spell.SpellDescription;
                spell1.SpellLevel = spell.SpellLevel;
                c.Spells.Spells.Add(spell1);
            }

            c.Spells.CalculateSpellcastingInfo(c);

            CharacterStat characterStat = database.CharacterStats.FirstOrDefault(o => o.Id == c.CharacterID);

            c.CharStats.Strength = characterStat.Strength;
            c.CharStats.Dexterity = characterStat.Dexterity;
            c.CharStats.Constitution = characterStat.Constitution;
            c.CharStats.Intelligence = characterStat.Intelligence;
            c.CharStats.Wisdom = characterStat.Wisdom;
            c.CharStats.Charisma = characterStat.Charisma;
            c.CharStats.Inspiration = characterStat.Inspiration;
            c.CharStats.PassivePerception = characterStat.PassivePerception;
            c.CharStats.Proficiency = characterStat.Proficiencie;
            c.CharStats.ArmorClass = characterStat.ArmorClass;
            c.CharStats.Initiative = characterStat.Initiative;
            c.CharStats.Speed = characterStat.Speed;
            c.CharStats.MaxHP = characterStat.MaxHP;
            c.CharStats.CurrentHP = characterStat.CurrentHP;
            c.CharStats.TempHP = characterStat.TempHP;
            c.CharStats.HitDie = (Character.eHitDice) characterStat.HitDie;

            CharacterDeathSave characterDeathsave =
                database.CharacterDeathSaves.FirstOrDefault(o => o.Character == c.CharacterID);

            c.CharStats.DeathSaveRolls.Id = characterDeathsave.Id;
            int success = characterDeathsave.Success;  // got the next line of code off of stack overflow to change an int into a bool[]
            c.CharStats.DeathSaveRolls.SuccessfulSaves = Convert.ToString(success, 2).Select(s => s.Equals('1')).ToArray();
            int fail = characterDeathsave.Fails;
            c.CharStats.DeathSaveRolls.FailedSaves = Convert.ToString(fail, 2).Select(s => s.Equals('1')).ToArray();

            CharacterWallet characterWallet = database.CharacterWallets.FirstOrDefault(o=>o.Id == c.CharacterID);

            c.CharWallet.Id = c.CharacterID;
            c.CharWallet.copper = characterWallet.Copper;
            c.CharWallet.silver = characterWallet.Silver;
            c.CharWallet.electrum = characterWallet.Electrum;
            c.CharWallet.gold = characterWallet.Gold;
            c.CharWallet.platinum = characterWallet.Platinum;

            IEnumerable<CharacterProficiencie> characterProficincie =
                database.CharacterProficiencies.Where(o => o.Character == c.CharacterID);

            foreach(CharacterProficiencie prof in characterProficincie)
            {
                Proficiencie proficiencie = database.Proficiencies.FirstOrDefault(o => o.Id == prof.ProficiencyId);
                c.Proficiencies.Add(proficiencie.Description);
            }

            return c;
        }
    }
}
