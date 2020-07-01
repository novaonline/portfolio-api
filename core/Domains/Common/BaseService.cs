using PortfolioApi.Models;
using PortfolioApi.Models.Helpers;
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
        protected readonly IRepoCrud<T, I> _profileRepo;

        protected BaseService(IRepoCrud<T, I> profileRepo,
            IValidatorCreate<T> validateForCreation,
            IValidatorUpdate<T, I> validateForUpdate,
            IValidatorDelete<T> validateForDelete)
        {
            _validateForCreation = validateForCreation;
            _validateForUpdate = validateForUpdate;
            _validateForDelete = validateForDelete;
            _profileRepo = profileRepo;
        }
        public ServiceMessage<T> Create(T input)
        {
            var validationResult = _validateForCreation.Validate(input);
            var result = new ServiceMessage<T> { Validation = validationResult };
            if (validationResult.IsValid)
            {
                result.Result = _profileRepo.Create(validationResult.Result);
            } 
            return result;
        }

        public ServiceMessage<T> Delete(T input)
        {
            var validationResult = _validateForDelete.Validate(input);
            var result = new ServiceMessage<T> { Validation = validationResult };
            if (validationResult.IsValid)
            {
                result.Result = _profileRepo.Delete(validationResult.Result);
            }
            return result;
        }

        public ServiceMessages<T> Read(T input)
        {
            var result = new ServiceMessages<T>();
            result.Results = _profileRepo.Read(input);
            return result;
        }

        public ServiceMessage<T> Update(T search, I input)
        {
            var validationResult = _validateForUpdate.Validate(search, input);
            var result = new ServiceMessage<T> { Validation = validationResult };
            if (validationResult.IsValid)
            {
                result.Result = _profileRepo.Update(validationResult.Result, input);
            }
            return result;
        }
    }
}
