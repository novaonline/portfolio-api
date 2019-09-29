using System;

namespace PortfolioApi.Models.Profiles
{
	public class ProfileInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUrl { get; set; }
        public string AboutMe { get; set; }

        public ProfileInfo() { }

        public ProfileInfo(ProfileInfo model) : this()
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            BirthDate = model.BirthDate;
            ImageUrl = model.ImageUrl;
            AboutMe = model.AboutMe;
        }
    }
}
