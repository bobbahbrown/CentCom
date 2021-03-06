﻿// <auto-generated />
using System;
using CentCom.Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CentCom.Common.Migrations.MySql
{
    [DbContext(typeof(MySqlDbContext))]
    [Migration("20200729172826_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CentCom.Common.Models.Ban", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("BanID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<uint>("BanType")
                        .HasColumnType("int unsigned");

                    b.Property<string>("BannedBy")
                        .IsRequired()
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.Property<DateTime>("BannedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("CID")
                        .HasColumnType("bigint");

                    b.Property<string>("CKey")
                        .IsRequired()
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IP")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Reason")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Source")
                        .HasColumnType("int");

                    b.Property<string>("UnbannedBy")
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("CKey");

                    b.HasIndex("Source");

                    b.ToTable("Bans");
                });

            modelBuilder.Entity("CentCom.Common.Models.BanSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Display")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<uint>("RoleplayLevel")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.ToTable("BanSources");
                });

            modelBuilder.Entity("CentCom.Common.Models.JobBan", b =>
                {
                    b.Property<int>("BanId")
                        .HasColumnType("int");

                    b.Property<string>("Job")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("BanId", "Job");

                    b.ToTable("JobBans");
                });

            modelBuilder.Entity("CentCom.Common.Models.Ban", b =>
                {
                    b.HasOne("CentCom.Common.Models.BanSource", "SourceNavigation")
                        .WithMany("Bans")
                        .HasForeignKey("Source")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CentCom.Common.Models.JobBan", b =>
                {
                    b.HasOne("CentCom.Common.Models.Ban", "BanNavigation")
                        .WithMany("JobBans")
                        .HasForeignKey("BanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
