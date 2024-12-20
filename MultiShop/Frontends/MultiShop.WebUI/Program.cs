var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();


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

builder.Services.AddControllersWithViews();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
