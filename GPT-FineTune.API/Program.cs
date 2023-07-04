using GPT_FineTune.Application.Commands.TrainingFiles;
using GPT_FineTune.Application.Interfaces;
using GPT_FineTune.Application.Services;
using GPT_FineTune.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(FormatTrainingDataCommand).Assembly));
builder.Services.AddScoped<ITrainingDataService, TrainingDataService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFineTuneService, FineTuneService>();
builder.Services.AddScoped<IFileApiRepository, FileApiRepository>();
builder.Services.AddScoped<IFineTuneApiRepository, FineTuneApiRepository>();
builder.Services.AddHttpClient();
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
