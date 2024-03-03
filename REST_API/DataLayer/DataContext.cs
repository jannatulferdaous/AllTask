using Microsoft.EntityFrameworkCore;
using REST_API.Models;

namespace REST_API.DataLayer
{
    public class DataContext:DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }
        public DbSet <Article> Articles { get; set; }
    }
}
