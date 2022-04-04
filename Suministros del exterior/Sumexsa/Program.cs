using Microsoft.EntityFrameworkCore;
using Modelo.Modelo;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreHero.ToastNotification;

var builder = WebApplication.CreateBuilder(args);
//Declaramos la conexion a usar desde el archivo appsettings.json y agregamos el contexto si el contexto esta en el mismo proyecto
//Esta cadena de conexion se utiliza para las migraciones
var conexion = builder.Configuration.GetConnectionString("LocalConnection");
builder.Services.AddDbContext<DbContexto>(option => option.UseSqlServer(conexion));
//Agregamos la inicializacion del servicio de notificaciones y su configuracion standard
builder.Services.AddNotyf(conf =>
{
    conf.DurationInSeconds = 4;
    conf.IsDismissable = true;
    conf.Position = NotyfPosition.BottomRight;
    conf.HasRippleEffect= true;
});

// Add services to the container.
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

app.Run();
