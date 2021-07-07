﻿// <auto-generated />
using System;
using DateTimeManagement.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DateTimeManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DateTimeManagement.Infra.Operation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MonEntittyWithIANADateTimes");
                });

            modelBuilder.Entity("DateTimeManagement.Infra.Operation", b =>
                {
                    b.OwnsOne("DateTimeManagement.Core.IANADateTime", "BilingDate", b1 =>
                        {
                            b1.Property<long>("OperationId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTimeOffset>("OffsetUTC")
                                .HasColumnType("datetimeoffset");

                            b1.Property<string>("OriginalDate")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("TimeZone")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OperationId");

                            b1.ToTable("MonEntittyWithIANADateTimes");

                            b1.WithOwner()
                                .HasForeignKey("OperationId");
                        });

                    b.OwnsOne("DateTimeManagement.Core.IANADateTime", "DueDate", b1 =>
                        {
                            b1.Property<long>("OperationId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTimeOffset>("OffsetUTC")
                                .HasColumnType("datetimeoffset");

                            b1.Property<string>("OriginalDate")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("TimeZone")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OperationId");

                            b1.ToTable("MonEntittyWithIANADateTimes");

                            b1.WithOwner()
                                .HasForeignKey("OperationId");
                        });

                    b.Navigation("BilingDate");

                    b.Navigation("DueDate");
                });
#pragma warning restore 612, 618
        }
    }
}