﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecALLDemo.Contrib.MaskedTextItem.Api.Services;

#nullable disable

namespace RecALLDemo.Contrib.MaskedTextItem.Api.Migrations.IdentityServer.PersistedGrantDb
{
    [DbContext(typeof(MaskedTextItemContext))]
    [Migration("20240509113935_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("maskedtextitem_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("RecALLDemo.Contrib.MaskedTextItem.Api.Models.MaskedTextItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "maskedtextitem_hilo");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("MaskedContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserIdentityGuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique()
                        .HasFilter("[ItemId] IS NOT NULL");

                    b.HasIndex("UserIdentityGuid");

                    b.ToTable("maskedtextitems", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}