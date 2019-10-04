using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Models.Interfaces.Validators
{
    /// <summary>
    /// An entity that requires reading validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatorRead<T> where T : Entity, new()
    {
        Validation<T> Validate(T input);
    }
}
