using Microsoft.EntityFrameworkCore;
//using TeamFriOne_Infrastructure.Services;
using TeamFriOne_Model.Context;
using TeamFriOne_Model.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region repository
builder.Services.AddTransient<IUserRepository, UserRepository>();

#endregion

#region services
//builder.Services.AddTransient<IUserService, UserService>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
