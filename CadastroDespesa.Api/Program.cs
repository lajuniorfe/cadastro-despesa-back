using CadastroDespesa.IOC;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

if(builder.Environment.IsProduction()){
    builder.Services.AddInfrastructureServicesProducao(builder.Configuration);
}
else {
    builder.Services.AddInfrastructureServices(builder.Configuration);
}
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CadastroDespesa.Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CadastroDespesa.Api v1");

});

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
