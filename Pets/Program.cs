using Pets.Interfaces;
using Pets.Repositories;
using Pets.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAny", policy =>
    {
        policy.WithOrigins("https://localhost:7289", "http://localhost:5067")
        .AllowAnyHeader()
        //���\������Y
        .AllowAnyMethod()
        //���\���� HTTP ��k
        .AllowAnyOrigin();
    });
});

builder.Services.AddSingleton<DbContext>();

builder.Services.AddScoped<ILost, LostRepository>();
builder.Services.AddScoped<IReceive, ReceiveRepository>();
builder.Services.AddScoped<IVaccine, VaccineRepository>();

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

app.UseCors("AllowAny");

app.Run();
