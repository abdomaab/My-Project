using Microsoft.EntityFrameworkCore;

namespace webapi.models
{
    public class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        //secure api ->gwt
    }
}