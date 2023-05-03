global using BlazorEcommerce.Shared;
using BlazorEcommerce.Server.BlazorEcommerce.Business;
using BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces;
using BlazorEcommerce.Server.BlazorEcommerce.Repository;
using BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// dependency injection
builder.Services.AddScoped<IProductManger, ProductManager>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IVariantRepository, VariantRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwaggerUI();
    app.UseSwagger();
}


else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
