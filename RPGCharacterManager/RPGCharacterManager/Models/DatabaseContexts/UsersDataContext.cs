using Microsoft.EntityFrameworkCore;
using RPGCharacterManager.Models.DatabaseModels;
using RPGCharacterManager.Models.OscarsDatabaseTestingModels;


namespace RPGCharacterManager.Models.DatabaseContexts
{
    public class UsersDataContext : DbContext
    {
        public static User.User currentUser { get; set; }// = new User.User();
        public UsersDataContext(DbContextOptions<UsersDataContext> options) : base(options) { }
        public DbSet<User.User> Users { get; set; }

        public DbSet<BackgroundInfo> BackgroundInfos{get; set;}
        public DbSet<CharacterDeathSave> CharacterDeathSaves {get;set;}
        public DbSet<CharacterFeature> CharacterFeatures{get;set;}
        public DbSet<CharacterInfo> CharacterInfos{get;set;}
        public DbSet<CharacterItem> CharacterItems{get;set;}
        public DbSet<CharacterProficiencie> CharacterProficiencies{get;set;}
        public DbSet<CharacterSave> CharacterSaves{get;set;}
        public DbSet<CharacterSkill> CharacterSkills{get;set;}
        public DbSet<CharacterStat> CharacterStats{get;set;}
        public DbSet<CharacterUser> CharacterUsers{get;set;}
        public DbSet<CharacterWallet> CharacterWallets{get;set;}
        public DbSet<CharacterWeapon> CharacterWeapons {get;set;}
        public DbSet<Feature> Features{get;set;}
        public DbSet<Item> Items{get;set;}
        public DbSet<Proficiencie> Proficiencies { get;set; }
        public DbSet<Spell> Spells{get;set;}
        public DbSet<SpellBook> SpellBooks{get;set;}
        public DbSet<Weapon> Weapons{get;set;}
    }
}
