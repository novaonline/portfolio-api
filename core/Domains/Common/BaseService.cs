using PortfolioApi.Models;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Helpers.Exceptions;
using PortfolioApi.Models.Interfaces;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Models.Interfaces.Services;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Common
{
	public class BaseService<T, I> : IService<T, I> where T : Entity, new() where I : IInfo<I>
	{
		protected readonly IValidatorCreate<T> _validateForCreation;
		protected readonly IValidatorUpdate<T, I> _validateForUpdate;
		protected readonly IValidatorDelete<T> _validateForDelete;
		protected readonly IRepoCrud<T, I> _repo;

		protected BaseService(IRepoCrud<T, I> profileRepo,
			IValidatorCreate<T> validateForCreation,
			IValidatorUpdate<T, I> validateForUpdate,
			IValidatorDelete<T> validateForDelete)
		{
			_validateForCreation = validateForCreation;
			_validateForUpdate = validateForUpdate;
			_validateForDelete = validateForDelete;
			_repo = profileRepo;
		}
		public ServiceMessage<T> Create(T input, RequestContext requestContext)
		{
			var validationResult = _validateForCreation.Validate(input);
			var result = new ServiceMessage<T> { Validation = validationResult };
			if (validationResult.IsValid)
			{
				result.Result = _repo.Create(validationResult.Result, requestContext);
			}
			return result;
		}

		public ServiceMessage<T> Delete(T input, RequestContext requestContext)
		{
			var validationResult = _validateForDelete.Validate(input);
			var result = new ServiceMessage<T> { Validation = validationResult };
			if (validationResult.IsValid)
			{
				result.Result = _repo.Delete(validationResult.Result, requestContext);
			}
			return result;
		}

		public ServiceMessages<T> Read(T input, RequestContext requestContext)
		{
			var result = new ServiceMessages<T>
			{
				Results = _repo.Read(input, requestContext)
			};
			return result;
		}

		public ServiceMessage<T> Update(T search, I input, RequestContext requestContext)
		{
			var validationResult = _validateForUpdate.Validate(search, input);
			var result = new ServiceMessage<T> { Validation = validationResult };
			if (validationResult.IsValid)
			{
				result.Result = _repo.Update(validationResult.Result, input, requestContext);
			}
			return result;
		}
	}
}
