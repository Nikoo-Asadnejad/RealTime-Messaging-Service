﻿// <auto-generated />
using System;
using Messaging_Service.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Messaging_Service.Migrations
{
    [DbContext(typeof(MessengerContext))]
    [Migration("20220925080639_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Messaging_Service.DataAccess.Entities.ChatModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ConnectionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreateDate")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeleteDate")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<long?>("EditDate")
                        .HasColumnType("bigint");

                    b.Property<long?>("EditedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("Messaging_Service.DataAccess.Entities.MessageModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("ChatModelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreateDate")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeleteDate")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<long?>("EditDate")
                        .HasColumnType("bigint");

                    b.Property<long?>("EditedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("RecieverId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ReciveDate")
                        .HasColumnType("bigint");

                    b.Property<long?>("SendDate")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ChatModelId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Messaging_Service.DataAccess.Entities.MessageModel", b =>
                {
                    b.HasOne("Messaging_Service.DataAccess.Entities.ChatModel", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatModelId");
                });

            modelBuilder.Entity("Messaging_Service.DataAccess.Entities.ChatModel", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
