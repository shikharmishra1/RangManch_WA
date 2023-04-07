using ViteAPI.Models;
using ViteAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.Configure<RangmanchDBSettings>(builder.Configuration.GetSection("RangmanchDB"));
builder.Services.AddSingleton<RangmanchDBServices>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(ep=>{
    ep.MapDefaultControllerRoute();
});

app.UseCors();

app.UseSpa(config=>
{
    if(app.Environment.IsDevelopment())
    {
        config.UseProxyToSpaDevelopmentServer("http://localhost:5173/");
    }
});
app.Run();


