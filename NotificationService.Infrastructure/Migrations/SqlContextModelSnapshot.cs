﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationService.Infrastructure.Context;

#nullable disable

namespace NotificationService.Infrastructure.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NotificationService.Domain.Notification.NotificationTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExternalTokens")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternalTokens")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LimitedToDelivaryTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationTemplateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Template")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NotificationTemplate");
                });
#pragma warning restore 612, 618
        }
    }
}
