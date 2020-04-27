using System;
using System.Reflection;
using FluentValidation;

namespace AutoDealer.Business.Functionality.Factories
{
    public class FluentValidatorsFactory : IValidatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FluentValidatorsFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)GetValidator(typeof(T));
        }

        public IValidator GetValidator(Type type)
        {
            try
            {
                return CreateInstance(typeof(IValidator<>).MakeGenericType(type));
            }
            catch (Exception)
            {
                var baseType = type.GetTypeInfo().BaseType;
                if (baseType == null)
                {
                    throw;
                }

                return CreateInstance(typeof(IValidator<>).MakeGenericType(baseType));
            }
        }

        private IValidator CreateInstance(Type validatorType)
        {
            return _serviceProvider.GetService(validatorType) as IValidator;
        }
	}
}
