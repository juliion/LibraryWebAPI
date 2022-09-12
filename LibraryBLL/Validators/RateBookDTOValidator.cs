using LibraryBLL.DTOs.Requests;
using FluentValidation;

namespace LibraryBLL.Validators
{
    public class RateBookDTOValidator : AbstractValidator<RateBookDTO>
    {
        public RateBookDTOValidator()
        {
            RuleFor(rb => rb.Score)
                .NotNull()
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(5);
        }
    }
}
