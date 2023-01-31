using EF_MySQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// aqui vamos a inyectar la dependencia
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseMySQL(connectionString: builder.Configuration.GetConnectionString("MyConnection"));
});

// aqui vamos a inyectar la dependencia

builder.Services.AddControllers();

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

