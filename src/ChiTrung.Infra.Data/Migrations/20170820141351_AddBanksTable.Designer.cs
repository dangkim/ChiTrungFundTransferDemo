﻿// <auto-generated />
using ChiTrung.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ChiTrung.Infra.Data.Migrations
{
    [DbContext(typeof(ChiTrungContext))]
    [Migration("20170820141351_AddBanksTable")]
    partial class AddBanksTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChiTrung.Domain.Models.Account", b =>
                {
                    b.Property<string>("AccCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("BankCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CusId")
                        .IsRequired()
                        .HasColumnName("CusId");

                    b.HasKey("AccCode");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("ChiTrung.Domain.Models.Atm", b =>
                {
                    b.Property<string>("AtmCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("AtmName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("BankCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("AtmCode");

                    b.ToTable("Atm");
                });

            modelBuilder.Entity("ChiTrung.Domain.Models.Bank", b =>
                {
                    b.Property<string>("BankCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("BankCode");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("ChiTrung.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(11);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ChiTrung.Domain.Models.Deposit", b =>
                {
                    b.Property<int>("DepCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("CusId")
                        .IsRequired()
                        .HasColumnName("CusId");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("WitCode");

                    b.HasKey("DepCode");

                    b.ToTable("Deposit");
                });

            modelBuilder.Entity("ChiTrung.Domain.Models.Withdrawal", b =>
                {
                    b.Property<string>("WitCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("AtmCode")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("TransactionDate");

                    b.HasKey("WitCode");

                    b.ToTable("Withdrawal");
                });
#pragma warning restore 612, 618
        }
    }
}
