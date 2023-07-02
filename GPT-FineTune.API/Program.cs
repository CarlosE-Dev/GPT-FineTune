using GPT_FineTune.Application.InputModels;
using GPT_FineTune.Application.Interfaces;
using GPT_FineTune.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(BaseInputModel).Assembly));
builder.Services.AddScoped<ITrainingDataService, TrainingDataService>();

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
