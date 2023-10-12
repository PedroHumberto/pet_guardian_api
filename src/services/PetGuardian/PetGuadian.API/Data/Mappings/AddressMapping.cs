﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Models.Models;

namespace PetGuadian.API.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(a => a.Number)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(a => a.Complement)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar(25)");

            builder.Property(a => a.PostalCode)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.HasOne(a => a.User)
                .WithOne(u => u.Address)
                .HasForeignKey<Address>(a => a.UserId);

            builder.ToTable("Addresses");


        }
    }
}
