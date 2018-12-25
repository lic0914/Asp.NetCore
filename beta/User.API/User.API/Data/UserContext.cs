using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using User.API.Model;

namespace User.API.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt):base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .ToTable("User");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppUser> AppUser { get; set; }
    }
}
