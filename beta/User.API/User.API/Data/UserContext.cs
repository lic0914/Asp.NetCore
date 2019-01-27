using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using User.API.Models;

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
            modelBuilder.Entity<UserProperty>()
                .Property(u => u.Value).HasMaxLength(100);
            modelBuilder.Entity<UserProperty>()
                .ToTable("UserProperties")
                .HasKey(u => new { u.Key, u.AppUserId, u.Value });

            modelBuilder.Entity<UserTag>()
                .Property(u => u.Tag).HasMaxLength(100);
            modelBuilder.Entity<UserTag>()
                .ToTable("UserTags")
                .HasKey(u => new { u.UserId, u.Tag });
            modelBuilder.Entity<BPFile>()
                .ToTable("BPFiles")
                .HasKey(f => f.Id);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppUser> AppUser { get; set; }
    }
}
