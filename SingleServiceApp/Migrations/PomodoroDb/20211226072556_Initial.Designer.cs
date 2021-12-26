﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SingleServiceApp.Providers.Pomodoros;

#nullable disable

namespace SingleServiceApp.Migrations.PomodoroDb
{
    [DbContext(typeof(PomodoroDbContext))]
    [Migration("20211226072556_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SingleServiceApp.Bll.Pomodoros.Pomodoro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pomodoros");
                });

            modelBuilder.Entity("SingleServiceApp.Bll.Pomodoros.Pomodoro", b =>
                {
                    b.OwnsOne("SingleServiceApp.Bll.Pomodoros.Duration", "RestDuration", b1 =>
                        {
                            b1.Property<Guid>("PomodoroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Hours")
                                .HasColumnType("int")
                                .HasColumnName("RestHours");

                            b1.Property<int>("Minutes")
                                .HasColumnType("int")
                                .HasColumnName("RestMinutes");

                            b1.HasKey("PomodoroId");

                            b1.ToTable("Pomodoros");

                            b1.WithOwner()
                                .HasForeignKey("PomodoroId");
                        });

                    b.OwnsOne("SingleServiceApp.Bll.Pomodoros.Duration", "WorkDuration", b1 =>
                        {
                            b1.Property<Guid>("PomodoroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Hours")
                                .HasColumnType("int")
                                .HasColumnName("WorkHours");

                            b1.Property<int>("Minutes")
                                .HasColumnType("int")
                                .HasColumnName("WorkMinutes");

                            b1.HasKey("PomodoroId");

                            b1.ToTable("Pomodoros");

                            b1.WithOwner()
                                .HasForeignKey("PomodoroId");
                        });

                    b.Navigation("RestDuration");

                    b.Navigation("WorkDuration");
                });
#pragma warning restore 612, 618
        }
    }
}
