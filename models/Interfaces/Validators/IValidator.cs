using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Models.Interfaces.Validators
{
    /// <summary>
    /// An entity that requires validation of some sort
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<T> where T : Entity
    {
        Validation<T> Validate(T input);
    }
}
