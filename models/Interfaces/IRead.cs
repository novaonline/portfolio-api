using System.Collections.Generic;

namespace PortfolioApi.Models.Interfaces
{
    /// <summary>
    /// General read of entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRead<I,O>
    {
         O Get(I input);
    }
}
