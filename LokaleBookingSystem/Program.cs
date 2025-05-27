using LokaleBookingSystem.Models;
using LokaleBookingSystem.Services;
using LokaleBookingSystemHej.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddRazorPages(options =>
{
    // Angiv hvilke foldere login giver adgang til
    options.Conventions.AuthorizeFolder("/Elev");
    options.Conventions.AuthorizeFolder("/Lærer");
    options.Conventions.AuthorizeFolder("/Admin");
});

//builder.Services.AddSingleton<IBookingRegler, BookingRegler>();
//builder.Services.AddSingleton<IBookingService, BookingService>();
builder.Services.AddSingleton<IBrugerService, BrugerService>();
builder.Services.AddSingleton<ILokaleRepo, LokaleRepo>();



builder.Services.AddSession();
//Add Authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Set path to your login page
        options.AccessDeniedPath = "/AccessDenied"; // Optional, for when access is denied

    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//builder.Services.AddSession();
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
