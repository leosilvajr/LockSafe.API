using LockSafe.API.Model;
using Microsoft.EntityFrameworkCore;

namespace LockSafe.API.Context
{
    public class LockSafeContext : DbContext
    {
        public LockSafeContext(DbContextOptions<LockSafeContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<PasswordAllowance> PasswordAllowances { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Definir o relacionamento entre as tabelas Users e Passwords e PasswordAllowances
            /*
                    
            */
            base.OnModelCreating(modelBuilder);
        }
    }
}
