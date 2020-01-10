using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api_adusers.Models
{
    public partial class AdUsersContext : DbContext
    {
        public AdUsersContext()
        {
        }

        public AdUsersContext(DbContextOptions<AdUsersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Deletiondate)
                    .HasColumnName("deletiondate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Displayname).HasColumnName("displayname");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Expirable).HasColumnName("expirable");

                entity.Property(e => e.Extension).HasColumnName("extension");

                entity.Property(e => e.Firstname).HasColumnName("firstname");

                entity.Property(e => e.GroupList).HasColumnName("groupList");

                entity.Property(e => e.Lastlogin)
                    .HasColumnName("lastlogin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("lastupdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Office).HasColumnName("office");

                entity.Property(e => e.Ou).HasColumnName("ou");

                entity.Property(e => e.Passwordlastset)
                    .HasColumnName("passwordlastset")
                    .HasColumnType("datetime");

                entity.Property(e => e.Program).HasColumnName("program");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Username).HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
