using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Data
{
    public class KeyValueDbContext: DbContext
    {
        public KeyValueDbContext(DbContextOptions<KeyValueDbContext> options) : base(options)
        {
        }

        public DbSet<Models.KeyValuePair> KeyValuePairs { get; set; }
    }
}
