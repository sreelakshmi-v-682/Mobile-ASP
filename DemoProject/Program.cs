using DemoProject.Data;
using DemoProject.Iservice;
using DemoProject.Models.Domain;
using DemoProject.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MvcDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("myconnection")));


builder.Services.AddControllersWithViews();

builder.Services.AddMvc();
builder.Services.AddDistributedMemoryCache();   
builder.Services.AddSession();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(1);
//});
//builder.Services.AddSession(o => { o.IdleTimeout=TimeSpan.FromSeconds(5); });
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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
