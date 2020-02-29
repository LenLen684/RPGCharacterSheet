using Microsoft.EntityFrameworkCore;

namespace RPGCharacterManager.Models.DatabaseContexts
{
    public class UsersDataContext : DbContext
    {
        public UsersDataContext(DbContextOptions<UsersDataContext> options) : base(options) { }
        public DbSet<User.User> Users { get; set; }
    }
}
