using CommentToEmail.Features.Comments.Dtos;
using CommentToEmail.Features.Comments.Services;
using CommentToEmail.Features.Common.Utils.Result;
using Microsoft.AspNetCore.Mvc;

namespace CommentToEmail.Features.Comments.Controllers;

[ApiController]
[Route("comments")]
public class CommentsController(ICommentsService commentsService) : ControllerBase
{
  private readonly ICommentsService _commentsService = commentsService;

  [HttpPost]
  public IActionResult Post([FromBody] CommentDto comment)
  {
    ApiResult result = _commentsService.ProcessComment(comment);
    return result.GetActionResult();
  }
}
