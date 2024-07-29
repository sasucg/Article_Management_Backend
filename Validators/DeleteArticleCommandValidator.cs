using FluentValidation;
using Article_Management_Backend.Commands;

public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand>
{
    public DeleteArticleCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty().WithMessage("ArticleId is required.");
    }
}