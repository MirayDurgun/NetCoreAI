using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project01_ApiDemo.Entities;
using System.Runtime.ConstrainedExecution;

namespace NetCoreAI.Project01_ApiDemo.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;initial catalog=ApiAIDb;integrated security=true;trustservercertificate=true");
            //trustservercertificate=true     Sunucu sertifikası doğrulanmadan da bağlantıya izin ver
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
