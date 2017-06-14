using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PortfolioApi.Services;
using PortfolioApi.Models.Addresses;
using PortfolioApi.Models.Phones;

namespace portfolioapi.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    partial class PortfolioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PortfolioApi.Models.Addresses.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int?>("ContactId");

                    b.Property<string>("Country");

                    b.Property<string>("Postal");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<int>("Type");

                    b.HasKey("AddressId");

                    b.HasIndex("ContactId");

                    b.ToTable("portfolioapi_models_addresses_address");
                });

            modelBuilder.Entity("PortfolioApi.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Secret")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Secret");

                    b.ToTable("portfolioapi_models_client");
                });

            modelBuilder.Entity("PortfolioApi.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.HasKey("ContactId");

                    b.ToTable("portfolioapi_models_contact");
                });

            modelBuilder.Entity("PortfolioApi.Models.Content", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BackgroundUrl");

                    b.Property<string>("Header");

                    b.Property<string>("HtmlId");

                    b.Property<int>("SectionId");

                    b.HasKey("ContentId");

                    b.ToTable("portfolioapi_models_content");
                });

            modelBuilder.Entity("PortfolioApi.Models.FrameworksAndLibs", b =>
                {
                    b.Property<int>("FrameworksAndLibsId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description");

                    b.Property<int>("RankId");

                    b.Property<string>("Title");

                    b.HasKey("FrameworksAndLibsId");

                    b.HasIndex("RankId");

                    b.HasIndex("Title");

                    b.ToTable("portfolioapi_models_frameworksandlibs");
                });

            modelBuilder.Entity("PortfolioApi.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description");

                    b.HasKey("InterestId");

                    b.HasIndex("Description");

                    b.ToTable("portfolioapi_models_interest");
                });

            modelBuilder.Entity("PortfolioApi.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description");

                    b.Property<int>("RankId");

                    b.Property<string>("Title");

                    b.HasKey("LanguageId");

                    b.HasIndex("RankId");

                    b.HasIndex("Title");

                    b.ToTable("portfolioapi_models_language");
                });

            modelBuilder.Entity("PortfolioApi.Models.Phones.PhoneNumber", b =>
                {
                    b.Property<int>("PhoneNumberId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactId");

                    b.Property<int>("Type");

                    b.Property<string>("Value");

                    b.HasKey("PhoneNumberId");

                    b.HasIndex("ContactId");

                    b.ToTable("portfolioapi_models_phones_phonenumber");
                });

            modelBuilder.Entity("PortfolioApi.Models.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutMe");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName");

                    b.HasKey("ProfileId");

                    b.ToTable("portfolioapi_models_profile");
                });

            modelBuilder.Entity("PortfolioApi.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("ProjectId");

                    b.ToTable("portfolioapi_models_project");
                });

            modelBuilder.Entity("PortfolioApi.Models.Rank", b =>
                {
                    b.Property<int>("RankId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("RankId");

                    b.ToTable("portfolioapi_models_rank");
                });

            modelBuilder.Entity("PortfolioApi.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int>("ContentId");

                    b.Property<string>("Meta");

                    b.HasKey("SectionId");

                    b.HasIndex("ContentId");

                    b.ToTable("portfolioapi_models_section");
                });

            modelBuilder.Entity("PortfolioApi.Models.Addresses.Address", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contact")
                        .WithMany("Addresses")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("PortfolioApi.Models.FrameworksAndLibs", b =>
                {
                    b.HasOne("PortfolioApi.Models.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.Language", b =>
                {
                    b.HasOne("PortfolioApi.Models.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortfolioApi.Models.Phones.PhoneNumber", b =>
                {
                    b.HasOne("PortfolioApi.Models.Contact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("PortfolioApi.Models.Section", b =>
                {
                    b.HasOne("PortfolioApi.Models.Content")
                        .WithMany("Sections")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
