using CommentToEmail.Features.Comments.Dtos;
using CommentToEmail.Features.Common.Utils.Result;

namespace CommentToEmail.Features.Comments.Services;

public interface ICommentsService
{
  public Task<ApiResult> ProcessComment(CommentDto comment);
}
