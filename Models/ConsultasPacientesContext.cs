using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDPRUEBA3.Models;

public partial class ConsultasPacientesContext : DbContext
{
    public ConsultasPacientesContext()
    {
    }

    public ConsultasPacientesContext(DbContextOptions<ConsultasPacientesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-81LONTD;Database=ConsultasPacientes ;Trusted_Connection=True; integrated security=true; TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctor__3214EC070FCC98A5");

            entity.ToTable("Doctor");

            entity.Property(e => e.Especialidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Hospital)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paciente__3214EC07B61A1D0E");

            entity.ToTable("Paciente");

            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdDoctor)
                .HasConstraintName("FK__Paciente__IdDoct__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
