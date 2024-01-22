using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;
using Repository.Interfaces;
using TestMapIT.Workers;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
	.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var supportedCultures = new[]
	{
		new CultureInfo("en-US"),
		new CultureInfo("de-De"),
	};

	//options.DefaultRequestCulture = new RequestCulture("de-De");
	options.DefaultRequestCulture = new RequestCulture("en-US");
	options.SupportedCultures = supportedCultures;
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//SQL Server
builder.Services.AddDbContext<Context>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("contextDB")));

//Register Scope
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddTransient<IFileWorker, FileWorker>();

var app = builder.Build();

app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=ItemMaster}/{action=Index}/{id?}");

app.Run();
