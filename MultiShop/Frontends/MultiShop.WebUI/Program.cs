using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Settings;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//builder.Services.AddHttpClient("InsecureHttpClient", client =>
//{
//    // Burada, HTTP istemcisi �zerinden SSL do?rulamas?n? devre d??? b?rak?yoruz
//    var handler = new HttpClientHandler
//    {
//        // Sertifika do?rulamas?n? devre d??? b?rak?yoruz
//        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
//    };

//    // ?stemciyi bu handler ile yap?land?r?yoruz
//    client = new HttpClient(handler);
//})
//.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
//{
//    // Sertifika do?rulamas?n? devre d??? b?rak?yoruz
//    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
//});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.LogoutPath = "/Login/LogOut/";
    opt.AccessDeniedPath = "/Pages/AccessDenied/";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "MultiShopJwt";
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.Cookie.Name = "MultiShopCookie";
    opt.SlidingExpiration = true;
});



builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddHttpClient<IIdentityService, IdentityService>();



builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
