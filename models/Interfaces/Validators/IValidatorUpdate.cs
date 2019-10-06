using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Models.Interfaces.Validators
{
    /// <summary>
    /// An entity that requires update validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatorUpdate<S, T> where S : Entity, new() where T : IInfo<T>
    {
        Validation<S> Validate(S search, T input);
    }
}
