using LMS.Infrastructure.Seeder;
using LMS.IoC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ServiceRegistation(builder.Configuration);


var app = builder.Build();

// Initialise and seed database

using var scope = app.Services.CreateScope();
var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
await initializer.InitialiseAsync();
await initializer.SeedAsync();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();

