using Tutorial4.Database;
using Tutorial4.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<AnimalShelter>();
<<<<<<< HEAD
builder.Services.AddSingleton<AnimalVisits>();
=======

>>>>>>> baac5c9a7fc0cc7dfdaa8f6d37830c5e52807650
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Minimal API
app.MapAnimalEndpoints();
app.MapVisitEndpoints();
// Controllers
// W tym podejściu zdecydowałem się korzystać z Minimal API
// Kontrolery nie są wykorzystane
app.MapControllers();
app.Run();