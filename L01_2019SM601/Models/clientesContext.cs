using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using L01_2019SM601.Models;
namespace L01_2019SM601.Models
{
    public class clientesContext : DbContext
    {
        public clientesContext(DbContextOptions<clientesContext> options) : base(options)
        {
        }

        public DbSet<clientess> entidades{ get; set; }
    }
}
