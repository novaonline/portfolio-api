using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PortfolioApi.Services;
using PortfolioApi.Models.Contacts.Addresses;
using PortfolioApi.Models.Contacts.Phones;

namespace PortfolioApi.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    [Migration("20170615003334_initForRevision")]
    partial class initForRevision
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PortfolioApi.Models.Clients.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("InfoId");

                    b.Property<string>("Secret")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("portfolioapi_models_clients_client");
                });

            modelBuilder.Entity("PortfolioApi.Models.Clients.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_clients_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Addresses.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("ContactId");

                    b.Property<int?>("InfoId");

                    b.Property<int?>("InfoId1");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.HasIndex("InfoId1");

                    b.ToTable("portfolioapi_models_contacts_addresses_address");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Addresses.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Postal");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_contacts_addresses_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("InfoId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("portfolioapi_models_contacts_contact");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_contacts_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Phones.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Type");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_contacts_phones_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Phones.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("ContactId");

                    b.Property<int?>("InfoId");

                    b.Property<int?>("InfoId1");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.HasIndex("InfoId1");

                    b.ToTable("portfolioapi_models_contacts_phones_phone");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("InfoId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("portfolioapi_models_contents_content");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BackgroundUrl");

                    b.Property<string>("Header");

                    b.Property<string>("HtmlId");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_contents_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Sections.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Meta");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_contents_sections_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Sections.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("ContentId");

                    b.Property<int?>("InfoId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("InfoId");

                    b.ToTable("portfolioapi_models_contents_sections_section");
                });

            modelBuilder.Entity("PortfolioApi.Models.Interests.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_interests_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Interests.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("InfoId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("portfolioapi_models_interests_interest");
                });

            modelBuilder.Entity("PortfolioApi.Models.Profiles.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutMe");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_profiles_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Profiles.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("InfoId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("portfolioapi_models_profiles_profile");
                });

            modelBuilder.Entity("PortfolioApi.Models.Projects.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_projects_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.Projects.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("InfoId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("portfolioapi_models_projects_project");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Frameworks.Framework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("InfoId");

                    b.Property<int>("RankId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.HasIndex("RankId");

                    b.ToTable("portfolioapi_models_rankableitems_frameworks_framework");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Frameworks.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_rankableitems_frameworks_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Languages.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_rankableitems_languages_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Languages.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("InfoId");

                    b.Property<int>("RankId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.HasIndex("RankId");

                    b.ToTable("portfolioapi_models_rankableitems_languages_language");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Libraries.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_rankableitems_libraries_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Libraries.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("InfoId");

                    b.Property<int>("RankId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.HasIndex("RankId");

                    b.ToTable("portfolioapi_models_rankableitems_libraries_library");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Ranks.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("portfolioapi_models_rankableitems_ranks_info");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Ranks.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("InfoId");

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("portfolioapi_models_rankableitems_ranks_rank");
                });

            modelBuilder.Entity("PortfolioApi.Models.Clients.Client", b =>
                {
                    b.HasOne("PortfolioApi.Models.Clients.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Addresses.Address", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contacts.Info")
                        .WithMany("Addresses")
                        .HasForeignKey("InfoId");

                    b.HasOne("PortfolioApi.Models.Contacts.Addresses.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId1");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Contact", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contacts.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contacts.Phones.Phone", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contacts.Info")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("InfoId");

                    b.HasOne("PortfolioApi.Models.Contacts.Phones.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId1");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Content", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contents.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contents.Sections.Section", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contents.Content")
                        .WithMany("Sections")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PortfolioApi.Models.Contents.Sections.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("PortfolioApi.Models.Interests.Interest", b =>
                {
                    b.HasOne("PortfolioApi.Models.Interests.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("PortfolioApi.Models.Profiles.Profile", b =>
                {
                    b.HasOne("PortfolioApi.Models.Profiles.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("PortfolioApi.Models.Projects.Project", b =>
                {
                    b.HasOne("PortfolioApi.Models.Projects.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Frameworks.Framework", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Frameworks.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");

                    b.HasOne("PortfolioApi.Models.RankableItems.Ranks.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Languages.Language", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Languages.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");

                    b.HasOne("PortfolioApi.Models.RankableItems.Ranks.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Libraries.Library", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Libraries.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");

                    b.HasOne("PortfolioApi.Models.RankableItems.Ranks.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.RankableItems.Ranks.Rank", b =>
                {
                    b.HasOne("PortfolioApi.Models.RankableItems.Ranks.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");
                });
        }
    }
}
