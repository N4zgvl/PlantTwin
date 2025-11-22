using PlantTwin.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Inyección de dependencias
builder.Services.AddSingleton<MachineSimulatorService>();
builder.Services.AddSingleton<NotifierService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Plant}/{action=Index}/{id?}");
app.Run();