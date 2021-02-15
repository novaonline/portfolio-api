using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Models.Interfaces.Validators
{
    /// <summary>
    /// An entity that requires delete validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatorDelete<T> where T : Entity, new()
    {
        Validation<T> Validate(T input);
    }
}
