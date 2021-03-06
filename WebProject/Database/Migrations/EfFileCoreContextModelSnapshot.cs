﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Database;

namespace Database.Migrations
{
    [DbContext(typeof(EfFileCoreContext))]
    partial class EfFileCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Database.Clients.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Database.Contacts.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Email");

                    b.Property<bool>("IsValid");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNo");

                    b.HasKey("ContactId");

                    b.HasIndex("ClientId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Database.Contacts.ImportedContact", b =>
                {
                    b.Property<int>("ImportedContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("ClientId");

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Photo");

                    b.Property<string>("Region");

                    b.Property<string>("Surname");

                    b.Property<string>("Title");

                    b.HasKey("ImportedContactId");

                    b.HasIndex("ClientId");

                    b.ToTable("ImportedContacts");
                });

            modelBuilder.Entity("Database.Files.ClientFileConfiguration", b =>
                {
                    b.Property<int>("ClientFileConfigurationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<int>("FileType");

                    b.Property<string>("InputPath");

                    b.Property<string>("OutputPath");

                    b.HasKey("ClientFileConfigurationId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientFileConfiguration");
                });

            modelBuilder.Entity("Database.Contacts.Contact", b =>
                {
                    b.HasOne("Database.Clients.Client", "Client")
                        .WithMany("Contacts")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("ForeignKey_Contact_Client")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Contacts.ImportedContact", b =>
                {
                    b.HasOne("Database.Clients.Client", "Client")
                        .WithMany("ImportedContacts")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("ForeignKey_ImportedContact_Client")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Files.ClientFileConfiguration", b =>
                {
                    b.HasOne("Database.Clients.Client", "Client")
                        .WithMany("ClientFileConfiguration")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("ForeignKey_FileCOnfiguration_Client")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
