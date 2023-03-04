using Microsoft.EntityFrameworkCore;

namespace L01_2019SM601.Models
{
    public class pedidoContext : DbContext
    {
        public pedidoContext(DbContextOptions<pedidoContext> options) : base(options)
        {
        }

        public DbSet<pedido> entidades { get; set; }
    }
}
