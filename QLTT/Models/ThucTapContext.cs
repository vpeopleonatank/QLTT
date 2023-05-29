using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLTT.Models;

public partial class ThucTapContext : DbContext
{
    public ThucTapContext()
    {
    }

    public ThucTapContext(DbContextOptions<ThucTapContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeTai> DeTais { get; set; }

    public virtual DbSet<GiangVien> GiangViens { get; set; }

    public virtual DbSet<HuongDan> HuongDans { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=ThucTap;Trusted_Connection=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeTai>(entity =>
        {
            entity.HasKey(e => e.Madt).HasName("PK__DeTai__7A21E02B19786611");

            entity.ToTable("DeTai");

            entity.Property(e => e.Madt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("madt");
            entity.Property(e => e.Kinhphi).HasColumnName("kinhphi");
            entity.Property(e => e.Noithuctap)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("noithuctap");
            entity.Property(e => e.Tendt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tendt");
        });

        modelBuilder.Entity<GiangVien>(entity =>
        {
            entity.HasKey(e => e.Magv).HasName("PK__GiangVie__7A2118CDF4F325EB");

            entity.ToTable("GiangVien");

            entity.Property(e => e.Magv)
                .ValueGeneratedNever()
                .HasColumnName("magv");
            entity.Property(e => e.Hotengv)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("hotengv");
            entity.Property(e => e.Luong)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("luong");
            entity.Property(e => e.Makhoa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("makhoa");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.GiangViens)
                .HasForeignKey(d => d.Makhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GiangVien__makho__267ABA7A");
        });

        modelBuilder.Entity<HuongDan>(entity =>
        {
            entity.HasKey(e => e.Mahd).HasName("PK__HuongDan__7A2100DE7A4D6DC0");

            entity.ToTable("HuongDan");

            entity.Property(e => e.Mahd).HasColumnName("mahd");
            entity.Property(e => e.Ketqua)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("ketqua");
            entity.Property(e => e.Madt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("madt");
            entity.Property(e => e.Magv).HasColumnName("magv");
            entity.Property(e => e.Masv).HasColumnName("masv");

            entity.HasOne(d => d.MadtNavigation).WithMany(p => p.HuongDans)
                .HasForeignKey(d => d.Madt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HuongDan__madt__2F10007B");

            entity.HasOne(d => d.MagvNavigation).WithMany(p => p.HuongDans)
                .HasForeignKey(d => d.Magv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HuongDan__magv__300424B4");

            entity.HasOne(d => d.MasvNavigation).WithMany(p => p.HuongDans)
                .HasForeignKey(d => d.Masv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HuongDan__masv__2E1BDC42");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Makhoa).HasName("PK__Khoa__30B01682263A580D");

            entity.ToTable("Khoa");

            entity.Property(e => e.Makhoa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("makhoa");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dienthoai");
            entity.Property(e => e.Tenkhoa)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tenkhoa");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Masv).HasName("PK__SinhVien__7A21767C073019DB");

            entity.ToTable("SinhVien");

            entity.Property(e => e.Masv)
                .ValueGeneratedNever()
                .HasColumnName("masv");
            entity.Property(e => e.Hotensv)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("hotensv");
            entity.Property(e => e.Makhoa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("makhoa");
            entity.Property(e => e.Namsinh).HasColumnName("namsinh");
            entity.Property(e => e.Quequan)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("quequan");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.Makhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SinhVien__makhoa__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
