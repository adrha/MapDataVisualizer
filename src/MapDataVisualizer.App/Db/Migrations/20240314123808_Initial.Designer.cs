﻿// <auto-generated />
using System;
using MapDataVisualizer.App.Db.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MapDataVisualizer.App.Db.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240314123808_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.SensorDataEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Long")
                        .HasColumnType("float");

                    b.Property<DateTime>("Received")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SensorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Received");

                    b.HasIndex("SensorId");

                    b.ToTable("SensorData");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.SensorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.SensorSoldierAssignmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SensorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SoldierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.HasIndex("SoldierId");

                    b.ToTable("SensorSoldierAssignments");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.SoldierEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Soldiers");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.SoldierTrainingAssignmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SoldierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SoldierId");

                    b.HasIndex("TrainingId");

                    b.ToTable("SoldierTrainingAssignments");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.TrainingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.SensorDataEntity", b =>
                {
                    b.HasOne("MapDataVisualizer.App.Db.Entity.SensorEntity", "Sensor")
                        .WithMany("SensorData")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.SensorSoldierAssignmentEntity", b =>
                {
                    b.HasOne("MapDataVisualizer.App.Db.Entity.SensorEntity", "Sensor")
                        .WithMany("SoldierAssignments")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MapDataVisualizer.App.Db.Entity.SoldierEntity", "Soldier")
                        .WithMany("SensorAssignments")
                        .HasForeignKey("SoldierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");

                    b.Navigation("Soldier");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.SoldierTrainingAssignmentEntity", b =>
                {
                    b.HasOne("MapDataVisualizer.App.Db.Entity.SoldierEntity", "Soldier")
                        .WithMany("TrainingAssignments")
                        .HasForeignKey("SoldierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MapDataVisualizer.App.Db.Entity.TrainingEntity", "Training")
                        .WithMany("SoldierAssignments")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Soldier");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.SensorEntity", b =>
                {
                    b.Navigation("SensorData");

                    b.Navigation("SoldierAssignments");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.SoldierEntity", b =>
                {
                    b.Navigation("SensorAssignments");

                    b.Navigation("TrainingAssignments");
                });

            modelBuilder.Entity("MapDataVisualizer.App.Db.Entity.TrainingEntity", b =>
                {
                    b.Navigation("SoldierAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
