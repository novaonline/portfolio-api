using System.Collections.Generic;
using System.Linq;

namespace PortfolioApi.Models.Helpers
{
    /// <summary>
    /// A model to package validation messages
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Validation<T> where T : Entity, new()
    {
        /// <summary>
        /// The result of the data after validation. Some clean up may have happened
        /// </summary>
        /// <value></value>
        public T Result { get; set; }

        /// <summary>
        /// The error messages foreach property
        /// </summary>
        /// <value></value>
        public Dictionary<string, List<ValidationErrorMessage>> ErrorMessagesPerProperty { get; set; }

        /// <summary>
        /// Determines if the Validation message is valid
        /// </summary>
        /// <value></value>
        public bool IsValid => !ErrorMessagesPerProperty.Any();

        public Validation() 
        {
            this.Result = new T();
            ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>();
        }

    }
}
