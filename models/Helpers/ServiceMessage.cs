namespace PortfolioApi.Models.Helpers
{
    public class ServiceMessage<T> where T : Entity, new()
    {
        public T Result { get; set; }
        public Validation<T> Validation { get; set; }

        public ServiceMessage()
        {
            this.Result = new T();
            this.Validation = new Validation<T>();
        }
    }
}
