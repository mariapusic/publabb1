using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using publabb1.Server.Data;
using publabb1.Server.Data.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CountryContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("defaultConnectionstring"))
    .UseCamelCaseNamingConvention());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.MapGet("countries", (CountryContext context) =>
{
    return context.CountryTable.ToList();
});
app.MapGet("cities", (CountryContext context) =>
{
    return context.CityTable.ToList();
});
app.MapGet("country/{Id:int}", (CountryContext context, int Id) =>
{
    return context.CityTable.Where(c => c.CountryId == Id);
});
app.MapPost("countries", (CountryContext context, CountryModel countryModel) =>
{
    context.CountryTable.Add(countryModel);
    context.SaveChanges();
});
app.MapPost("cities", (CountryContext context, CityModel cityModel) =>
{
    context.CityTable.Add(cityModel);
    context.SaveChanges();
});

app.Run();
