using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThamitPardakht.Entities.Entities.Users;

namespace ThamitPardakht.Data.Interface
{
    public  interface IDataBaseContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }

        int SaveChange(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangeAsync(bool assepAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangeAsynce(CancellationToken cancellationToken = new CancellationToken());
    }
}
