﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testAsqServer.model.Entity;

#nullable disable

namespace testAsqServer.Migrations
{
    [DbContext(typeof(FormDbContext))]
    partial class FormDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("testAsqServer.model.Entity.FileInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("hash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FileInfo");
                });

            modelBuilder.Entity("testAsqServer.model.Entity.OOOForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganisationFullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganisationShortName")
                        .HasColumnType("TEXT");

                    b.Property<int>("StandartIPFormId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StandartIPFormInn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StandartIPFormInn");

                    b.ToTable("OOOForm");
                });

            modelBuilder.Entity("testAsqServer.model.Entity.PayForm", b =>
                {
                    b.Property<string>("Bik")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CheckingAccount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CorrespondentAccount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Bik");

                    b.ToTable("PayForm");
                });

            modelBuilder.Entity("testAsqServer.model.Entity.StandartIPForm", b =>
                {
                    b.Property<string>("Inn")
                        .HasColumnType("TEXT");

                    b.Property<int>("EgripFileId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InnFileId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ogrip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OgripFileId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PayFormBik")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PayFormId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("RegisterDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RentFileId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Inn");

                    b.HasIndex("EgripFileId");

                    b.HasIndex("InnFileId");

                    b.HasIndex("OgripFileId");

                    b.HasIndex("PayFormBik");

                    b.HasIndex("RentFileId");

                    b.ToTable("StandartIPForm");
                });

            modelBuilder.Entity("testAsqServer.model.Entity.OOOForm", b =>
                {
                    b.HasOne("testAsqServer.model.Entity.StandartIPForm", "StandartIPForm")
                        .WithMany()
                        .HasForeignKey("StandartIPFormInn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StandartIPForm");
                });

            modelBuilder.Entity("testAsqServer.model.Entity.StandartIPForm", b =>
                {
                    b.HasOne("testAsqServer.model.Entity.FileInfo", "EgripFile")
                        .WithMany()
                        .HasForeignKey("EgripFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testAsqServer.model.Entity.FileInfo", "InnFile")
                        .WithMany()
                        .HasForeignKey("InnFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testAsqServer.model.Entity.FileInfo", "OgripFile")
                        .WithMany()
                        .HasForeignKey("OgripFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testAsqServer.model.Entity.PayForm", "PayForm")
                        .WithMany()
                        .HasForeignKey("PayFormBik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testAsqServer.model.Entity.FileInfo", "RentFile")
                        .WithMany()
                        .HasForeignKey("RentFileId");

                    b.Navigation("EgripFile");

                    b.Navigation("InnFile");

                    b.Navigation("OgripFile");

                    b.Navigation("PayForm");

                    b.Navigation("RentFile");
                });
#pragma warning restore 612, 618
        }
    }
}
