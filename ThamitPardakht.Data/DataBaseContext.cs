using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Common.Utilities;
using ThamitPardakht.Data.Interface;
using ThamitPardakht.Entities.Entities.Users;

namespace ThamitPardakht.Data
{
    public  class DataBaseContext:DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options):base(options)  
        {

        }

        public DbSet<User> Users{ get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // افزودن مقادیر پیش فرض به جدول Roles
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1 , Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2 , Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3 , Name = nameof(UserRoles.Customer) });

            // اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            //--
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
        }

        public int SaveChange(bool acceptAllChangesOnSuccess)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangeAsync(bool assepAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangeAsynce(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
