namespace PortfolioApi.Models.Interfaces.Validators
{
    /// <summary>
    /// An entity that requires delete validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatorDelete<T> : IValidator<T> where T : Entity { }
}
