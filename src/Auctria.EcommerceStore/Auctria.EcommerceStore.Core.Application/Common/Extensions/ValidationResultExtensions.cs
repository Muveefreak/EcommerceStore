using FluentValidation.Results;

namespace Auctria.EcommerceStore.Core.Application.Common.Extensions;

public static class ValidationResultExtensions
{
    public static IList<ValidationFailure> ValidationFailure(this ValidationResult input)
    {
        return input.Errors.Any() ? input.Errors.ToList() : new List<ValidationFailure>();
    }

    public static IList<ValidationFailure> ValidationFailure(this ValidationResult[] input)
    {
        return input
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();
    }
}
