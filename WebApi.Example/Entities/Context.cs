using Microsoft.EntityFrameworkCore;

namespace WebApi.Example.Entities
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }
        public DbSet <Product> Products { get; set; }
    }
}
