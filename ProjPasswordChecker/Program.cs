using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using ProjPasswordCheck.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Injeção de dependência para IConfiguration
builder.Services.AddSingleton(builder.Configuration);


// Adicione os serviços necessários aqui
builder.Services.AddScoped<IValidationRule, LengthValidationRule>();
builder.Services.AddScoped<IValidationRule, DigitValidationRule>();
builder.Services.AddScoped<IValidationRule, LowercaseValidationRule>();
builder.Services.AddScoped<IValidationRule, UppercaseValidationRule>();
builder.Services.AddScoped<IValidationRule, SpecialCharacterValidationRule>();
builder.Services.AddScoped<IValidationRule, NoRepeatingCharactersValidationRule>();
builder.Services.AddScoped<IValidationRule, SpaceValidationRule>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.IgnoreNullValues = true;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Password Checker API",
        Version = "v1",
        Description = "API para verificar a força de senhas",
        Contact = new OpenApiContact
        {
            Name = "Eraldo A S Jr",
            Email = "eraldojunior096@gmail.com",
            Url = new Uri("https://github.com/eraldoASJr")
        }
    });
});

var app = builder.Build();

// Configuração do pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Password Checker API");
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
