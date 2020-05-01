using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace AutoDealer.Business.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProp> NotEmptyWithMessage<T, TProp>(this IRuleBuilder<T, TProp> options)
        {
            return options.NotEmpty().WithMessage($"Field {{PropertyName}} can not be empty");
        }
        
        public static IRuleBuilderOptions<T, string> MaxLengthWithMessage<T>(this IRuleBuilder<T, string> options,int length)
        {
            return options.MaximumLength(length)
                .WithMessage($"The value of the field {{PropertyName}} can not be more than {length}");
        }

        public static IRuleBuilderOptions<T, int> IsPositiveWithMessage<T>(this IRuleBuilder<T, int> options)
        {
            return options.GreaterThan(0).WithMessage($"The value of the field {{PropertyName}} should be positive ");
        }

        public static IRuleBuilderOptions<T, int> IsPositiveOrZeroWithMessage<T>(this IRuleBuilder<T, int> options)
        {
            return options.GreaterThanOrEqualTo(0)
                .WithMessage($"The value of the field {{PropertyName}} should be positive ");
        }

        public static IRuleBuilderOptions<T, string> IsValidEmailWithMessage<T>(this IRuleBuilder<T, string> options)
        {
            return options.EmailAddress()
                .WithMessage($"The value of the field {{PropertyName}} has invalid email format");
        }

        public static IRuleBuilderOptions<T, string> IsValidPhoneNumberWithMessage<T>(this IRuleBuilder<T, string> options)
        {
            return options.Matches(@"^[0-9\(\)\-\+ ]{6,}$")
                .WithMessage($"The value of the field {{PropertyName}} has invalid phone format");
        }

        public static IRuleBuilderOptions<T, string> IsValidEinWithMessage<T>(this IRuleBuilder<T, string> options)
        {
            return options.Matches(@"^[1-9]\d?-\d{7}$")
                .WithMessage($"The value of the field {{PropertyName}} has invalid EIN format");
        }

        public static IRuleBuilderOptions<T, TProp> MustExistsWithMessageAsync<T, TProp>(this IRuleBuilder<T, TProp> options, Func<TProp, CancellationToken, Task<bool>> condition)
        {
            return options.MustAsync(condition).WithMessage($"The {{PropertyName}} you have entered does not exist");
        }

        public static IRuleBuilderOptions<T, TProp> MustExistsWithMessageAsync<T, TProp>(this IRuleBuilder<T, TProp> options, Func<T, CancellationToken, Task<bool>> predicate)
        {
            return options.MustAsync((obj, prop, token) => predicate(obj, token)).WithMessage($"The {{PropertyName}} you have entered does not exist");
        }

        public static IRuleBuilderOptions<T, TProp> MustNotExistWithMessageAsync<T, TProp>(this IRuleBuilder<T, TProp> options, Func<TProp, CancellationToken, Task<bool>> condition)
        {
            return options.MustAsync(condition).WithMessage($"The {{PropertyName}} you have entered already exists");
        }

        public static IRuleBuilderOptions<T, TProp> MustNotExistWithMessageAsync<T, TProp>(this IRuleBuilder<T, TProp> options, Func<T, CancellationToken, Task<bool>> predicate)
        {
            return options.MustAsync((obj, prop, token) => predicate(obj, token)).WithMessage($"The {{PropertyName}} you have entered already exists");
        }
    }
}
