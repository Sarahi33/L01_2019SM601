using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using L01_2019SM601.Models;

namespace L01_2019SM601.Models
{
    public class motoristaContext : DbContext
    {

        public motoristaContext(DbContextOptions<motoristaContext> options) : base(options)
        {
        }

        public DbSet<motorista> entidades { get; set; }
    }
}
