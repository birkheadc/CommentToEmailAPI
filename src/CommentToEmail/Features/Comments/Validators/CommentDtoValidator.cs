using CommentToEmail.Features.Comments.Dtos;
using FluentValidation;

namespace CommentToEmail.Features.Comments.Validators;

public class CommentDtoValidator : AbstractValidator<CommentDto>
{
  public CommentDtoValidator()
  {
    RuleFor(x => x.Site).NotEmpty();
    RuleFor(x => x.Name).NotEmpty();
    RuleFor(x => x.Body).NotEmpty();
  }
}
