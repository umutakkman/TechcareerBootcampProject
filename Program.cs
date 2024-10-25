using Microsoft.EntityFrameworkCore;
using TechcareerBootcampFest4Project.Data.Concrete.EfCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KiraSitesiContext>(options =>{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});

var app = builder.Build();

SeedData.TestVerileriniDoldur(app);

app.MapGet("/", () => "Hello World!");

app.Run();
