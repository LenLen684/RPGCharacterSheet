
using Microsoft.EntityFrameworkCore;

namespace RPGCharacterManager.Models.OscarsDatabaseTestingModels
{
    public class Class : DbContext
    {
        public Class(DbContextOptions<Class> options) : base(options) { }
        public DbSet<TestingModel> Testings { get; set; }
    }
}
