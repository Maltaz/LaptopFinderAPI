using FluentValidation;
using FluentValidation.AspNetCore;
using LaptopFinder.Core.Repositories;
using LaptopFinder.Core.Services;
using LaptopFinderAPI;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(sg => sg.EnableAnnotations());
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => 
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        );
});

builder.Services.AddScoped<ICBRService, CBRService>();
builder.Services.AddSingleton<IMongoClientFactory>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var connectionString = config.GetConnectionString("MongoDB");
    return new MongoDbClientFactory(connectionString);
});
builder.Services.AddScoped<ICaseRepository>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var connectionString = config.GetConnectionString("MongoDB");

    var clientFactory = sp.GetRequiredService<IMongoClientFactory>();
    var mongoClient = clientFactory.GetMongoClient();

    return new CaseRepository(mongoClient);
});
builder.Services.AddScoped<ILaptopRepository>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var connectionString = config.GetConnectionString("MongoDB");

    var clientFactory = sp.GetRequiredService<IMongoClientFactory>();
    var mongoClient = clientFactory.GetMongoClient();

    return new LaptopRepository(mongoClient);
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
