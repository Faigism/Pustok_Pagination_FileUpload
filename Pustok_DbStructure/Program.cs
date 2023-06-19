using Microsoft.EntityFrameworkCore;
using Pustok_DbStructure.DAL;
using Pustok_DbStructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PustokDb_Contex>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<LayoutService>();
var app = builder.Build();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.UseStaticFiles();

app.Run();
