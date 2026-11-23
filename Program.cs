using HelloApi.Models;
using HelloApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddScoped<MessageService>();

var app = builder.Build();

app.MapGet("/api/hello", (MessageService messageService) =>
{
    return new HelloResponse
    {
        Message = messageService.GetMessage()
    };
});

app.Run();