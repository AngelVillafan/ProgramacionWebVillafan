var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();  
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(x=>x.MapDefaultControllerRoute());

app.Run();
