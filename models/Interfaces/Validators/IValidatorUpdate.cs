namespace PortfolioApi.Models.Interfaces.Validators
{
    /// <summary>
    /// An entity that requires update validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatorUpdate<T> : IValidator<T> where T : Entity { }
}
