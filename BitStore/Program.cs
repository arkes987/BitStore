using BitStore.Cache.Installers;
using BitStore.Engine.Installers;
using BitStore.Metadata.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

RedisInstaller.InstallServices(builder.Services, builder.Configuration);
RedLockInstaller.InstallServices(builder.Services, builder.Configuration);
RepositoryInstaller.InstallServices(builder.Services);
ServiceInstaller.InstallServices(builder.Services);
