// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Projekat.Migrations
{
    [DbContext(typeof(BibliotekaContext))]
    [Migration("20220106025033_V2")]
    partial class V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClanskaKarta")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("Models.Iznajmljivanje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Mesec")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.ToTable("Iznajmljivanje");
                });

            modelBuilder.Entity("Models.Knjiga", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Sifra")
                        .HasColumnType("int");

                    b.Property<int?>("ZanrID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ZanrID");

                    b.ToTable("Knjiga");
                });

            modelBuilder.Entity("Models.Mesec", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.ToTable("Mesec");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClanID")
                        .HasColumnType("int");

                    b.Property<int?>("IznajmljivanjeID")
                        .HasColumnType("int");

                    b.Property<int?>("KnjigaID")
                        .HasColumnType("int");

                    b.Property<int?>("MesecID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClanID");

                    b.HasIndex("IznajmljivanjeID");

                    b.HasIndex("KnjigaID");

                    b.HasIndex("MesecID");

                    b.ToTable("KnjigeClanovi");
                });

            modelBuilder.Entity("Models.Zanr", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Zanr");
                });

            modelBuilder.Entity("Models.Knjiga", b =>
                {
                    b.HasOne("Models.Zanr", "Zanr")
                        .WithMany("KnjigaZanr")
                        .HasForeignKey("ZanrID");

                    b.Navigation("Zanr");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.HasOne("Models.Clan", "Clan")
                        .WithMany("ClanKnjiga")
                        .HasForeignKey("ClanID");

                    b.HasOne("Models.Iznajmljivanje", "Iznajmljivanje")
                        .WithMany("KnjigeClanovi")
                        .HasForeignKey("IznajmljivanjeID");

                    b.HasOne("Models.Knjiga", "Knjiga")
                        .WithMany("KnjigaClan")
                        .HasForeignKey("KnjigaID");

                    b.HasOne("Models.Mesec", null)
                        .WithMany("MesecSpoj")
                        .HasForeignKey("MesecID");

                    b.Navigation("Clan");

                    b.Navigation("Iznajmljivanje");

                    b.Navigation("Knjiga");
                });

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.Navigation("ClanKnjiga");
                });

            modelBuilder.Entity("Models.Iznajmljivanje", b =>
                {
                    b.Navigation("KnjigeClanovi");
                });

            modelBuilder.Entity("Models.Knjiga", b =>
                {
                    b.Navigation("KnjigaClan");
                });

            modelBuilder.Entity("Models.Mesec", b =>
                {
                    b.Navigation("MesecSpoj");
                });

            modelBuilder.Entity("Models.Zanr", b =>
                {
                    b.Navigation("KnjigaZanr");
                });
#pragma warning restore 612, 618
        }
    }
}
