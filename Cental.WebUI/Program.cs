using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.BusinessLayer.Extensions;
using Cental.BusinessLayer.Validators;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CentalContext>();
builder.Services.AddIdentity<AppUser, AppRole>(
    cfg =>
    {
        cfg.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<CentalContext>()
    .AddErrorDescriber<CustomErrorDescriber>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddServiceRegistration();

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<BrandValidator>();

builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(new AuthorizeFilter());
}).AddRazorRuntimeCompilation();
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Login/Index";
    config.LogoutPath = "/Login/Logout";
    config.AccessDeniedPath = "/ErrorPage/AccesDenied";
});
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
app.UseStatusCodePagesWithRedirects("/ErrorPage/NotFound404");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
