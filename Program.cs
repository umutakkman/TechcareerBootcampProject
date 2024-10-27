using Microsoft.EntityFrameworkCore;
using TechcareerBootcampFest4Project.Data.Abstract;
using TechcareerBootcampFest4Project.Data.Concrete;
using TechcareerBootcampFest4Project.Data.Concrete.EfCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SiteContext>(options =>{
    options.UseSqlite(builder.Configuration["ConnectionStrings:Sql_connection"]);
});

builder.Services.AddScoped<ICarRepository, EfCarRepository>();

var app = builder.Build();

SeedData.TestVerileriniDoldur(app);

app.MapDefaultControllerRoute();

app.Run();
