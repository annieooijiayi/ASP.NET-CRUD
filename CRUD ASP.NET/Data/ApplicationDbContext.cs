using CRUD_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ASP.NET.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }

        public DbSet<Category> Categories { get; set; }     
    }
}
