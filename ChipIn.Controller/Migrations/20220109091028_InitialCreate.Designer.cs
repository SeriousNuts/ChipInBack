// <auto-generated />
using System;
using ChipIn.Controller.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChipIn.Controller.Migrations
{
    [DbContext(typeof(ChipInControllerContext))]
    [Migration("20220109091028_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChipIn.Controller.Models.User_", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("discriminator");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name_")
                        .HasColumnType("text")
                        .HasColumnName("name_");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Photo")
                        .HasColumnType("text")
                        .HasColumnName("photo");

                    b.HasKey("Id")
                        .HasName("pk_user_");

                    b.ToTable("user_", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User_");
                });

            modelBuilder.Entity("ChipIn.models.Event", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("CreditorName")
                        .HasColumnType("text")
                        .HasColumnName("creditor_name");

                    b.Property<decimal?>("FullAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("full_amount");

                    b.Property<DateTime?>("deadline")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deadline");

                    b.Property<string>("name_")
                        .HasColumnType("text")
                        .HasColumnName("name_");

                    b.HasKey("id")
                        .HasName("pk_event");

                    b.ToTable("event", (string)null);
                });

            modelBuilder.Entity("ChipIn.Controller.Models.Member", b =>
                {
                    b.HasBaseType("ChipIn.Controller.Models.User_");

                    b.Property<int?>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("event_id");

                    b.Property<int>("MemberId")
                        .HasColumnType("integer")
                        .HasColumnName("member_id");

                    b.Property<double>("member_credit")
                        .HasColumnType("double precision")
                        .HasColumnName("member_credit");

                    b.HasIndex("EventId")
                        .HasDatabaseName("ix_user__event_id");

                    b.HasDiscriminator().HasValue("Member");
                });

            modelBuilder.Entity("ChipIn.Controller.Models.Member", b =>
                {
                    b.HasOne("ChipIn.models.Event", "Event")
                        .WithMany("members")
                        .HasForeignKey("EventId")
                        .HasConstraintName("fk_user__event_event_id");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ChipIn.models.Event", b =>
                {
                    b.Navigation("members");
                });
#pragma warning restore 612, 618
        }
    }
}
