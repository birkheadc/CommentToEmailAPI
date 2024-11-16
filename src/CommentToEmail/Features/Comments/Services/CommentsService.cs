using CommentToEmail.Features.Comments.Dtos;
using CommentToEmail.Features.Common.Utils.Result;

namespace CommentToEmail.Features.Comments.Services;

public class CommentsService : ICommentsService
{
  public ApiResult ProcessComment(CommentDto comment)
  {
    Console.WriteLine(
      $"Comment received: Site: {comment.Site}, Name: {comment.Name}, Body: {comment.Body}"
    );
    return ApiResult.Success();
  }
}
