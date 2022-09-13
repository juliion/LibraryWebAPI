using LibraryBLL.DTOs.Requests;
using FluentValidation;

namespace LibraryBLL.Validators
{
    public class SaveBookDTOValidator : AbstractValidator<SaveBookDTO>
    {
        public SaveBookDTOValidator()
        {
            RuleFor(b => b.Title)
                .NotNull()
                .NotEmpty();
            RuleFor(b => b.Cover)
                .NotNull()
                .NotEmpty();
            RuleFor(b => b.Content)
                .NotNull()
                .NotEmpty();
            RuleFor(b => b.Genre)
                .NotNull()
                .NotEmpty();
            RuleFor(b => b.Author)
                .NotNull()
                .NotEmpty();
        }
    }
}
