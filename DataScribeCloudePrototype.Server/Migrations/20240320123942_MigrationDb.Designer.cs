﻿// <auto-generated />
using System;
using DataScribeCloudePrototype.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataScribeCloudePrototype.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240320123942_MigrationDb")]
    partial class MigrationDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Audio", b =>
                {
                    b.Property<Guid>("AudioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UrlAidio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserIDId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AudioId");

                    b.HasIndex("UserIDId");

                    b.ToTable("Audio");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.DocFiles", b =>
                {
                    b.Property<Guid>("DocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserIDId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DocId");

                    b.HasIndex("UserIDId");

                    b.ToTable("DocFiles");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Image", b =>
                {
                    b.Property<Guid>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserIDId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ImageId");

                    b.HasIndex("UserIDId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Notes", b =>
                {
                    b.Property<Guid>("NotesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserIDId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotesId");

                    b.HasIndex("UserIDId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Pdf", b =>
                {
                    b.Property<Guid>("PDFId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CurrUserIDId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PDFUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PDFId");

                    b.HasIndex("CurrUserIDId");

                    b.ToTable("Pdf");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Audio", b =>
                {
                    b.HasOne("DataScribeCloudePrototype.Server.Models.User", "UserID")
                        .WithMany()
                        .HasForeignKey("UserIDId");

                    b.Navigation("UserID");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.DocFiles", b =>
                {
                    b.HasOne("DataScribeCloudePrototype.Server.Models.User", "UserID")
                        .WithMany()
                        .HasForeignKey("UserIDId");

                    b.Navigation("UserID");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Image", b =>
                {
                    b.HasOne("DataScribeCloudePrototype.Server.Models.User", "UserID")
                        .WithMany()
                        .HasForeignKey("UserIDId");

                    b.Navigation("UserID");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Notes", b =>
                {
                    b.HasOne("DataScribeCloudePrototype.Server.Models.User", "UserID")
                        .WithMany()
                        .HasForeignKey("UserIDId");

                    b.Navigation("UserID");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Pdf", b =>
                {
                    b.HasOne("DataScribeCloudePrototype.Server.Models.User", "CurrUserID")
                        .WithMany()
                        .HasForeignKey("CurrUserIDId");

                    b.Navigation("CurrUserID");
                });
#pragma warning restore 612, 618
        }
    }
}
