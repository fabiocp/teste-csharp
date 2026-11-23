using HelloApi.Models;
using HelloApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddScoped<MessageService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/hello", (MessageService messageService) =>
{
    return new HelloResponse
    {
        Message = messageService.GetMessage()
    };
});

app.Run();