namespace CommentToEmail.Features.Comments.Options;

public class EmailOptions
{
  public required string From { get; set; }
  public required string Subject { get; set; }
  public required string To { get; set; }
}
