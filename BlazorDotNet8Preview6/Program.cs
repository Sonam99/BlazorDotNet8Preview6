using BlazorDotNet8Preview6;
using BlazorDotNet8Preview6.Flows.ProductDetails;
using BlazorDotNet8Preview6.Services.APIs;
using BlazorDotNet8Preview6.States;
using Cypher.SeedWorks;
using BlazorDotNet8Preview6.Flows.ProductDetails.Pages.UpdateProductPage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7173") });
builder.Services.AddSingleton(sp => new APIHelper(sp.GetRequiredService<HttpClient>()));

builder.Services.AddSingleton<EventBus>();

builder.Services.AddTransient<IProductAPI, ProductAPI>();
builder.Services.AddTransient<IProductDeleteAPI, ProductAPI>();
builder.Services.AddTransient<IProductUpdateAPI, ProductAPI>();


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

app.MapRazorComponents<App>();

app.MapControllers();


app.Run();
