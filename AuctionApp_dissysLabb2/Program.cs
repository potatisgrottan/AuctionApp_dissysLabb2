using AuctionApp_dissysLabb2.Core.Interfaces;
using AuctionApp_dissysLabb2.Infrastructure;
using AuctionApp_dissysLabb2.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAuctionService, MockAuctionService>();

builder.Services.AddDbContext<ProjectDbContext>(
    options => options.UseMySQL(
    builder.Configuration.GetConnectionString("ProjectDBConnection")
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();