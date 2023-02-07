using APImercaderias.MercaderiaMapper;
using APImercaderias.Modelos;
using APImercaderias.Repositorio.IRepositorio;
using APImercaderias.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsersContext>(opciones =>
{
    opciones.UseSqlServer("Data Source=DESKTOP-RDML62O\\SQLEXPRESS;Initial Catalog=MERCADERIAS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
});

builder.Services.AddScoped<IProductosRepositorio, ProductosRepositorio>();
builder.Services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();
builder.Services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();

builder.Services.AddAutoMapper(typeof(MercaderiaMapper));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));






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
