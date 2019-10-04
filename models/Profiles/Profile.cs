namespace PortfolioApi.Models.Profiles
{
    public class Profile : Entity
    {
        public ProfileInfo Info { get; set; }

        public Profile()
        {
            this.Info = new ProfileInfo();
        }
    }
}
