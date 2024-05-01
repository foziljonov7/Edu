using Edu.API.Helpers;
using Edu.Services.Helpers.Mappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.DbConfigure(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.ServiceConfigure();
builder.Services.AddValidatorConfigure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
