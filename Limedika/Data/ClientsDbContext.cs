using Limedika.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Limedika.Data
{
    public class ClientsDbContext(DbContextOptions<ClientsDbContext> options) : DbContext(options)
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientLog> ClientsLogs { get; set; }
    }
}
