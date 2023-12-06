using Microsoft.EntityFrameworkCore;
using AdminDAL.Entities;

namespace AdminDAL.Context
{
    public class AdminContext : DbContext
    {
       

        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options) { }

        public virtual DbSet<EntityTbl> EntityTbls { get; set; }
        public virtual DbSet<Feature> Features { get; set; }

        // Other configurations, if required
    }
}
  