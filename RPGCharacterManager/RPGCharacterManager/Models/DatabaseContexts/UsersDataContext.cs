using Microsoft.EntityFrameworkCore;
using RPGCharacterManager.Models.OscarsDatabaseTestingModels;

namespace RPGCharacterManager.Models.DatabaseContexts
{
    public class UsersDataContext : DbContext
    {
        public static User.User currentUser { get; set; } = new User.User();
        public UsersDataContext(DbContextOptions<UsersDataContext> options) : base(options) { }
        public DbSet<User.User> Users { get; set; }
    }
}
