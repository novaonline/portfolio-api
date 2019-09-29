namespace Portfolio.Api.Models.Helpers
{
    public class ValidationErrorMessage
    {
        /// <summary>
        /// The Error Message
        /// </summary>
        /// <value></value>
        public string Message { get; set; }

        /// <summary>
        /// A suggested value if available 
        /// </summary>
        /// <value></value>
        public string Suggestion { get; set; }

        /// <summary>
        /// Additional Help if available
        /// </summary>
        /// <value></value>
        public string Hint { get; set; }

        public ValidationErrorMessage() { }
        public ValidationErrorMessage(string errorMessage) : this()
        {
            this.Message = errorMessage;
        }
    }
}
