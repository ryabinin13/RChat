﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RChat.DAL.Context;

namespace RChat.Migrations
{
    [DbContext(typeof(RChatContext))]
    [Migration("20230714154746_deleteMessages")]
    partial class deleteMessages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BotEntityChatEntity", b =>
                {
                    b.Property<int>("BotEntitiesBotId")
                        .HasColumnType("integer");

                    b.Property<int>("ChatEntitiesChatId")
                        .HasColumnType("integer");

                    b.HasKey("BotEntitiesBotId", "ChatEntitiesChatId");

                    b.HasIndex("ChatEntitiesChatId");

                    b.ToTable("BotEntityChatEntity");
                });

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

            modelBuilder.Entity("RChat.DAL.Entities.BotEntity", b =>
                {
                    b.Property<int>("BotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("BotId");

                    b.ToTable("Bots");
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

            modelBuilder.Entity("BotEntityChatEntity", b =>
                {
                    b.HasOne("RChat.DAL.Entities.BotEntity", null)
                        .WithMany()
                        .HasForeignKey("BotEntitiesBotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RChat.DAL.Entities.ChatEntity", null)
                        .WithMany()
                        .HasForeignKey("ChatEntitiesChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
#pragma warning restore 612, 618
        }
    }
}
