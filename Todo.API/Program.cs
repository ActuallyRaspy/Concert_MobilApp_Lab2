using Microsoft.EntityFrameworkCore;
using Todo.API.Profiles;
using Todo.Data;
using Todo.Data.Repository;
using TodoAPI.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext, UnitOfWork, and AutoMapper to the Services container
//builder.Services.AddSingleton<ITodoRepository, TodoRepository>(); <-- don't need this anymore
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Todo"))
);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //Automatically loads all profiles in Profile folder

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