﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetGuadian.API.Data;

#nullable disable

namespace PetGuadian.API.Migrations
{
    [DbContext(typeof(AppContextDb))]
    partial class AppContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetGuardian.Models.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("PetGuardian.Models.Models.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("Gender")
                        .HasColumnType("smallint");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<int>("Specie")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pets", (string)null);
                });

            modelBuilder.Entity("PetGuardian.Models.Models.PetExams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExamLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<Guid>("petId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("petId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("PetGuardian.Models.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("PetGuardian.Models.Models.Address", b =>
                {
                    b.HasOne("PetGuardian.Models.Models.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("PetGuardian.Models.Models.Address", "UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetGuardian.Models.Models.Pet", b =>
                {
                    b.HasOne("PetGuardian.Models.Models.User", "User")
                        .WithMany("Pets")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetGuardian.Models.Models.PetExams", b =>
                {
                    b.HasOne("PetGuardian.Models.Models.Pet", "Pet")
                        .WithMany("PetExams")
                        .HasForeignKey("petId")
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("PetGuardian.Models.Models.User", b =>
                {
                    b.OwnsOne("PetGuardian.Domain.Core.DomainObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("varchar()11")
                                .HasColumnName("Cpf");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("PetGuardian.Domain.Core.DomainObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasMaxLength(254)
                                .HasColumnType("varchar(254)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("PetGuardian.Models.Models.Pet", b =>
                {
                    b.Navigation("PetExams");
                });

            modelBuilder.Entity("PetGuardian.Models.Models.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
