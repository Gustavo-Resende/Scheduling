using Microsoft.EntityFrameworkCore;
using Scheduling.Data;
using Scheduling.Service.AgendamentoService;
using Scheduling.Service.BarbeiroService;
using Scheduling.Service.ClienteService;
using Scheduling.Service.EmpresaService;
using Scheduling.Service.ServicoService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBarbeiroInterface, BarbeiroService>();
builder.Services.AddScoped<IClienteInterface, ClienteService>();
builder.Services.AddScoped<IServicoInterface, ServicoService>();
builder.Services.AddScoped<IAgendamentoInterface, AgendamentoService>();
builder.Services.AddScoped<IEmpresaInterface, EmpresaService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
