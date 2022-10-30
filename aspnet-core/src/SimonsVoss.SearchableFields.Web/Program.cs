using SimonsVoss.SearchableFields.Web.Application;
using SimonsVoss.SearchableFields.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IJsonDataImporter, JsonDataImporter>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string defaultCorsPolicyName = "localhost";
var corsOrigins = builder.Configuration["CorsOrigins"];

builder.Services.AddCors(
    options => options.AddPolicy(
        defaultCorsPolicyName,
        builder => builder
            .WithOrigins(
                corsOrigins
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseCors(defaultCorsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();