using Cennet_Emlak.Data.Abstract;
using Cennet_Emlak.Data.Concrete.EfCore;
using Cennet_Emlak.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EfEstateContext>(options => {
    var config = builder.Configuration;
    var connectionStrings = config.GetConnectionString("Default");
    options.UseMySql(connectionStrings,ServerVersion.AutoDetect(connectionStrings));
});
builder.Services.AddDbContext<IdentityContext>(options => {
    var config = builder.Configuration;
    var connectionStrings = config.GetConnectionString("Default");
    options.UseMySql(connectionStrings,ServerVersion.AutoDetect(connectionStrings));
});


builder.Services.AddScoped<IStartPageRepository,StartPageRepository>();
builder.Services.AddScoped<IPortfolioRepository,PortfolioRepository>();
builder.Services.AddScoped<IAboutRepository,AboutRepository>();
builder.Services.AddScoped<ISalesStateRepository,SalesStateRpository>();

builder.Services.AddScoped<IMessageRepository,MessageRepository>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<IdentityContext>();
builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequiredLength =6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

    options.User.RequireUniqueEmail = true;

});
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(5);
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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

IdentitySeedDate.IdentityTestUser(app);

app.Run();
