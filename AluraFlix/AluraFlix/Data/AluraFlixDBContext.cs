using AluraFlix.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraFlix.Data
{
    public class AluraFlixDBContext : DbContext
    {
        public AluraFlixDBContext(DbContextOptions<AluraFlixDBContext> opt) : base(opt)
        {

        }

        public DbSet<Videos> Videos { get; set; }
    }
}
