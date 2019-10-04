using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Models.Interfaces.Validators
{
    /// <summary>
    /// An entity that requires update validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatorUpdate<T> where T : Entity, new()
    {
        Validation<T> Validate(T input);
    }
}
