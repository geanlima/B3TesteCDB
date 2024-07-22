
using CDBCalculator.Domain.Interfaces;
using CDBCalculator.Domain.Services;
using CDBCalculator.Domain.Validators;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInvestmentCalculator, InvestmentCalculatorService>();
builder.Services.AddScoped<IInvestmentRequestValidator, InvestmentRequestValidator>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .AllowAnyOrigin() 
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseCors("AllowAngularApp");

app.MapControllers();

await app.RunAsync();
