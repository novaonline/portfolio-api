using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Models.Clients
{
    public class Client : DateAware
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Secret { get; set; }
        public string Name { get; set; }
    }
}
