﻿// <auto-generated />
using System;
using Fut360.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fut360.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fut360.Models.AgendamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aprovado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataHoraFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInicial")
                        .HasColumnType("datetime2");

                    b.Property<int>("localModelId")
                        .HasColumnType("int");

                    b.Property<string>("userModelId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("localModelId");

                    b.HasIndex("userModelId");

                    b.ToTable("AgendamentoModel");
                });

            modelBuilder.Entity("Fut360.Models.HorarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("Hora_fim")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Hora_inicio")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Horarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hora_fim = new TimeSpan(0, 6, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 6, 0, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Hora_fim = new TimeSpan(0, 6, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 6, 30, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            Hora_fim = new TimeSpan(0, 7, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 7, 0, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            Hora_fim = new TimeSpan(0, 7, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 7, 30, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            Hora_fim = new TimeSpan(0, 8, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 8, 0, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            Hora_fim = new TimeSpan(0, 8, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 8, 30, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            Hora_fim = new TimeSpan(0, 9, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 9, 0, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            Hora_fim = new TimeSpan(0, 9, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 9, 30, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            Hora_fim = new TimeSpan(0, 10, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            Id = 10,
                            Hora_fim = new TimeSpan(0, 10, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 10, 30, 0, 0)
                        },
                        new
                        {
                            Id = 11,
                            Hora_fim = new TimeSpan(0, 11, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 11, 0, 0, 0)
                        },
                        new
                        {
                            Id = 12,
                            Hora_fim = new TimeSpan(0, 11, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 11, 30, 0, 0)
                        },
                        new
                        {
                            Id = 13,
                            Hora_fim = new TimeSpan(0, 12, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 12, 0, 0, 0)
                        },
                        new
                        {
                            Id = 14,
                            Hora_fim = new TimeSpan(0, 12, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 12, 30, 0, 0)
                        },
                        new
                        {
                            Id = 15,
                            Hora_fim = new TimeSpan(0, 13, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 13, 0, 0, 0)
                        },
                        new
                        {
                            Id = 16,
                            Hora_fim = new TimeSpan(0, 13, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 13, 30, 0, 0)
                        },
                        new
                        {
                            Id = 17,
                            Hora_fim = new TimeSpan(0, 14, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 14, 0, 0, 0)
                        },
                        new
                        {
                            Id = 18,
                            Hora_fim = new TimeSpan(0, 14, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 14, 30, 0, 0)
                        },
                        new
                        {
                            Id = 19,
                            Hora_fim = new TimeSpan(0, 15, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 15, 0, 0, 0)
                        },
                        new
                        {
                            Id = 20,
                            Hora_fim = new TimeSpan(0, 15, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 15, 30, 0, 0)
                        },
                        new
                        {
                            Id = 21,
                            Hora_fim = new TimeSpan(0, 16, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 16, 0, 0, 0)
                        },
                        new
                        {
                            Id = 22,
                            Hora_fim = new TimeSpan(0, 16, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 16, 30, 0, 0)
                        },
                        new
                        {
                            Id = 23,
                            Hora_fim = new TimeSpan(0, 17, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 17, 0, 0, 0)
                        },
                        new
                        {
                            Id = 24,
                            Hora_fim = new TimeSpan(0, 17, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 17, 30, 0, 0)
                        },
                        new
                        {
                            Id = 25,
                            Hora_fim = new TimeSpan(0, 18, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 18, 0, 0, 0)
                        },
                        new
                        {
                            Id = 26,
                            Hora_fim = new TimeSpan(0, 18, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 18, 30, 0, 0)
                        },
                        new
                        {
                            Id = 27,
                            Hora_fim = new TimeSpan(0, 19, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 19, 0, 0, 0)
                        },
                        new
                        {
                            Id = 28,
                            Hora_fim = new TimeSpan(0, 19, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 19, 30, 0, 0)
                        },
                        new
                        {
                            Id = 29,
                            Hora_fim = new TimeSpan(0, 20, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 20, 0, 0, 0)
                        },
                        new
                        {
                            Id = 30,
                            Hora_fim = new TimeSpan(0, 20, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 20, 30, 0, 0)
                        },
                        new
                        {
                            Id = 31,
                            Hora_fim = new TimeSpan(0, 21, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 21, 0, 0, 0)
                        },
                        new
                        {
                            Id = 32,
                            Hora_fim = new TimeSpan(0, 21, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 21, 30, 0, 0)
                        },
                        new
                        {
                            Id = 33,
                            Hora_fim = new TimeSpan(0, 22, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 22, 0, 0, 0)
                        },
                        new
                        {
                            Id = 34,
                            Hora_fim = new TimeSpan(0, 22, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 22, 30, 0, 0)
                        },
                        new
                        {
                            Id = 35,
                            Hora_fim = new TimeSpan(0, 23, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 23, 0, 0, 0)
                        },
                        new
                        {
                            Id = 36,
                            Hora_fim = new TimeSpan(0, 23, 30, 0, 0),
                            Hora_inicio = new TimeSpan(0, 23, 30, 0, 0)
                        },
                        new
                        {
                            Id = 37,
                            Hora_fim = new TimeSpan(0, 0, 0, 0, 0),
                            Hora_inicio = new TimeSpan(0, 0, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("Fut360.Models.LocalModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AprovadorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemLocal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Maplink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AprovadorId");

                    b.ToTable("LocalModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Fut360.Models.AgendamentoModel", b =>
                {
                    b.HasOne("Fut360.Models.LocalModel", "localModel")
                        .WithMany()
                        .HasForeignKey("localModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "userModel")
                        .WithMany()
                        .HasForeignKey("userModelId");

                    b.Navigation("localModel");

                    b.Navigation("userModel");
                });

            modelBuilder.Entity("Fut360.Models.LocalModel", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Aprovador")
                        .WithMany()
                        .HasForeignKey("AprovadorId");

                    b.Navigation("Aprovador");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
