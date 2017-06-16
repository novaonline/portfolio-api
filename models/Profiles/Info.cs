using System;

namespace PortfolioApi.Models.Profiles
{
    public class Info : InfoItem, IPortfolioInfo<Info>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUrl { get; set; }
        public string AboutMe { get; set; }

        public void Update(Info model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            BirthDate = model.BirthDate;
            ImageUrl = model.ImageUrl;
            AboutMe = model.AboutMe;
        }
    }
}
