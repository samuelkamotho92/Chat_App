﻿// <auto-generated />
using System;
using Comment_Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Comment_Service.Migrations
{
    [DbContext(typeof(CommentDBContext))]
    [Migration("20231221120147_Comment")]
    partial class Comment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Comment_Service.Models.Comment", b =>
                {
                    b.Property<Guid>("commentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_on")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("postId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("updated_on")
                        .HasColumnType("datetime2");

                    b.HasKey("commentId");

                    b.ToTable("comments");
                });
#pragma warning restore 612, 618
        }
    }
}
