using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace U3Act1AlumnadoPrueba.Models
{
    public partial class AlumnadoContext : DbContext
    {
        public AlumnadoContext()
        {
        }

        public AlumnadoContext(DbContextOptions<AlumnadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; } = null!;
        public virtual DbSet<Carrera> Carrera { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=Alumnado;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.Control)
                    .HasName("PRIMARY");

                entity.ToTable("alumnos");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Idcarrera, "FK_alumnos_1");

                entity.Property(e => e.Control)
                    .HasMaxLength(10)
                    .HasColumnName("control");

                entity.Property(e => e.Entrada).HasColumnName("entrada");

                entity.Property(e => e.Idcarrera)
                    .HasMaxLength(1)
                    .HasColumnName("idcarrera")
                    .IsFixedLength();

                entity.Property(e => e.Materno)
                    .HasMaxLength(45)
                    .HasColumnName("materno");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.Paterno)
                    .HasMaxLength(45)
                    .HasColumnName("paterno");

                entity.Property(e => e.Sexo).HasColumnName("sexo");

                entity.HasOne(d => d.IdcarreraNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.Idcarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_alumnos_1");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.Clave)
                    .HasName("PRIMARY");

                entity.ToTable("carrera");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Clave)
                    .HasMaxLength(1)
                    .HasColumnName("clave")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
