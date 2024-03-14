using MapDataVisualizer.App.Db.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.App.Db.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TrainingEntity> Trainings { get; set; }
        public DbSet<SoldierTrainingAssignmentEntity> SoldierTrainingAssignments { get; set; }
        public DbSet<SoldierEntity> Soldiers { get; set; }
        public DbSet<SensorSoldierAssignmentEntity> SensorSoldierAssignments {get;set;}
        public DbSet<SensorEntity> Sensors { get; set; }
        public DbSet<SensorDataEntity> SensorData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingEntity>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<TrainingEntity>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<TrainingEntity>()
                .HasMany(e => e.SoldierAssignments)
                .WithOne(e => e.Training)
                .HasPrincipalKey(e => e.Id)
                .HasForeignKey(e => e.TrainingId);

            modelBuilder.Entity<SoldierTrainingAssignmentEntity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<SoldierEntity>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<SoldierEntity>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<SoldierEntity>()
                .Property(e => e.Rank)
                .IsRequired();
            modelBuilder.Entity<SoldierEntity>()
                .HasMany(e => e.TrainingAssignments)
                .WithOne(e => e.Soldier)
                .HasPrincipalKey(e => e.Id)
                .HasForeignKey(e => e.SoldierId);

            modelBuilder.Entity<SensorSoldierAssignmentEntity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<SensorEntity>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<SensorEntity>()
                .HasMany(e => e.SoldierAssignments)
                .WithOne(e => e.Sensor)
                .HasPrincipalKey(e => e.Id)
                .HasForeignKey(e => e.SensorId);
            modelBuilder.Entity<SensorEntity>()
                .Property(e => e.SerialNumber)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<SensorEntity>()
                .HasMany(e => e.SensorData)
                .WithOne(e => e.Sensor)
                .HasPrincipalKey(e => e.Id)
                .HasForeignKey(e => e.SensorId);
            modelBuilder.Entity<SensorEntity>()
                .HasIndex(e => e.SerialNumber)
                .IsUnique();

            modelBuilder.Entity<SensorDataEntity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<SensorDataEntity>()
                .HasIndex(e => e.Received);            
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
