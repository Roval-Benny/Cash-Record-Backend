using Cash_Record_Backend.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cash_Record_Backend.Data.DAL
{
    public class CashRecordDbContext:IdentityDbContext<User>
    {
        public CashRecordDbContext(DbContextOptions<CashRecordDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Entry> Entries { get; set; }
    }
}
