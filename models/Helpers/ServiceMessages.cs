using System.Collections.Generic;
using System.Linq;

namespace PortfolioApi.Models.Helpers
{
    public class ServiceMessages<T> where T : Entity, new()
    {
        public IEnumerable<T> Results { get; set; }
        public Validation<T> Validation { get; set; }

        public ServiceMessages()
        {
            this.Results = new List<T>().AsEnumerable();
            this.Validation = new Validation<T>();
        }
    }
}
