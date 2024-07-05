using AvaloniaApp.Model;
using DynamicData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApp.Access
{
    public interface IAppDbContext
    {

        DbSet<User> Users { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<BookCategory> BookCategories { get; set; }
        DbSet<CheckOut> CheckOuts { get; set; }

        Task<int> SaveChangesAsync();

    }
}
