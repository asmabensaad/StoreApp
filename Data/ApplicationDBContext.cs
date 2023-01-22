using Microsoft.EntityFrameworkCore;
using Store.Models;
namespace Store.Data
{
    public class ApplicationDBContext  :DbContext
    { 
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
            {
        
        }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Stock>Stocklist { get;set; }

    }
}

