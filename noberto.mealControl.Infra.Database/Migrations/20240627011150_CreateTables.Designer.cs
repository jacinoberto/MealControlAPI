﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using noberto.mealControl.Infra.Database.Context;

#nullable disable

namespace noberto.mealControl.Infra.Database.Migrations
{
    [DbContext(typeof(MealControlDbContext))]
    [Migration("20240627011150_CreateTables")]
    partial class CreateTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_address");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("area");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("city");

                    b.Property<string>("Complement")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("complement");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("street");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id");

                    b.ToTable("tb_addresses", (string)null);
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Administrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_administrator");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("tb_administrators", (string)null);
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_manager");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("tb_managers", (string)null);
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_meal");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("uuid")
                        .HasColumnName("administrator_id");

                    b.Property<bool>("Coffe")
                        .HasColumnType("boolean")
                        .HasColumnName("coffe");

                    b.Property<bool>("Dinner")
                        .HasColumnType("boolean")
                        .HasColumnName("dinner");

                    b.Property<bool>("Lunch")
                        .HasColumnType("boolean")
                        .HasColumnName("lunch");

                    b.Property<Guid>("ShecheduleLocalEventId")
                        .HasColumnType("uuid")
                        .HasColumnName("schedule_local_event_id");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid")
                        .HasColumnName("team_id");

                    b.HasKey("Id")
                        .HasName("id_meal");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("ShecheduleLocalEventId");

                    b.HasIndex("TeamId");

                    b.ToTable("tb_meals", (string)null);
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.ScheduleEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_team");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("uuid")
                        .HasColumnName("administrator_id");

                    b.Property<bool>("Atypical")
                        .HasColumnType("boolean")
                        .HasColumnName("atypical");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<DateOnly>("MealDate")
                        .HasColumnType("date")
                        .HasColumnName("meal_date");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("tb_schedule_events", (string)null);
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.ScheduleLocalEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_schedule_event");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("uuid")
                        .HasColumnName("administrator_id");

                    b.Property<Guid>("ScheduleEventId")
                        .HasColumnType("uuid")
                        .HasColumnName("schedule_event_id");

                    b.Property<Guid>("WorkId")
                        .HasColumnType("uuid")
                        .HasColumnName("work_id");

                    b.HasKey("Id")
                        .HasName("id_schedule_local_event");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("ScheduleEventId");

                    b.HasIndex("WorkId");

                    b.ToTable("tb_schedule_local_events", (string)null);
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_team");

                    b.Property<bool>("ActiveTeam")
                        .HasColumnType("boolean")
                        .HasColumnName("active_team");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("uuid")
                        .HasColumnName("administrator_id");

                    b.Property<Guid>("TeamManagementId")
                        .HasColumnType("uuid")
                        .HasColumnName("manage_team_id");

                    b.Property<Guid>("WorkerId")
                        .HasColumnType("uuid")
                        .HasColumnName("worker_id");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("TeamManagementId");

                    b.HasIndex("WorkerId");

                    b.ToTable("tb_teams", (string)null);
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.TeamManagement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_teamManagement");

                    b.Property<bool>("ActiveTeam")
                        .HasColumnType("boolean")
                        .HasColumnName("active_team");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("uuid")
                        .HasColumnName("administrator_id");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uuid")
                        .HasColumnName("manager_id");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("sector");

                    b.Property<Guid>("WorkId")
                        .HasColumnType("uuid")
                        .HasColumnName("work_id");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("WorkId");

                    b.ToTable("tb_team_management", (string)null);
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Work", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_work");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("uuid")
                        .HasColumnName("administrator_id");

                    b.Property<DateOnly?>("ClosingDate")
                        .HasColumnType("date")
                        .HasColumnName("closing_date");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("identification");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AdministratorId");

                    b.ToTable("tb_works", (string)null);
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_worker");

                    b.Property<bool>("ActiveProfile")
                        .HasColumnType("boolean")
                        .HasColumnName("active_profile");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)")
                        .HasColumnName("registration");

                    b.HasKey("Id");

                    b.ToTable("tb_workers", (string)null);
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Administrator", b =>
                {
                    b.HasOne("noberto.mealControl.Core.Entities.Address", "Address")
                        .WithMany("Administrators")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("noberto.mealControl.Core.Entity.User", "User", b1 =>
                        {
                            b1.Property<Guid>("AdministratorId")
                                .HasColumnType("uuid");

                            b1.Property<bool>("ActiveProfile")
                                .HasColumnType("boolean")
                                .HasColumnName("active_profile");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("character varying(150)")
                                .HasColumnName("email");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("name");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("password");

                            b1.Property<string>("Registration")
                                .IsRequired()
                                .HasMaxLength(9)
                                .HasColumnType("character varying(9)")
                                .HasColumnName("registration");

                            b1.HasKey("AdministratorId");

                            b1.HasIndex("Email")
                                .IsUnique();

                            b1.HasIndex("Registration")
                                .IsUnique();

                            b1.ToTable("tb_administrators");

                            b1.WithOwner()
                                .HasForeignKey("AdministratorId");
                        });

                    b.Navigation("Address");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Manager", b =>
                {
                    b.HasOne("noberto.mealControl.Core.Entities.Address", "Address")
                        .WithMany("Managers")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("noberto.mealControl.Core.Entity.User", "User", b1 =>
                        {
                            b1.Property<Guid>("ManagerId")
                                .HasColumnType("uuid");

                            b1.Property<bool>("ActiveProfile")
                                .HasColumnType("boolean")
                                .HasColumnName("active_profile");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("character varying(150)")
                                .HasColumnName("email");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("name");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("password");

                            b1.Property<string>("Registration")
                                .IsRequired()
                                .HasMaxLength(9)
                                .HasColumnType("character varying(9)")
                                .HasColumnName("registration");

                            b1.HasKey("ManagerId");

                            b1.HasIndex("Email")
                                .IsUnique();

                            b1.HasIndex("Registration")
                                .IsUnique();

                            b1.ToTable("tb_managers");

                            b1.WithOwner()
                                .HasForeignKey("ManagerId");
                        });

                    b.Navigation("Address");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Meal", b =>
                {
                    b.HasOne("noberto.mealControl.Core.Entities.Administrator", "Administrator")
                        .WithMany("Meals")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("noberto.mealControl.Core.Entities.ScheduleLocalEvent", "ScheduleLocalEvent")
                        .WithMany("Meals")
                        .HasForeignKey("ShecheduleLocalEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("noberto.mealControl.Core.Entities.Team", "Team")
                        .WithMany("Meals")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("ScheduleLocalEvent");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.ScheduleEvent", b =>
                {
                    b.HasOne("noberto.mealControl.Core.Entities.Administrator", "Administrator")
                        .WithMany("ScheduleEvents")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.ScheduleLocalEvent", b =>
                {
                    b.HasOne("noberto.mealControl.Core.Entities.Administrator", "Administrator")
                        .WithMany("ScheduleLocalEvents")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("noberto.mealControl.Core.Entities.ScheduleEvent", "ScheduleEvent")
                        .WithMany("ScheduleLocalEvents")
                        .HasForeignKey("ScheduleEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("noberto.mealControl.Core.Entities.Work", "Work")
                        .WithMany("ScheduleLocalEvents")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("ScheduleEvent");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Team", b =>
                {
                    b.HasOne("noberto.mealControl.Core.Entities.Administrator", "Administrator")
                        .WithMany("Teams")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("noberto.mealControl.Core.Entities.TeamManagement", "TeamManagement")
                        .WithMany("Teams")
                        .HasForeignKey("TeamManagementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("noberto.mealControl.Core.Entities.Worker", "Worker")
                        .WithMany("Teams")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("TeamManagement");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.TeamManagement", b =>
                {
                    b.HasOne("noberto.mealControl.Core.Entities.Administrator", "Administrator")
                        .WithMany("TeamManagement")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("noberto.mealControl.Core.Entities.Manager", "Manager")
                        .WithMany("TeamManagement")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("noberto.mealControl.Core.Entities.Work", "Work")
                        .WithMany("TeamManagemant")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("Manager");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Work", b =>
                {
                    b.HasOne("noberto.mealControl.Core.Entities.Address", "Address")
                        .WithMany("Works")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("noberto.mealControl.Core.Entities.Administrator", "Administrator")
                        .WithMany("Works")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Address", b =>
                {
                    b.Navigation("Administrators");

                    b.Navigation("Managers");

                    b.Navigation("Works");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Administrator", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("ScheduleEvents");

                    b.Navigation("ScheduleLocalEvents");

                    b.Navigation("TeamManagement");

                    b.Navigation("Teams");

                    b.Navigation("Works");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Manager", b =>
                {
                    b.Navigation("TeamManagement");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.ScheduleEvent", b =>
                {
                    b.Navigation("ScheduleLocalEvents");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.ScheduleLocalEvent", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Team", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.TeamManagement", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Work", b =>
                {
                    b.Navigation("ScheduleLocalEvents");

                    b.Navigation("TeamManagemant");
                });

            modelBuilder.Entity("noberto.mealControl.Core.Entities.Worker", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
