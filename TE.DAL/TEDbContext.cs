using Microsoft.EntityFrameworkCore;

namespace TE.DAL
{
    public partial class TEDbContext : DbContext
    {
        public TEDbContext(DbContextOptions<TEDbContext> options)
                : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}