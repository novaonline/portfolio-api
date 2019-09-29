namespace PortfolioApi.Models.Helpers
{
    public class ServiceMessage<T> where T : Entity
    {
        public T Result { get; set; }
        public Validation<T> Validation { get; set; }
    }
}
