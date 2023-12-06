using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Admin.Entities;

public partial class AdminCont : DbContext
{
    public AdminCont()
    {
    }

    public AdminCont(DbContextOptions<AdminCont> options)
        : base(options)
    {
    }

    public virtual DbSet<Feature> Features { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:featuremeshserver.database.windows.net,1433;Initial Catalog=FeatureMeshOffline;Persist Security Info=False;User ID=admin123;Password=Admin@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");

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
