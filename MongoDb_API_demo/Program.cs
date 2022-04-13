using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDb_API_demo;
using MongoDb_API_demo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DBSettigs>(builder.Configuration.GetSection("DBSettigs"));
builder.Services.AddSingleton<IMongoClient>(s=>new MongoClient(builder.Configuration.GetValue<string>("DBSettigs:ConnectionString")));
builder.Services.AddScoped<IStudentService,StudentService>();

builder.Services.AddControllers();
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
