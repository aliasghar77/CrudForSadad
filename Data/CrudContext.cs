using Microsoft.EntityFrameworkCore;
using CrudFroSadad.Models;

namespace CrudFroSadad.Data
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
       

    }
}
