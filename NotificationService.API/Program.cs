using Microsoft.EntityFrameworkCore;
using NotificationService.Application.AutoMapperProfiles;
using NotificationService.Infrastructure;
using NotificationService.Infrastructure.Context;
using NotificationService.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InstallInfrastructure();

#region AutoMapper config
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfiles());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region DbContext
var connectionString = builder.Configuration.GetConnectionString("SqlDataBase");
builder.Services.AddDbContext<SqlContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion


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
