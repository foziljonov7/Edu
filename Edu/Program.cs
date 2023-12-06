using Edu.Data;
using Edu.Dtos;
using Edu.Entities;
using Edu.Filters;
using Edu.Services;
using Edu.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("localhost");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(o
    => o.UseSqlServer(connectionString));

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddTransient<IValidator<CreateCourseDto>, CreateCourseValidator>();
builder.Services.AddTransient<IValidator<UpdateCourseDto>, UpdateCourseValidator>();
builder.Services.AddTransient<IValidator<CreateTeacherDto>, CreateTeacherValidator>();
builder.Services.AddTransient<IValidator<UpdateTeacherDto>, UpdateTeacherValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
