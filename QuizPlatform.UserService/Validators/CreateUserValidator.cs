using FluentValidation;
using QuizPlatform.UserService.Features.Users.DTOs;

namespace QuizPlatform.UserService.Validators;

public class CreateUserValidator:AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(x=>x.Name).NotEmpty().WithMessage("Nome obbligatorio");
        RuleFor(x=>x.Surname).NotEmpty().WithMessage("Cognome obbligatorio");
        RuleFor(x=>x.Email).NotEmpty().EmailAddress().WithMessage("Email obbligatorio");
        RuleFor(x=>x.Password).NotEmpty().WithMessage("Password obbligatoria");
    }
}