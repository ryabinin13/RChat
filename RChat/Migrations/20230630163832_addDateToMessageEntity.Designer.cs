﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RChat.DAL.Context;

namespace RChat.Migrations
{
    [DbContext(typeof(RChatContext))]
    [Migration("20230630163832_addDateToMessageEntity")]
    partial class addDateToMessageEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ChatEntityUserEntity", b =>
                {
                    b.Property<int>("ChatEntitiesChatId")
                        .HasColumnType("integer");

                    b.Property<int>("UserEntitiesUserId")
                        .HasColumnType("integer");

                    b.HasKey("ChatEntitiesChatId", "UserEntitiesUserId");

                    b.HasIndex("UserEntitiesUserId");

                    b.ToTable("ChatEntityUserEntity");
                });

            modelBuilder.Entity("RChat.DAL.Entities.ChatEntity", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ChatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("RChat.DAL.Entities.MessageEntity", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ChatEntityChatId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int?>("UserEntityUserId")
                        .HasColumnType("integer");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatEntityChatId");

                    b.HasIndex("UserEntityUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("RChat.DAL.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasAlternateKey("Login");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatEntityUserEntity", b =>
                {
                    b.HasOne("RChat.DAL.Entities.ChatEntity", null)
                        .WithMany()
                        .HasForeignKey("ChatEntitiesChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RChat.DAL.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserEntitiesUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RChat.DAL.Entities.MessageEntity", b =>
                {
                    b.HasOne("RChat.DAL.Entities.ChatEntity", "ChatEntity")
                        .WithMany("MessageEntities")
                        .HasForeignKey("ChatEntityChatId");

                    b.HasOne("RChat.DAL.Entities.UserEntity", "UserEntity")
                        .WithMany("MessageEntities")
                        .HasForeignKey("UserEntityUserId");

                    b.Navigation("ChatEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("RChat.DAL.Entities.ChatEntity", b =>
                {
                    b.Navigation("MessageEntities");
                });

            modelBuilder.Entity("RChat.DAL.Entities.UserEntity", b =>
                {
                    b.Navigation("MessageEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
