using Assignment.ActionFIlters;
using Assignment.DbContexts;
using Assignment.Extensions;
using Assignment.SeedData;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilterAttribute());
});
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = configuration.GetConnectionString("MongoConnection"); // Update to your MongoDB connection string
    return new MongoClient(connectionString);
});
builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var databaseName = "UserDb"; 
    return client.GetDatabase(databaseName);
}); 
var connectionStringRDBMS = builder.Configuration.GetConnectionString("SqlServerConnection");
var assemblyName = Assembly.GetExecutingAssembly().FullName;
builder.Services.AddDbContext<RDBMSDbContext>(options =>
      options.UseSqlServer(connectionStringRDBMS, m => m.MigrationsAssembly(assemblyName)));
builder.Services.AddServices();
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


using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<MongoDbSeeder>();
    await seeder.SeedAsync();
}

app.Run();
