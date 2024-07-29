using FluentValidation;
using Article_Management_Backend.Commands;

public class UpdatedArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
{
    public UpdatedArticleCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty().WithMessage("ArticleId is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
        RuleFor(x => x.ArticleCode).NotEmpty().WithMessage("Article Code is required.")
                                   .MaximumLength(50).WithMessage("Article Code cannot exceed 50 characters.");
        RuleFor(x => x.ArticleCategoryId).NotEmpty().WithMessage("Category Name is required.");
        RuleFor(x => x.ArticleStatusId).NotEmpty().WithMessage("Status Name is required.");
    }
}