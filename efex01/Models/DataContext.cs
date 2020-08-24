using Microsoft.EntityFrameworkCore;

namespace efex01.Models
{
    public class DataContext: DbContext{
        public DataContext(DbContextOptions<DataContext> opts)
            :base(opts){}
        
        public DbSet<Product> Products{get;set;}

        public DbSet<Category> Categories { get; set; }
    }
}