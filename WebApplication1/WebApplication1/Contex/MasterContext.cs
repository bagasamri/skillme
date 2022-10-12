using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Contex
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Penilaian> penilaian { get; set; }
    }
}
