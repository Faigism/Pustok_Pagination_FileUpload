using Microsoft.EntityFrameworkCore;
using Pustok_DbStructure.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PustokDb_Contex>(opt =>
{
    opt.UseSqlServer("Server=ASUSPROART\\SQLEXPRESS;Database=PustokDb_Structure;Integrated Security=True");
});
var app = builder.Build();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.UseStaticFiles();

app.Run();
