﻿// <auto-generated />
using System;
using DataScribeCloudePrototype.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataScribeCloudePrototype.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Audio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CurrUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UrlAidio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Audio");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.DocFiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CurrUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DocFiles");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Images", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CurrUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Notes", b =>
                {
                    b.Property<int>("NotesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotesId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CurrUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotesId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Pdf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CurrUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PDFUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pdf");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Pptx", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CurrUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PptxUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pptx");
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
                    b.HasOne("DataScribeCloudePrototype.Server.Models.User", null)
                        .WithMany("Audios")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.DocFiles", b =>
                {
                    b.HasOne("DataScribeCloudePrototype.Server.Models.User", null)
                        .WithMany("DocFiles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Images", b =>
                {
                    b.HasOne("DataScribeCloudePrototype.Server.Models.User", null)
                        .WithMany("Images")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Notes", b =>
                {
                    b.HasOne("DataScribeCloudePrototype.Server.Models.User", null)
                        .WithMany("Notes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.Pdf", b =>
                {
                    b.HasOne("DataScribeCloudePrototype.Server.Models.User", null)
                        .WithMany("Pdfs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DataScribeCloudePrototype.Server.Models.User", b =>
                {
                    b.Navigation("Audios");

                    b.Navigation("DocFiles");

                    b.Navigation("Images");

                    b.Navigation("Notes");

                    b.Navigation("Pdfs");
                });
#pragma warning restore 612, 618
        }
    }
}
