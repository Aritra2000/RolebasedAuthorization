using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using WebApplication1.Models;
using WebApplication1.Repository.DataAccessOfTables;






var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RolebasedContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("project_Conn")));

builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<IdataAccessTblRoles<TblRole>, DataAccessTblRoles>();
builder.Services.AddScoped<IDataAccessUserTblUser<TblUser>, DataAccessUserTblUser>();
builder.Services.AddScoped<IDataAccessTblUserRoles<TblUserRole>, DataAccessTblUserRoles>();


//authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/User/Login";

    options.Events = new CookieAuthenticationEvents
    {
        OnSignedIn = async context =>
        {
            var user = await _db.TblUsers.Where() 
        }
    }
});



//authorization policy

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("rolebasedatuthorization", policy => policy.RequireRole("admin"));
    
});


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

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
