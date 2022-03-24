using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using csun_marketplace.services;
using csun_marketplace.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using csun_marketplace.Data;
using csun_marketplace.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddDbContextFactory<CSUNMarketplaceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<csun_marketplaceContext>();builder.Services.AddDbContext<csun_marketplaceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("csun_marketplaceContextConnection")));
builder.Services.AddScoped<ICSUNMarketplaceService, CSUNMarketplaceService>();
builder.Services.AddScoped<TokenProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
