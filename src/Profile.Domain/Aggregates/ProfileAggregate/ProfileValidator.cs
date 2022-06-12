using FluentValidation;
using Profile.Domain.Exceptions;

namespace Profile.Domain.Aggregates.ProfileAggregate;

public class ProfileValidator : AbstractValidator<Profile>
{
    private static readonly string[] Location = { "request" };
    
    public ProfileValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithState(_ => new InvalidRequestMessage("Id should not be empty."))
            .MaximumLength(64)
            .WithState(_ => new InvalidRequestMessage("Id length should be less then or equal to 64."));
        
        var nameLocation = new List<string>(Location) { "name" };
        RuleFor(x => x.Name)
            .MaximumLength(64)
            .WithState(_ => new ValidationMessage(
                nameLocation,
                "Validation:ProfileNameMaximumLengthError"));
        
        var surnameLocation = new List<string>(Location) { "surname" };
        RuleFor(x => x.Surname)
            .MaximumLength(64)
            .WithState(_ => new ValidationMessage(
                surnameLocation,
                "Validation:ProfileSurnameMaximumLengthError"));
        
        var descriptionLocation = new List<string>(Location) { "description" };
        RuleFor(x => x.Description)
            .MaximumLength(512)
            .WithState(_ => new ValidationMessage(
                descriptionLocation,
                "Validation:ProfileDescriptionMaximumLengthError"));
    }
}