﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteVector.Infra.Data.Context;

#nullable disable

namespace TesteVector.Infra.Data.Migrations
{
    [DbContext(typeof(TesteVectorContext))]
    [Migration("20220706202920_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TesteVector.Domain.Models.Entities.AccessHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AccessDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AccessHistory", (string)null);
                });

            modelBuilder.Entity("TesteVector.Domain.Models.Entities.Email", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessHistoryId")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccessHistoryId");

                    b.ToTable("Email", (string)null);
                });

            modelBuilder.Entity("TesteVector.Domain.Models.Entities.Email", b =>
                {
                    b.HasOne("TesteVector.Domain.Models.Entities.AccessHistory", "AccessHistory")
                        .WithMany("Emails")
                        .HasForeignKey("AccessHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessHistory");
                });

            modelBuilder.Entity("TesteVector.Domain.Models.Entities.AccessHistory", b =>
                {
                    b.Navigation("Emails");
                });
#pragma warning restore 612, 618
        }
    }
}