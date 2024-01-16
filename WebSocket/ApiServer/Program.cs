using ApiServer.Server.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

var MyAllowSpecificOrigins = "AllOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddPolicy(name: MyAllowSpecificOrigins, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options =>
    options.MimeTypes = ResponseCompressionDefaults
    .MimeTypes
    .Concat(new[] { "application/octet-stream" })
);



builder.Services.AddCors(o => o.AddPolicy(name: MyAllowSpecificOrigins, builder => 
builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();


app.UseCors(MyAllowSpecificOrigins);

app.UseResponseCompression();
app.MapHub<ChatHub>("/chathub");


app.MapGet("/index", async context =>
{
    var response = context.Response;
    response.ContentType = "text/html";
    var fileContent = File.ReadAllText("wwwroot/index.html");
    await response.WriteAsync(fileContent);
});

app.Run();

