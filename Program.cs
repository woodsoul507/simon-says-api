using Microsoft.OpenApi.Models;
using SimonSays.API.Core;
using SimonSays.API.SwaggerExamples.Requests;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ISimonSays, SimonSays.API.Core.SimonSays>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Simon Says API",
        Description = "An ASP.NET Core Web API that simulates the classic Simon Says game. ",
        Contact = new OpenApiContact
        {
            Name = "Documentation",
            Url = new Uri("https://github.com/woodsoul507/simon-says-api")
        },
        License = new OpenApiLicense
        {
            Name = "Simon Says API is an open source project under MIT license",
            Url = new Uri("https://github.com/woodsoul507/simon-says-api/blob/main/LICENSE")
        }
    });

    options.ExampleFilters();

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<SimonSaysPostRequestExample>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
