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

        public DbSet<motorista> motoristas { get; set; }
        public DbSet<pedido> pedidos { get; set; }
        public DbSet<plato> platos { get; set; }        
        public DbSet<clientess> clientesses { get; set; }
    }
}
