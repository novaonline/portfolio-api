namespace PortfolioApi.Models.Profiles
{
    public class Profile : Entity
    {
        public ProfileInfo Info { get; set; }

        public Profile()
        {
            this.Info = new ProfileInfo();
        }

        public Profile(int Id) : this()
        {
            this.Id = Id;
        }
    }
}
