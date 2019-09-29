namespace PortfolioApi.Models.Interfaces.Validators
{
    /// <summary>
    /// An entity that requires reading validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatorRead<T> : IValidator<T> where T : Entity { }
}
