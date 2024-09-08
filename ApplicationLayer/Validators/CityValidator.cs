using ApplicationLayer.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Validators
{
    public class CityValidator : AbstractValidator<CityDTO>
    {
        private const int MinAllowedNumberOfCitizens = 0;
        private const int MaxAllowedNumberOfCitizens = 2000000;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CityValidator(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;

            RuleFor(dto => dto.Name)
                .NotNull().NotEmpty().WithMessage("Please specify a name.")
                .Length(3, 50).WithMessage("Name must be between 3 and 50 characters.")
                .Matches("^[А-ШA-Z][а-шa-zА-ШA-Z]*( [а-шa-zА-ШA-Z]+)*$").WithMessage("Name must start wiht a capital letter and contain Serbian Cyrillic or Latin letters.");

            RuleFor(dto => dto.PostCode)
                .NotNull().NotEmpty().WithMessage("Please specify a zip code.")
                .InclusiveBetween(10000, 99999).WithMessage("Zip code must contains exactly 5 digits.");

            RuleFor(dto => dto.NumberOfCitizens)
                .GreaterThanOrEqualTo(MinAllowedNumberOfCitizens)
                .LessThanOrEqualTo(MaxAllowedNumberOfCitizens)
                .WithMessage("Number of citizens must be between 0 and 2 000 000.");

        }

        private bool IsPatchRequest()
        {
            var httpMethod = _httpContextAccessor.HttpContext?.Request.Method;
            return httpMethod != null && httpMethod.Equals("PATCH", StringComparison.OrdinalIgnoreCase);
        }
        private bool IsPutRequest()
        {
            var httpMethod = _httpContextAccessor.HttpContext?.Request.Method;
            return httpMethod != null && httpMethod.Equals("PUT", StringComparison.OrdinalIgnoreCase);
        }
    }
}
