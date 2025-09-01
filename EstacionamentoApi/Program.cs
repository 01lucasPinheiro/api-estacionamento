using EstacionamentoApi.Data;
using EstacionamentoApi.Routes;
using EstacionamentoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<VeiculoContext>();
builder.Services.AddScoped<VeiculoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.VeiculosRoutes();
app.UseHttpsRedirection();
app.Run();
