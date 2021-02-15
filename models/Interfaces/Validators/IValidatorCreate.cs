using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Models.Interfaces.Validators
{
    /// <summary>
    /// An entity that requires create validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatorCreate<T> where T : Entity, new()
    {
        Validation<T> Validate(T input);
    }
}
