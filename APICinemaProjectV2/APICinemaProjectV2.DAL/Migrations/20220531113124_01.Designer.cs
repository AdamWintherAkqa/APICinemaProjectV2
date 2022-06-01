﻿// <auto-generated />
using System;
using APICinemaProject2.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APICinemaProjectV2.DAL.Migrations
{
    [DbContext(typeof(AbContext))]
    [Migration("20220531113124_01")]
    partial class _01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Actor", b =>
                {
                    b.Property<int>("ActorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorID");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.CandyShop", b =>
                {
                    b.Property<int>("CandyShopID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CandyShopName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CandyShopPrice")
                        .HasColumnType("int");

                    b.Property<string>("CandyShopType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CandyShopID");

                    b.ToTable("CandyShops");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomerGender")
                        .HasColumnType("bit");

                    b.Property<bool>("CustomerIsVIP")
                        .HasColumnType("bit");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Hall", b =>
                {
                    b.Property<int>("HallID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("HallNumber")
                        .HasColumnType("int");

                    b.HasKey("HallID");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InstructorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorID");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.LoyaltyProgram", b =>
                {
                    b.Property<int>("LoyaltyProgramID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("LoyaltyProgramID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("OrderID");

                    b.ToTable("LoyaltyPrograms");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Merchandise", b =>
                {
                    b.Property<int>("MerchandiseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MerchandiseColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MerchandiseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MerchandisePrice")
                        .HasColumnType("int");

                    b.Property<string>("MerchandiseSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MerchandiseStock")
                        .HasColumnType("int");

                    b.Property<string>("MerchandiseType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MerchandiseID");

                    b.ToTable("Merchandises");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HallID")
                        .HasColumnType("int");

                    b.Property<int>("InstructorID")
                        .HasColumnType("int");

                    b.Property<int>("MovieAgeLimit")
                        .HasColumnType("int");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MoviePlayTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("MovieReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MovieID");

                    b.HasIndex("HallID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.MovieTime", b =>
                {
                    b.Property<int>("MovieTimeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HallID")
                        .HasColumnType("int");

                    b.Property<int?>("MovieID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("MovieTimeID");

                    b.HasIndex("HallID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieTimes");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AgeCheck")
                        .HasColumnType("bit");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieTimeID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("MovieTimeID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Seat", b =>
                {
                    b.Property<int>("SeatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HallID")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<string>("SeatRowLetter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeatID");

                    b.HasIndex("HallID");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.Property<int>("ActorsActorID")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMovieID")
                        .HasColumnType("int");

                    b.HasKey("ActorsActorID", "MoviesMovieID");

                    b.HasIndex("MoviesMovieID");

                    b.ToTable("ActorMovie");
                });

            modelBuilder.Entity("CandyShopOrder", b =>
                {
                    b.Property<int>("CandyShopsCandyShopID")
                        .HasColumnType("int");

                    b.Property<int>("OrdersOrderID")
                        .HasColumnType("int");

                    b.HasKey("CandyShopsCandyShopID", "OrdersOrderID");

                    b.HasIndex("OrdersOrderID");

                    b.ToTable("CandyShopOrder");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMovieID")
                        .HasColumnType("int");

                    b.HasKey("GenreID", "MoviesMovieID");

                    b.HasIndex("MoviesMovieID");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("MerchandiseOrder", b =>
                {
                    b.Property<int>("MerchandiseID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("MerchandiseID", "OrderID");

                    b.HasIndex("OrderID");

                    b.ToTable("MerchandiseOrder");
                });

            modelBuilder.Entity("OrderSeat", b =>
                {
                    b.Property<int>("OrdersOrderID")
                        .HasColumnType("int");

                    b.Property<int>("SeatsSeatID")
                        .HasColumnType("int");

                    b.HasKey("OrdersOrderID", "SeatsSeatID");

                    b.HasIndex("SeatsSeatID");

                    b.ToTable("OrderSeat");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.LoyaltyProgram", b =>
                {
                    b.HasOne("APICinemaProject2.DAL.Database.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICinemaProject2.DAL.Database.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Movie", b =>
                {
                    b.HasOne("APICinemaProject2.DAL.Database.Models.Hall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICinemaProject2.DAL.Database.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.MovieTime", b =>
                {
                    b.HasOne("APICinemaProject2.DAL.Database.Models.Hall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICinemaProject2.DAL.Database.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieID");

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Order", b =>
                {
                    b.HasOne("APICinemaProject2.DAL.Database.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.HasOne("APICinemaProject2.DAL.Database.Models.MovieTime", "MovieTime")
                        .WithMany()
                        .HasForeignKey("MovieTimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("MovieTime");
                });

            modelBuilder.Entity("APICinemaProject2.DAL.Database.Models.Seat", b =>
                {
                    b.HasOne("APICinemaProject2.DAL.Database.Models.Hall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallID");

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.HasOne("APICinemaProject2.DAL.Database.Models.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsActorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICinemaProject2.DAL.Database.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CandyShopOrder", b =>
                {
                    b.HasOne("APICinemaProject2.DAL.Database.Models.CandyShop", null)
                        .WithMany()
                        .HasForeignKey("CandyShopsCandyShopID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICinemaProject2.DAL.Database.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("APICinemaProject2.DAL.Database.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICinemaProject2.DAL.Database.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MerchandiseOrder", b =>
                {
                    b.HasOne("APICinemaProject2.DAL.Database.Models.Merchandise", null)
                        .WithMany()
                        .HasForeignKey("MerchandiseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICinemaProject2.DAL.Database.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderSeat", b =>
                {
                    b.HasOne("APICinemaProject2.DAL.Database.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APICinemaProject2.DAL.Database.Models.Seat", null)
                        .WithMany()
                        .HasForeignKey("SeatsSeatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}