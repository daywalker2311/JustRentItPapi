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

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Rents> Rents { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
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

                entity.Property(e => e.FkUserid)
                    .HasColumnName("fk_userid")
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

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.FkUserid)
                    .HasConstraintName("FK__Cars__fk_userid__3D5E1FD2");
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

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Users__CBA1B2574E3B41B7");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(1)
                    .IsUnicode(false);

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
