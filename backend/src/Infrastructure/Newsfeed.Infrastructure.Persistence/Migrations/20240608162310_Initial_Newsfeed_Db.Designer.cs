﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newsfeed.Infrastructure.Persistence;

#nullable disable

namespace Newsfeed.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(NewsfeedDbContext))]
    [Migration("20240608162310_Initial_Newsfeed_Db")]
    partial class Initial_Newsfeed_Db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Newsfeed.Domain.AggregatesModel.CategoryAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("Newsfeed.Domain.AggregatesModel.PostAggregate.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DisplayMode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PostType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ThumbnailId")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Newsfeed.Domain.AggregatesModel.PostAggregate.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("ReactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Reaction");
                });

            modelBuilder.Entity("Newsfeed.Domain.AggregatesModel.PostAggregate.Post", b =>
                {
                    b.OwnsOne("Newsfeed.Domain.AggregatesModel.PostAggregate.Author", "Author", b1 =>
                        {
                            b1.Property<int>("PostId")
                                .HasColumnType("int");

                            b1.Property<string>("AuthorId")
                                .HasColumnType("longtext");

                            b1.Property<string>("AuthorName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("PostId");

                            b1.ToTable("Posts");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsMany("Newsfeed.Domain.AggregatesModel.PostAggregate.PostAttachment", "PostAttachments", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<string>("PostAttachmentExtension")
                                .HasColumnType("longtext");

                            b1.Property<string>("PostAttachmentName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("PostAttachmentType")
                                .HasColumnType("int");

                            b1.Property<int>("PostId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("PostId");

                            b1.ToTable("PostAttachments", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsMany("Newsfeed.Domain.AggregatesModel.PostAggregate.PostCategory", "PostCategories", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<int>("CategoryId")
                                .HasColumnType("int");

                            b1.Property<int>("PostId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("PostId");

                            b1.ToTable("PostCategories", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.OwnsMany("Newsfeed.Domain.AggregatesModel.PostAggregate.PostHashTag", "PostHashTags", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("PostId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("PostId");

                            b1.ToTable("PostHashTags", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.Navigation("Author")
                        .IsRequired();

                    b.Navigation("PostAttachments");

                    b.Navigation("PostCategories");

                    b.Navigation("PostHashTags");
                });

            modelBuilder.Entity("Newsfeed.Domain.AggregatesModel.PostAggregate.Reaction", b =>
                {
                    b.HasOne("Newsfeed.Domain.AggregatesModel.PostAggregate.Post", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Newsfeed.Domain.AggregatesModel.ReactionAggregate.ValueObjects.UserReaction", "UserReactions", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<int>("ReactionId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("UserId");

                            b1.HasKey("Id");

                            b1.HasIndex("ReactionId");

                            b1.ToTable("UserReaction");

                            b1.WithOwner()
                                .HasForeignKey("ReactionId");
                        });

                    b.Navigation("UserReactions");
                });
#pragma warning restore 612, 618
        }
    }
}
