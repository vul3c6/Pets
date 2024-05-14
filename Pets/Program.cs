using Pets.Repositories;
using Pets.Contracts;
using Pets.Interfaces;
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
        //允許任何標頭
        .AllowAnyMethod()
        //允許任何 HTTP 方法
        .AllowAnyOrigin();
    });
});

builder.Services.AddSingleton<DbContext>();

builder.Services.AddScoped<IMember, MemberRepository>();
builder.Services.AddScoped<ImyPet, myPetRepository>();
builder.Services.AddScoped<ILost, LostRepository>();
builder.Services.AddScoped<IReceive, ReceiveRepository>();
builder.Services.AddScoped<IVaccine, VaccineRepository>();
// 將CrossRepository 類型的實例注入到ICross 容器中
builder.Services.AddScoped<ICross1, Cross1Repositories>();
builder.Services.AddScoped<ICross2, Cross2Repositories>();

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
