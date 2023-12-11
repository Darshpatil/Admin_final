using System;
using System.Collections.Generic;
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
