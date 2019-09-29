namespace PortfolioApi.Models.Interfaces.Validators
{
    /// <summary>
    /// An entity that requires create validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatorCreate<T> : IValidator<T> where T : Entity { }
}
