using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace U2Act3_MapaCurricular.Models
{
    public partial class Mapa_CurricularContext : DbContext
    {
        public Mapa_CurricularContext()
        {
        }

        public Mapa_CurricularContext(DbContextOptions<Mapa_CurricularContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=Mapa_Curricular;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.ToTable("carreras");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Clave, "Clave_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Clave)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Especialidad).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.Plan)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.ToTable("materias");

                entity.HasIndex(e => e.IdCarrera, "fkmat_idx1");

                entity.Property(e => e.Clave)
                    .HasMaxLength(8)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nombre).HasMaxLength(65);

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkmat");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
