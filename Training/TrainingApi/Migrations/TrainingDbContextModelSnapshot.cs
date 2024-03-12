﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Training;

#nullable disable

namespace TrainingApi.Migrations
{
    [DbContext(typeof(TrainingDbContext))]
    partial class TrainingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrainingApi.Models.SalesDetails", b =>
                {
                    b.Property<long>("SalesDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SalesDetailsId"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedStamp")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<long>("SalesHeaderid")
                        .HasColumnType("bigint");

                    b.HasKey("SalesDetailsId");

                    b.HasIndex("SalesHeaderid");

                    b.ToTable("SalesDetails");
                });

            modelBuilder.Entity("TrainingApi.Models.SalesDetailsTemp", b =>
                {
                    b.Property<long>("SalesDetailsTempId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SalesDetailsTempId"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedStamp")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("SalesDetailsTempId");

                    b.ToTable("SalesDetailsTemps");
                });

            modelBuilder.Entity("TrainingApi.Models.SalesHeader", b =>
                {
                    b.Property<long>("SalesHeaderid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SalesHeaderid"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedStamp")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SalesHeaderid");

                    b.ToTable("SalesHeaders");
                });

            modelBuilder.Entity("TrainingApi.Models.SalesDetails", b =>
                {
                    b.HasOne("TrainingApi.Models.SalesHeader", "SalesHeaderId")
                        .WithMany("SalesDetails")
                        .HasForeignKey("SalesHeaderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesHeaderId");
                });

            modelBuilder.Entity("TrainingApi.Models.SalesHeader", b =>
                {
                    b.Navigation("SalesDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
