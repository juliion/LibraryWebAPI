using LibraryBLL.DTOs.Requests;
using FluentValidation;

namespace LibraryBLL.Validators
{
    public class SaveReviewDTOValidator : AbstractValidator<SaveReviewDTO>
    {
        public SaveReviewDTOValidator()
        {
            RuleFor(r => r.Message)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.Reviewer)
                .NotNull()
                .NotEmpty();
        }
    }
}
