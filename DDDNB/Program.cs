using Application.AutoMap;
using AutoMapper;
using DDDNB.Extensions;
using DDDNB.IoC;
using Infrastruct.Data.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<StudyContext>(options =>
        options.UseSqlServer(builder.Configuration["SqlConnection:ConnectionString"]!));

builder.Services.RegisterServices();
builder.Services.AddAutoMapperSetup();

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
