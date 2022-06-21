﻿// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Argentina"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Brasil"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chile"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Paraguay"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Uruguay"
                        });
                });

            modelBuilder.Entity("Api.Data.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Api.Data.PostUsersLikes", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PostsUserLikes");
                });

            modelBuilder.Entity("Api.Data.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            CountryId = 1,
                            Name = "Buenos Aires"
                        },
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Córdoba"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Tucumán"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "Santa Fé"
                        });
                });

            modelBuilder.Entity("Api.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Api.Data.Post", b =>
                {
                    b.HasOne("Api.Data.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Data.PostUsersLikes", b =>
                {
                    b.HasOne("Api.Data.Post", "Post")
                        .WithMany("PostUsersLiked")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Data.User", "User")
                        .WithMany("PostUsersLiked")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Data.Province", b =>
                {
                    b.HasOne("Api.Data.Country", "Country")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Api.Data.User", b =>
                {
                    b.OwnsOne("Api.Data.Address", "Address", b1 =>
                        {
                            b1.Property<int?>("UserId")
                                .HasColumnType("integer");

                            b1.Property<string>("Direction")
                                .HasColumnType("text");

                            b1.Property<int>("Id")
                                .HasColumnType("integer");

                            b1.Property<int?>("ProvinceId")
                                .HasColumnType("integer");

                            b1.HasKey("UserId");

                            b1.HasIndex("ProvinceId");

                            b1.ToTable("Addresses");

                            b1.HasOne("Api.Data.Province", "Province")
                                .WithMany()
                                .HasForeignKey("ProvinceId");

                            b1.WithOwner("User")
                                .HasForeignKey("UserId");

                            b1.Navigation("Province");

                            b1.Navigation("User");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Data.Country", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("Api.Data.Post", b =>
                {
                    b.Navigation("PostUsersLiked");
                });

            modelBuilder.Entity("Api.Data.User", b =>
                {
                    b.Navigation("PostUsersLiked");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
