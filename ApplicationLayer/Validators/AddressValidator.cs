using ApplicationLayer.DTO;
using FluentValidation;

namespace ApplicationLayer.Validators
{
    public class AddressValidator : AbstractValidator<AddressDTO>
    {
        public AddressValidator()
        {
            RuleFor(dto => dto.Street)
                .NotNull().NotEmpty().WithMessage("Please specify a street name.")
                .Length(3, 50).WithMessage("Street name must be between 3 and 50 characters.")
                .Matches("^[А-ШA-Z][а-шa-zА-ШA-Z]*( [а-шa-zА-ШA-Z]+)*$").WithMessage("Street name must start wiht a capital letter and contain Serbian Cyrillic or Latin letters.");

            RuleFor(dto => dto.Number)
                .NotNull().NotEmpty().WithMessage("Please specify a address number.")
                .GreaterThan(0).WithMessage("Number must be greater than 0.");

            RuleFor(dto => dto.Floor)
                .GreaterThanOrEqualTo(0).WithMessage("Floor must be greater than or equal to 0.");
        }

    }
}
