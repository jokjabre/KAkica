﻿// <auto-generated />
using KAkica.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KAkica.Domain.Migrations
{
    [DbContext(typeof(KAkicaDbContext))]
    [Migration("20190704222204_Added_user")]
    partial class Added_user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KAkica.Domain.Models.KakicaUser", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("Username");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KAkica.Domain.Models.Owner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KakicaUserRef");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("KakicaUserRef")
                        .IsUnique()
                        .HasFilter("[KakicaUserRef] IS NOT NULL");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("KAkica.Domain.Models.OwnerPooper", b =>
                {
                    b.Property<long>("PooperId");

                    b.Property<long>("OwnerId");

                    b.HasKey("PooperId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("OwnerPoopers");
                });

            modelBuilder.Entity("KAkica.Domain.Models.Pooper", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Poopers");
                });

            modelBuilder.Entity("KAkica.Domain.Models.Owner", b =>
                {
                    b.HasOne("KAkica.Domain.Models.KakicaUser", "KakicaUser")
                        .WithOne("Owner")
                        .HasForeignKey("KAkica.Domain.Models.Owner", "KakicaUserRef");
                });

            modelBuilder.Entity("KAkica.Domain.Models.OwnerPooper", b =>
                {
                    b.HasOne("KAkica.Domain.Models.Owner", "Owner")
                        .WithMany("OwnerPoopers")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KAkica.Domain.Models.Pooper", "Pooper")
                        .WithMany("OwnerPoopers")
                        .HasForeignKey("PooperId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}