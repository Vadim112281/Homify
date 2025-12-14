using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using Homify.Monolith.Application.Common.Results;
using Homify.Monolith.Application.Profiles;
using Homify.Monolith.Application.Services.ApartmentService;
using Homify.Monolith.Application.Validators.Apartment;
using Homify.Monolith.Domain.Models;
using Homify.Monolith.Infrastructure.Data;
using Homify.Monolith.Infrastructure.Repositories.Apartment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(o =>
        o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .SelectMany(x => x.Value!.Errors.Select(e => $"{x.Key}: {e.ErrorMessage}"))
            .ToList();

        var result = Result<object?>.Failure(errors);
        
        return new BadRequestObjectResult(result);
    };
});

// Db
builder.Services.AddDbContext<HomifyDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(ApartmentProfile).Assembly);

// Roles
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<HomifyDbContext>()
    .AddDefaultTokenProviders();

// Repositories
builder.Services.AddTransient<IApartmentRepository, ApartmentRepository>();

// Services
builder.Services.AddTransient<IApartmentService, ApartmentService>();

// Validators
builder.Services.AddValidatorsFromAssemblyContaining<ApartmentDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();