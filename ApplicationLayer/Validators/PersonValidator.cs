using ApplicationLayer.DTO;
using FluentValidation;

namespace ApplicationLayer.Validators
{
    public class PersonValidator : AbstractValidator<PersonDTO>
    {
        private static readonly DateTime MinAllowedDateOfBirth = new DateTime(1920, 1, 1);
        private const int MinAllowedHeight = 50;
        private const int MAxAllowedHeight = 250;

        public PersonValidator() 
        {
            RuleFor(dto => dto.FirstName)
                .NotNull().NotEmpty().WithMessage("Please specify a first name.")
                .Length(3, 33).WithMessage("First name must be between 3 and 33 characters.")
                .Matches("^[А-ШA-Z][а-шa-zА-ШA-Z]*$").WithMessage("First name must start wiht a capital letter and contain Serbian Cyrillic or Latin letters.");
            
            RuleFor(dto => dto.LastName)
                .NotNull().NotEmpty().WithMessage("Please specify a last name.")
                .Length(3, 33).WithMessage("Last name must be between 3 and 33 characters.")
                .Matches("^[А-ШA-Z][а-шa-zА-ШA-Z]*$").WithMessage("Last name must start wiht a capital letter and contain Serbian Cyrillic or Latin letters.");

            RuleFor(dto => dto.JMBG)
                .NotEmpty().NotNull().WithMessage("Please specify a JMBG.")
                .Must(BeAValidJMBG).WithMessage("Please specify a valid JMBG (JMBG must ave exactly 13 digits).");
            
            RuleFor(dto => dto.DateOfBirth)
                .GreaterThanOrEqualTo(MinAllowedDateOfBirth)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("Date of birth must not be earlier than 01/01/1920 and must not be in the future.");
           
            RuleFor(dto => dto.Height)
                .InclusiveBetween(MinAllowedHeight, MAxAllowedHeight).WithMessage("Height must be between 50 and 250 cm.");

            RuleFor(dto => dto.Address)
                .NotNull().NotEmpty().WithMessage("Please specify an address.")
                .Length(3, 50).WithMessage("Address must be between 3 and 50 characters.")
                .Matches("^[А-ШA-Z][а-шa-zА-ШA-Z]*( [а-шa-zА-ШA-Z0-9]+)*$").WithMessage("Address must start wiht a capital letter and contain Serbian Cyrillic or Latin letters and numbers.");

        }

        private bool BeAValidJMBG(long jmbg)
        {
            return JMBGValidator.ValidateJMBG(jmbg);
        }
    }
}
