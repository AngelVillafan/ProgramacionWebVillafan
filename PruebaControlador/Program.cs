var builder = WebApplication.CreateBuilder(args);
//Activo MVC como patron de desarrollo
builder.Services.AddMvc();
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
    endpoints.MapDefaultControllerRoute());
// Controller = Home / Action = Index / Id?



app.Run();
