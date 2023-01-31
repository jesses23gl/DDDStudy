using Application.AutoMap;
using AutoMapper;
using DDDNB.Extensions;
using DDDNB.IoC;
using Infrastruct.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<StudyContext>(options =>
        options.UseSqlServer(builder.Configuration["SqlConnection:ConnectionString"]!));
builder.Services.AddMemoryCache();
builder.Services.RegisterServices();
builder.Services.AddAutoMapperSetup();
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints => {

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();
