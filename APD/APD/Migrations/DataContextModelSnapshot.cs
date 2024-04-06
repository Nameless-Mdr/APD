﻿// <auto-generated />
using APD.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APD.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APD.Domain.Entity.Installation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit")
                        .HasColumnName("IsDefault");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int")
                        .HasColumnName("OfficeId");

                    b.Property<int>("PrintDeviceId")
                        .HasColumnType("int")
                        .HasColumnName("PrintDeviceId");

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("int")
                        .HasColumnName("SequenceNumber");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PrintDeviceId");

                    b.ToTable("Installation", "main");
                });

            modelBuilder.Entity("APD.Domain.Entity.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Office", "main");
                });

            modelBuilder.Entity("APD.Domain.Entity.PrintDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("TypeConnect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TypeConnect");

                    b.HasKey("Id");

                    b.ToTable("PrintDevice", "main");
                });

            modelBuilder.Entity("APD.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int")
                        .HasColumnName("OfficeId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("User", "main");
                });

            modelBuilder.Entity("APD.Domain.Entity.Installation", b =>
                {
                    b.HasOne("APD.Domain.Entity.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APD.Domain.Entity.PrintDevice", "PrintDevice")
                        .WithMany()
                        .HasForeignKey("PrintDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("PrintDevice");
                });

            modelBuilder.Entity("APD.Domain.Entity.User", b =>
                {
                    b.HasOne("APD.Domain.Entity.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });
#pragma warning restore 612, 618
        }
    }
}
