using Limedika.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Limedika.Data
{
    public class ClientsDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientLog> ClientsLogs { get; set; }
        public ClientsDbContext(DbContextOptions<ClientsDbContext> options) : base(options)
        {

        }
    }
}
