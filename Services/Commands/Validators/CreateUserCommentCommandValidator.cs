using FluentValidation;
using FluentValidation.AspNetCore;

namespace Services.Commands.Validators
{
    public class CreateUserCommentCommandValidator : AbstractValidator<CreateUserCommentCommand>
    {
        public CreateUserCommentCommandValidator()
        {
            RuleFor(x => x.NickName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(25);
            RuleFor(x => x.Comment).NotEmpty().NotNull().MinimumLength(3).MaximumLength(500);
        }
    }
}
