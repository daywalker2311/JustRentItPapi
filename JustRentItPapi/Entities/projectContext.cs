using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JustRentItPapi.Entities
{
    public partial class projectContext : DbContext
    {
        public projectContext()
        {
        }

        public projectContext(DbContextOptions<projectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Rents> Rents { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.Carid)
                    .HasName("PK__Cars__1439FCAC94ED4417");

                entity.Property(e => e.Carid)
                    .HasColumnName("carid")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnName("brand")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Engine)
                    .IsRequired()
                    .HasColumnName("engine")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Yearmade)
                    .HasColumnName("yearmade")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Rents>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Confirmation)
                    .HasColumnName("confirmation")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rentperiod)
                    .HasColumnName("rentperiod")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Users__CBA1B2576F191C0F");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FkCarid)
                    .HasColumnName("fk_carid")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Joiningdate)
                    .HasColumnName("joiningdate")
                    .HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkCar)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkCarid)
                    .HasConstraintName("FK__Users__fk_carid__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
