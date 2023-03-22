using MedicoApp.Core.Domain.Common;
using MedicoApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<PruebaDeLab> PruebaDeLab { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ResultDeLab> ResultDeLab { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables

            modelBuilder.Entity<Medicos>()
                .ToTable("Medicos");

            modelBuilder.Entity<Pacientes>()
                .ToTable("Pacientes");

            modelBuilder.Entity<PruebaDeLab>()
               .ToTable("PruebaDeLab");

            modelBuilder.Entity<Citas>()
               .ToTable("Citas");

            modelBuilder.Entity<ResultDeLab>()
               .ToTable("ResultDeLab");

            modelBuilder.Entity<User>()
               .ToTable("Users");

            #endregion
            #region "primary keys"
            modelBuilder.Entity<Medicos>()
                .HasKey(medicos => medicos.Id);

            modelBuilder.Entity<Pacientes>()
                .HasKey(pacientes => pacientes.Id);

            modelBuilder.Entity<PruebaDeLab>()
                .HasKey(pruebaDeLab => pruebaDeLab.Id);

            modelBuilder.Entity<Citas>()
               .HasKey(citas => citas.Id);

            modelBuilder.Entity<ResultDeLab>()
               .HasKey(resultDeLab => resultDeLab.Id);

            modelBuilder.Entity<User>()
              .HasKey(user => user.Id);
            #endregion

            #region "Relationships"
            modelBuilder.Entity<Medicos>().HasMany<Citas>(medicos => medicos.Citas)
                          .WithOne(cita => cita.Medicos).HasForeignKey(cita => cita.MedicosId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pacientes>().HasMany<Citas>(pacientes => pacientes.Citas)
                          .WithOne(cita => cita.Pacientes).HasForeignKey(cita => cita.PacientesId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pacientes>().HasMany<ResultDeLab>(pacientes => pacientes.ResultDeLab)
                          .WithOne(ResultDeLab => ResultDeLab.Pacientes).HasForeignKey(ResultDeLab => ResultDeLab.PacienteId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PruebaDeLab>().HasMany<ResultDeLab>(pruebadelab => pruebadelab.ResultDeLab)
                         .WithOne(ResultDeLab => ResultDeLab.PruebaDeLab).HasForeignKey(ResultDeLab => ResultDeLab.PruebaDeLabId).OnDelete(DeleteBehavior.Cascade);

            



            #endregion

            #region "Property configurations"
            #region Medicos
            modelBuilder.Entity<Medicos>().
               Property(medicos => medicos.Name)
               .IsRequired();

            modelBuilder.Entity<Medicos>().
               Property(medicos => medicos.Apellido)
               .IsRequired();

            modelBuilder.Entity<Medicos>().
               Property(medicos => medicos.Cedula)
               .IsRequired();

            modelBuilder.Entity<Medicos>().
               Property(medicos => medicos.Phone)
               .IsRequired();

            modelBuilder.Entity<Medicos>().
               Property(medicos => medicos.Email)
               .IsRequired();


            #endregion
            #region Pacientes
            modelBuilder.Entity<Pacientes>().
               Property(pacientes => pacientes.Name)
               .IsRequired();

            modelBuilder.Entity<Pacientes>().
               Property(pacientes => pacientes.Apellido)
               .IsRequired();

            modelBuilder.Entity<Pacientes>().
               Property(pacientes => pacientes.Phone)
               .IsRequired();

            modelBuilder.Entity<Pacientes>().
               Property(pacientes => pacientes.Direccion)
               .IsRequired();

            modelBuilder.Entity<Pacientes>().
              Property(pacientes => pacientes.Fumador)
              .IsRequired();

            modelBuilder.Entity<Pacientes>().
              Property(pacientes => pacientes.Alergias)
              .IsRequired();
            modelBuilder.Entity<Pacientes>().
             Property(pacientes => pacientes.FechaNacimiento)
             .IsRequired();

            modelBuilder.Entity<Pacientes>().
              Property(pacientes => pacientes.Cedula)
              .IsRequired().HasMaxLength(100);

            #endregion

            #region PruebaDeLab
            modelBuilder.Entity<PruebaDeLab>().
               Property(pruebaDeLab => pruebaDeLab.Name)
               .IsRequired();
            #endregion

            #region Citas
            modelBuilder.Entity<Citas>().
              Property(citas => citas.Name)
              .IsRequired();

            modelBuilder.Entity<Citas>().
              Property(citas => citas.FechaDeLaCita)
              .IsRequired();

            modelBuilder.Entity<Citas>().
              Property(citas => citas.HoraDeLaCita)
              .IsRequired();

            modelBuilder.Entity<Citas>().
              Property(citas => citas.MedicosId)
              .IsRequired();

            modelBuilder.Entity<Citas>().
              Property(citas => citas.PacientesId)
              .IsRequired();
            #endregion
            #region ResultDeLab
            modelBuilder.Entity<ResultDeLab>().
              Property(resultDeLab => resultDeLab.Id)
              .IsRequired();
            modelBuilder.Entity<ResultDeLab>().
             Property(resultDeLab => resultDeLab.Name)
             .IsRequired();
            modelBuilder.Entity<ResultDeLab>().
             Property(resultDeLab => resultDeLab.Apellido)
             .IsRequired();


            modelBuilder.Entity<ResultDeLab>().
              Property(resultDeLab => resultDeLab.PacienteId)
              .IsRequired();

            modelBuilder.Entity<ResultDeLab>().
              Property(resultDeLab => resultDeLab.PruebaDeLabId)
              .IsRequired();


            #endregion
            #region Users
            modelBuilder.Entity<User>().
              Property(user => user.Username)
              .IsRequired();

            modelBuilder.Entity<User>().
              Property(user => user.Name)
              .IsRequired();

            modelBuilder.Entity<User>().
              Property(user => user.Password)
              .IsRequired();

            modelBuilder.Entity<User>().
              Property(user => user.Email)
              .IsRequired();

            modelBuilder.Entity<User>().
              Property(user => user.Apellido)
              .IsRequired();
            #endregion
            #endregion
        }
    }
}
