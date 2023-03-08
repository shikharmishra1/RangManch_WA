

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(ep=>{
    ep.MapDefaultControllerRoute();
});

app.UseSpa(config=>
{
    if(app.Environment.IsDevelopment())
    {
        config.UseProxyToSpaDevelopmentServer("http://localhost:5173/");
    }
});
app.Run();


