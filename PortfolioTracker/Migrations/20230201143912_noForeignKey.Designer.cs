﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioTracker.Models;

#nullable disable

namespace PortfolioTracker.Migrations
{
    [DbContext(typeof(TrackerContext))]
    [Migration("20230201143912_noForeignKey")]
    partial class noForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PortfolioTracker.Models.Coin", b =>
                {
                    b.Property<Guid>("CoinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PortfolioportfpolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalBuyingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalCoins")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CoinId");

                    b.HasIndex("PortfolioportfpolioId");

                    b.ToTable("Coins");
                });

            modelBuilder.Entity("PortfolioTracker.Models.Portfolio", b =>
                {
                    b.Property<Guid>("portfpolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("portfolioName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("totalBalance")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("portfpolioId");

                    b.HasIndex("UserName");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("PortfolioTracker.Models.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoinId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Fees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PricePerCoin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSpent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionId");

                    b.HasIndex("CoinId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("PortfolioTracker.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PortfolioTracker.Models.Coin", b =>
                {
                    b.HasOne("PortfolioTracker.Models.Portfolio", "Portfolio")
                        .WithMany("coins")
                        .HasForeignKey("PortfolioportfpolioId");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("PortfolioTracker.Models.Portfolio", b =>
                {
                    b.HasOne("PortfolioTracker.Models.User", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserName");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PortfolioTracker.Models.Transaction", b =>
                {
                    b.HasOne("PortfolioTracker.Models.Coin", "Coin")
                        .WithMany("Transactions")
                        .HasForeignKey("CoinId");

                    b.Navigation("Coin");
                });

            modelBuilder.Entity("PortfolioTracker.Models.Coin", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("PortfolioTracker.Models.Portfolio", b =>
                {
                    b.Navigation("coins");
                });

            modelBuilder.Entity("PortfolioTracker.Models.User", b =>
                {
                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}
