using MultiShop.Comment.Context;
using MultiShop.Comment.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CommentContext>();
// Add services to the container.
builder.Services.AddScoped<ICommentService, CommentService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
