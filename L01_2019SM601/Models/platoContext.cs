using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using L01_2019SM601.Models;

namespace L01_2019SM601.Models
{
    public class platoContext : DbContext
    {
        public platoContext(DbContextOptions<platoContext> options) : base(options)
        {
        }

        public DbSet<plato> entidades { get; set; }
    }
}
