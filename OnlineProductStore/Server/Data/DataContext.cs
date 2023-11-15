using Microsoft.EntityFrameworkCore;
using OnlineProductStore.Shared.Models;

namespace OnlineProductStore.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
