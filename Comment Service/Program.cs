using Comment_Service.Data;
using Comment_Service.Extensions;
using Comment_Service.Services;
using Comment_Service.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddAuth();
builder.AddSwaggenGenExtension();

//config context
builder.Services.AddDbContext<CommentDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//config http client
builder.Services.AddHttpClient("Posts",c=>c.BaseAddress=new Uri(builder.Configuration.GetValue<string>("ServiceURL:postService")));
builder.Services.AddScoped<IPost, PostService>();
builder.Services.AddScoped<IComment, CommentServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
