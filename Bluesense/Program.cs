using Bluesense.Application.Interfaces;
using Bluesense.Application.Services;
using Bluesense.Infrastructure.Persistence;
using Bluesense.Infrastructure.Repositories;
using Bluesense.Infrastructure.Cache;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL Kısmım
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

// Redis Tarafı bitti
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));
builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();

// Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Application Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IMessageService, MessageService>();

// Controllers & SignalR
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSignalR();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bluesense API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapHub<Bluesense.Hubs.ChatHub>("/chathub");

app.Run();
