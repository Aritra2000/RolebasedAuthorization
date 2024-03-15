using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class RolebasedContext : DbContext
{
    public RolebasedContext()
    {
    }

    public RolebasedContext(DbContextOptions<RolebasedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserRole> TblUserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    { 

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.ToTable("tbl_role");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.ToTable("Tbl_User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fname).HasColumnName("fname");
            entity.Property(e => e.Ph)
                .HasMaxLength(10)
                .HasColumnName("ph");
        });

        modelBuilder.Entity<TblUserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_UserRoles");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_UserRoles_tbl_role");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_UserRoles_Tbl_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
