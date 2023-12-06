using System;

using Microsoft.EntityFrameworkCore;

namespace AdminDAL.Entities2;

public partial class AdminCont : DbContext
{
    public AdminCont()
    {
    }

    public AdminCont(DbContextOptions<AdminCont> options)
        : base(options)
    {
    }

    public virtual DbSet<EntityTbl> EntityTbls { get; set; }

    public virtual DbSet<Feature> Features { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // => optionsBuilder.UseSqlServer("Server=tcp:featuremeshserver.database.windows.net,1433;Initial Catalog=FeatureMeshOffline;Persist Security Info=False;User ID=admin123;Password=Admin@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feature>(entity =>
        {
            entity.Property(e => e.UserName).HasDefaultValueSql("(N'')");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
