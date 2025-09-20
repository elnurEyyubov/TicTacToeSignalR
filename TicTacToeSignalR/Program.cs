using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.EntityFrameworkCore;
using TicTacToeSignalR.DataBaseAccess;
using TicTacToeSignalR.Helpers;
using TicTacToeSignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GameDBContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
});

builder.Services.AddIdentities();

builder.Services.AddSignalR();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/Account/Register";
        options.LoginPath = "/Account/Register";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.MapHub<GameHub>("/lobby");
app.MapHub<GameHub>("/game");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
