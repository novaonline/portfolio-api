using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using portfolio_api.Services;
using portfolio_api.Models.Addresses;
using portfolio_api.Models.Phones;

namespace portfolioapi.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    [Migration("20170612031702_added_client")]
    partial class added_client
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("portfolio_api.Models.Addresses.Address", b =>
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

                    b.ToTable("portfolio_api_models_addresses_address");
                });

            modelBuilder.Entity("portfolio_api.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Secret")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Secret");

                    b.ToTable("portfolio_api_models_client");
                });

            modelBuilder.Entity("portfolio_api.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.HasKey("ContactId");

                    b.ToTable("portfolio_api_models_contact");
                });

            modelBuilder.Entity("portfolio_api.Models.FrameworksAndLibs", b =>
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

                    b.ToTable("portfolio_api_models_frameworksandlibs");
                });

            modelBuilder.Entity("portfolio_api.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description");

                    b.HasKey("InterestId");

                    b.HasIndex("Description");

                    b.ToTable("portfolio_api_models_interest");
                });

            modelBuilder.Entity("portfolio_api.Models.Language", b =>
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

                    b.ToTable("portfolio_api_models_language");
                });

            modelBuilder.Entity("portfolio_api.Models.Phones.PhoneNumber", b =>
                {
                    b.Property<int>("PhoneNumberId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactId");

                    b.Property<int>("Type");

                    b.Property<string>("Value");

                    b.HasKey("PhoneNumberId");

                    b.HasIndex("ContactId");

                    b.ToTable("portfolio_api_models_phones_phonenumber");
                });

            modelBuilder.Entity("portfolio_api.Models.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutMe");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName");

                    b.HasKey("ProfileId");

                    b.ToTable("portfolio_api_models_profile");
                });

            modelBuilder.Entity("portfolio_api.Models.Project", b =>
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

                    b.ToTable("portfolio_api_models_project");
                });

            modelBuilder.Entity("portfolio_api.Models.Rank", b =>
                {
                    b.Property<int>("RankId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("RankId");

                    b.ToTable("portfolio_api_models_rank");
                });

            modelBuilder.Entity("portfolio_api.Models.Addresses.Address", b =>
                {
                    b.HasOne("portfolio_api.Models.Contact")
                        .WithMany("Addresses")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("portfolio_api.Models.FrameworksAndLibs", b =>
                {
                    b.HasOne("portfolio_api.Models.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("portfolio_api.Models.Language", b =>
                {
                    b.HasOne("portfolio_api.Models.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("portfolio_api.Models.Phones.PhoneNumber", b =>
                {
                    b.HasOne("portfolio_api.Models.Contact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactId");
                });
        }
    }
}
