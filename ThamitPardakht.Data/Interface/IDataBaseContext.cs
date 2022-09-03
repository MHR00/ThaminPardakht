using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThamitPardakht.Entities.Entities.Accounts;
using ThamitPardakht.Entities.Entities.Contacts;
using ThamitPardakht.Entities.Entities.Users;

namespace ThamitPardakht.Data.Interface
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserInRole> UserInRoles { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<UserContact> UserContacts { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        int SaveChange(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangeAsync(bool assepAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangeAsynce(CancellationToken cancellationToken = new CancellationToken());
    }
}
