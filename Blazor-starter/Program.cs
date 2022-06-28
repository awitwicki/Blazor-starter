using Blazor_starter;
using Blazor_starter.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options
                 //.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")) Dont forget to create migration!
                   .UseInMemoryDatabase("InMemoryDb")
                   );


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddServerSideBlazor();


builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    // Automatic update database when exist new migration
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Migration
    if (context.Database.IsSqlServer())
    {
        context.Database.Migrate();
    }

    // Init roles
    {
        var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Create all roles
        foreach (var roleName in Consts.RolesList)
        {
            var roleExists = _roleManager.FindByNameAsync(roleName).Result;
            if (roleExists == null)
            {
                _roleManager.CreateAsync(new IdentityRole(roleName)).Wait();
            }
        }
    }
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();
