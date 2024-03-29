﻿// <auto-generated />
using System;
using ConcertTicketsBookingSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConcertTicketsBookingSystem.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221202203242_NewState")]
    partial class NewState
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.Concerts.Concert", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dataTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("performer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ticketsNum")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("concerts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Concert");
                });

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.PromoCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConcertId")
                        .HasColumnType("int");

                    b.Property<byte>("ProcentNum")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ConcertId");

                    b.ToTable("promoCodes");
                });

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.Roles.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.Roles.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConcertId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConcertId");

                    b.HasIndex("OwnerId");

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.Concerts.ClassicConcert", b =>
                {
                    b.HasBaseType("ConcertTicketsBookingSystem.Models.Concerts.Concert");

                    b.Property<string>("compositor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("voiceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ClassicConcert");
                });

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.Concerts.OpenAirConcert", b =>
                {
                    b.HasBaseType("ConcertTicketsBookingSystem.Models.Concerts.Concert");

                    b.Property<string>("headliner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("OpenAirConcert");
                });

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.Concerts.PartyConcert", b =>
                {
                    b.HasBaseType("ConcertTicketsBookingSystem.Models.Concerts.Concert");

                    b.Property<byte>("ageLimit")
                        .HasColumnType("tinyint");

                    b.HasDiscriminator().HasValue("PartyConcert");
                });

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.PromoCode", b =>
                {
                    b.HasOne("ConcertTicketsBookingSystem.Models.Concerts.Concert", "Concert")
                        .WithMany()
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");
                });

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.Ticket", b =>
                {
                    b.HasOne("ConcertTicketsBookingSystem.Models.Concerts.Concert", "Concert")
                        .WithMany()
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConcertTicketsBookingSystem.Models.Roles.User", "Owner")
                        .WithMany("Tickets")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ConcertTicketsBookingSystem.Models.Roles.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
