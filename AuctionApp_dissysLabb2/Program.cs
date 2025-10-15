using AuctionApp_dissysLabb2.Areas.Identity.Data;
using AuctionApp_dissysLabb2.Core.Interfaces;
using AuctionApp_dissysLabb2.Infrastructure;
using AuctionApp_dissysLabb2.Persistence;
using Microsoft.EntityFrameworkCore;
using AuctionApp_dissysLabb2.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAuctionService, MockAuctionService>();
builder.Services.AddScoped<IBidService, MockBidService>();
var cs = builder.Configuration.GetConnectionString("AuctionDb");
builder.Services.AddDbContext<AuctionDbContext>(
    options => options.UseMySQL(cs));

builder.Services.AddDbContext<AuctionApp_dissysLabb2Context>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("IdentityDB")));

// AuctionApp_dissysLabb2Context = AppIDentityContext i tutorial 1 del 3
builder.Services.AddDefaultIdentity<AppIdentityUser>(options => 
    options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuctionApp_dissysLabb2Context>();

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

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();