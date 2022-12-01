using BitStore.Cache.Installers;
using BitStore.DbScaffolder;
using BitStore.Engine.Installers;
using BitStore.Metadata.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

RedisInstaller.Install(builder.Services, builder.Configuration);
RedLockInstaller.Install(builder.Services, builder.Configuration);
ClockInstaller.Install(builder.Services);
RepositoryInstaller.Install(builder.Services);
ServiceInstaller.Install(builder.Services);
builder.Services.AddDbContext<BitStoreContext>();
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

