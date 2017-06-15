using System;

namespace PortfolioApi.Models.Profiles
{
    public class Info : InfoItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUrl { get; set; }
        public string AboutMe { get; set; }
    }
}
