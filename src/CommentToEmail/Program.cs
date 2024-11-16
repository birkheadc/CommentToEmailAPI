using CommentToEmail.Features.Comments.Dtos;
using CommentToEmail.Features.Comments.Services;
using CommentToEmail.Features.Comments.Validators;
using CommentToEmail.Features.Common.Filters.FluentValidationFilter;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(o =>
{
  o.Filters.Add<FluentValidationFilter>();
});

builder.Services.AddScoped<IValidator<CommentDto>, CommentDtoValidator>();
builder.Services.AddScoped<ICommentsService, CommentsService>();

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Comment to Email API Root Endpoint. [ Version 1.0.0 ]");

app.Run();
