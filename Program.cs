using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProiectBun.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

//Add services to the container.

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Utilaje");
    options.Conventions.AllowAnonymousToPage("/Acasa/Index");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
} 
);
builder.Services.AddDbContext<ProiectBunContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectBunContext") ?? throw new InvalidOperationException("Connection string 'ProiectBunContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();
    
builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectBunContext") ?? throw new InvalidOperationException("Connectionstring 'ProiectBunContext' not found.")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
