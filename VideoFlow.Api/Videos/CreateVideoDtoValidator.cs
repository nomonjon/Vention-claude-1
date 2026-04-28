using FluentValidation;

namespace VideoFlow.Api.Videos;

public class CreateVideoDtoValidator : AbstractValidator<CreateVideoDto>
{
    public CreateVideoDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Title must be at most 100 characters long.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(200).WithMessage("Description must be at most 200 characters long.");

        RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId is required.");
    }
}
