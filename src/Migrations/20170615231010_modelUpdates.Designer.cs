﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PortfolioApi.Models.Contacts.Addresses;
using PortfolioApi.Models.Contacts.Phones;
using PortfolioApi.Services;
using System;

namespace PortfolioApi.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    [Migration("20170615231010_modelUpdates")]
    partial class modelUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview1-24937")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PortfolioApi.Models.Clients.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Name");

                    b.Property<string>("Secret")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Secret");

                    b.ToTable("pfm_clients_client");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.ToTable("pfm_contacts_contact");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("HtmlId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("HtmlId");

                    b.ToTable("pfm_contents_content");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Sections.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("ContentId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("pfm_contents_sections_section");
                });

            modelBuilder.Entity("PortfolioApi.Models.Interests.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.ToTable("pfm_interests_interest");
                });

            modelBuilder.Entity("PortfolioApi.Models.Profiles.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.ToTable("pfm_profiles_profile");
                });

            modelBuilder.Entity("PortfolioApi.Models.Projects.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("Title");

                    b.ToTable("pfm_projects_project");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Frameworks.Framework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("RankId");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.HasIndex("Title");

                    b.ToTable("pfm_rankableitems_frameworks_framework");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Languages.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("RankId");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.HasIndex("Title");

                    b.ToTable("pfm_rankableitems_languages_language");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Libraries.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("RankId");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.HasIndex("Title");

                    b.ToTable("pfm_rankableitems_libraries_library");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Ranks.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.ToTable("pfm_rankableitems_ranks_rank");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Info", b =>
                {
                    b.Property<int?>("ContactId");

                    b.Property<int>("AddressType");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("PhoneType");

                    b.Property<string>("Postal");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.HasKey("ContactId");

                    b.ToTable("pfm_contacts_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Info", b =>
                {
                    b.Property<int?>("ContentId");

                    b.Property<string>("BackgroundUrl");

                    b.Property<string>("Header");

                    b.HasKey("ContentId");

                    b.ToTable("pfm_contents_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Sections.Info", b =>
                {
                    b.Property<int?>("SectionId");

                    b.Property<string>("Body");

                    b.Property<string>("Meta");

                    b.HasKey("SectionId");

                    b.ToTable("pfm_contents_sections_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Interests.Info", b =>
                {
                    b.Property<int?>("InterestId");

                    b.Property<string>("Description");

                    b.HasKey("InterestId");

                    b.ToTable("pfm_interests_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Profiles.Info", b =>
                {
                    b.Property<int?>("ProfileId");

                    b.Property<string>("AboutMe");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.HasKey("ProfileId");

                    b.ToTable("pfm_profiles_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Projects.Info", b =>
                {
                    b.Property<int?>("ProjectId");

                    b.Property<string>("Description");

                    b.Property<string>("Url");

                    b.HasKey("ProjectId");

                    b.ToTable("pfm_projects_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Frameworks.Info", b =>
                {
                    b.Property<int?>("FrameworkId");

                    b.Property<string>("Description");

                    b.HasKey("FrameworkId");

                    b.ToTable("pfm_rankableitems_frameworks_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Languages.Info", b =>
                {
                    b.Property<int?>("LanguageId");

                    b.Property<string>("Description");

                    b.HasKey("LanguageId");

                    b.ToTable("pfm_rankableitems_languages_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Libraries.Info", b =>
                {
                    b.Property<int?>("LibraryId");

                    b.Property<string>("Description");

                    b.HasKey("LibraryId");

                    b.ToTable("pfm_rankableitems_libraries_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Ranks.Info", b =>
                {
                    b.Property<int?>("RankId");

                    b.Property<string>("Description");

                    b.HasKey("RankId");

                    b.ToTable("pfm_rankableitems_ranks_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Sections.Section", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contents.Content")
                        .WithMany("Sections")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Frameworks.Framework", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Ranks.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Languages.Language", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Ranks.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Libraries.Library", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Ranks.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Info", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contacts.Contact")
                        .WithOne("Info")
                        .HasForeignKey("PortfolioApi.Models.Contacts.Info", "ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Info", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contents.Content")
                        .WithOne("Info")
                        .HasForeignKey("PortfolioApi.Models.Contents.Info", "ContentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Sections.Info", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contents.Sections.Section")
                        .WithOne("Info")
                        .HasForeignKey("PortfolioApi.Models.Contents.Sections.Info", "SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.Interests.Info", b =>
                {
                    b.HasOne("PortfolioApi.Models.Interests.Interest")
                        .WithOne("Info")
                        .HasForeignKey("PortfolioApi.Models.Interests.Info", "InterestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.Profiles.Info", b =>
                {
                    b.HasOne("PortfolioApi.Models.Profiles.Profile")
                        .WithOne("Info")
                        .HasForeignKey("PortfolioApi.Models.Profiles.Info", "ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.Projects.Info", b =>
                {
                    b.HasOne("PortfolioApi.Models.Projects.Project")
                        .WithOne("Info")
                        .HasForeignKey("PortfolioApi.Models.Projects.Info", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Frameworks.Info", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Frameworks.Framework")
                        .WithOne("Info")
                        .HasForeignKey("PortfolioApi.Models.RankableItems.Frameworks.Info", "FrameworkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Languages.Info", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Languages.Language")
                        .WithOne("Info")
                        .HasForeignKey("PortfolioApi.Models.RankableItems.Languages.Info", "LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Libraries.Info", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Libraries.Library")
                        .WithOne("Info")
                        .HasForeignKey("PortfolioApi.Models.RankableItems.Libraries.Info", "LibraryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Ranks.Info", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Ranks.Rank")
                        .WithOne("Info")
                        .HasForeignKey("PortfolioApi.Models.RankableItems.Ranks.Info", "RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
