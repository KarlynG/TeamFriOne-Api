using Microsoft.EntityFrameworkCore;
using TeamFriOne_Infrastructure.Services;
using TeamFriOne_Model.Context;
using TeamFriOne_Model.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region repository
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IVacationRepository, VacationRepository>();
builder.Services.AddTransient<IPayrollRepository, PayrollRepository>();

#endregion

#region services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IVacationService, VacationService>();
builder.Services.AddTransient<IPayrollService, PayrollService>();

#endregion

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MainPolicy",
          builder =>
          {
              builder
                     .SetIsOriginAllowed(x => true)
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowCredentials();

          });
});
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("nueva politica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("nueva politica");

app.UseHttpsRedirection();

app.UseCors("MainPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
