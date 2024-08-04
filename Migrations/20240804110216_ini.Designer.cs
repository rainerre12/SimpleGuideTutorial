﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleGuideTutorial.Context;

#nullable disable

namespace SimpleGuideTutorial.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240804110216_ini")]
    partial class ini
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimpleGuideTutorial.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SimpleGuideTutorial.Model.Description", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<int?>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.HasIndex("VideoId");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("SimpleGuideTutorial.Model.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DescriptionId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("SimpleGuideTutorial.Model.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("SimpleGuideTutorial.Model.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DescriptionId")
                        .HasColumnType("int");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("SimpleGuideTutorial.Model.Category", b =>
                {
                    b.HasOne("SimpleGuideTutorial.Model.Topic", "topic")
                        .WithMany("Categories")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("topic");
                });

            modelBuilder.Entity("SimpleGuideTutorial.Model.Description", b =>
                {
                    b.HasOne("SimpleGuideTutorial.Model.Category", "Category")
                        .WithMany("Descriptions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleGuideTutorial.Model.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("SimpleGuideTutorial.Model.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId");

                    b.Navigation("Category");

                    b.Navigation("Image");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("SimpleGuideTutorial.Model.Image", b =>
                {
                    b.HasOne("SimpleGuideTutorial.Model.Description", "Description")
                        .WithMany()
                        .HasForeignKey("DescriptionId");

                    b.Navigation("Description");
                });

            modelBuilder.Entity("SimpleGuideTutorial.Model.Video", b =>
                {
                    b.HasOne("SimpleGuideTutorial.Model.Description", "Description")
                        .WithMany()
                        .HasForeignKey("DescriptionId");

                    b.Navigation("Description");
                });

            modelBuilder.Entity("SimpleGuideTutorial.Model.Category", b =>
                {
                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("SimpleGuideTutorial.Model.Topic", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
