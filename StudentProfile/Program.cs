using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using STD.Data.Models;
using STD.Infrastructure.AutoMapper;
using STD.Infrastructure.Services;
using STD.Infrastructure.Services.Students;
using STD.Infrastructure.Services.Users;
using StudentProfile.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddIdentity<User, IdentityRole>(
    config => {
        config.SignIn.RequireConfirmedAccount = false;
        config.User.RequireUniqueEmail = true;
        config.Password.RequireDigit = false;
        config.Password.RequiredLength = 6;
        config.Password.RequireLowercase = false;
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireUppercase = false;
        config.SignIn.RequireConfirmedEmail = false;

    }

    )
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddDefaultUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
