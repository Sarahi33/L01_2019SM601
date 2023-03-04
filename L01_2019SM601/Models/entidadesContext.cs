using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using L01_2019SM601.Models;
namespace L01_2019SM601.Models
{
    public class entidadesContext : DbContext
    {
        public entidadesContext(DbContextOptions<entidadesContext> options) : base(options)
        {
        }

        public DbSet<entidades> entidades{ get; set; }
    }
}
