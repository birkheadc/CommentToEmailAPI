using System.Text.Json;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using CommentToEmail.Features.Comments.Dtos;
using CommentToEmail.Features.Comments.Options;
using CommentToEmail.Features.Common.Utils.Result;
using Microsoft.Extensions.Options;

namespace CommentToEmail.Features.Comments.Services;

public class CommentsService(
  IOptions<CommentsOptions> options,
  IAmazonSimpleEmailService amazonSimpleEmailService
) : ICommentsService
{
  private readonly IOptions<CommentsOptions> _options = options;
  private readonly IAmazonSimpleEmailService _amazonSimpleEmailService = amazonSimpleEmailService;

  public async Task<ApiResult> ProcessComment(CommentDto comment)
  {
    Console.WriteLine("Processing comment");
    string emailBody = GenerateEmailBody(comment);
    ApiResult result = await SendEmail(emailBody);
    return result;
  }

  private async Task<ApiResult> SendEmail(string body)
  {
    Console.WriteLine("Preparing request");
    SendEmailRequest request =
      new()
      {
        Source = _options.Value.Email.From,
        Destination = new Destination { ToAddresses = [_options.Value.Email.To] },
        Message = new Message
        {
          Subject = new Content { Charset = "UTF-8", Data = _options.Value.Email.Subject },
          Body = new Body
          {
            Text = new Content { Charset = "UTF-8", Data = body },
          },
        },
      };

    Console.WriteLine("Sending email");
    try
    {
      SendEmailResponse response = await _amazonSimpleEmailService.SendEmailAsync(request);
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error sending email");
      Console.WriteLine(ex);
      return ApiResult.Failure(ApiResultErrors.InternalServerError);
    }

    Console.WriteLine("Email sent successfully");
    return ApiResult.Success();
  }

  private string GenerateEmailBody(CommentDto comment)
  {
    return $"You have a new comment!\n\nSite: {comment.Site}\nName: {comment.Name}\n\n{comment.Body}";
  }
}
