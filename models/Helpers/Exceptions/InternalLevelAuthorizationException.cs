using System;
using System.Runtime.Serialization;

namespace PortfolioApi.Models.Helpers.Exceptions
{
	public class InternalLevelAuthorizationException : Exception
	{
		public InternalLevelAuthorizationException()
		{
		}

		public InternalLevelAuthorizationException(string message) : base(message)
		{
		}

		public InternalLevelAuthorizationException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InternalLevelAuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
