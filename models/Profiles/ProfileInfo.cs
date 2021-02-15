using System;

namespace PortfolioApi.Models.Profiles
{
    public class ProfileInfo : Info<ProfileInfo>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? AboutMe { get; set; }

        public ProfileInfo() { }

        public ProfileInfo(ProfileInfo model) : this()
        {
            UpdateProperties(model);
        }

        public override void UpdateProperties(ProfileInfo update)
        {
            this.AboutMe = update.AboutMe ?? this.AboutMe;
            this.BirthDate = update.BirthDate ?? this.BirthDate;
            this.FirstName = update.FirstName ?? this.FirstName;
            this.ImageUrl = update.ImageUrl ?? this.ImageUrl;
            this.LastName = update.LastName ?? this.LastName;
        }
    }
}
