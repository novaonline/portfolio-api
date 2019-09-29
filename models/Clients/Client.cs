namespace PortfolioApi.Models.Clients
{
    public class Client : Entity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Secret { get; set; }
        public string Name { get; set; }
    }
}
