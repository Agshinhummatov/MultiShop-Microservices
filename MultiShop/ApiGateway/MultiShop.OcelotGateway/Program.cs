using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceOcelot";
    opt.RequireHttpsMetadata = false;
});


//OcelotAuthenticationScheme bu hardan gelir ocelot.json icindeki burdan gelir   "AuthenticationOptions": {
//"AuthenticationProviderKey": "OcelotAuthenticationScheme",
//        "AllowedScopes": ["DiscountFullPermission"]
//      }

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();


builder.Services.AddOcelot(configuration);


var app = builder.Build();

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
