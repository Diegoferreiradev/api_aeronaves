using APICiaAerea.Contexts;
using APICiaAerea.Middlewares;
using APICiaAerea.Services;
using APICiaAerea.Validators.Aeronave;
using APICiaAerea.Validators.Cancelamento;
using APICiaAerea.Validators.Piloto;
using APICiaAerea.Validators.Voo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CiaAreaContext>();
builder.Services.AddTransient<AeronaveService>();
builder.Services.AddTransient<PilotoService>();
builder.Services.AddTransient<VooService>();
builder.Services.AddTransient<AdicionarAeronaveValidator>();
builder.Services.AddTransient<AtualizarAeronaveValidator>();
builder.Services.AddTransient<ExcluirAeronaveValidator>();
builder.Services.AddTransient<AdicionarPilotoValidator>();
builder.Services.AddTransient<AtualizarPilotoValidator>();
builder.Services.AddTransient<ExcluirPilotoValidator>();
builder.Services.AddTransient<AdicionarVooValidator>();
builder.Services.AddTransient<AtualizarVooValidator>();
builder.Services.AddTransient<ExcluirVooValidator>();
builder.Services.AddTransient<CancelarVooValidator>();



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

app.UseMiddleware<ValidationExceptionHandlerMiddleware>();

app.Run();
