using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InterviewScheduler_2.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using InterviewScheduler_2.Services;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<InterviewScheduler_2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserRegContext") ?? throw new InvalidOperationException("Connection string 'UserRegContext' not found.")));

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CompanyCreateService>();
builder.Services.AddScoped<InterviewScheduler_2Context>();
builder.Services.AddSession(options => { options.IdleTimeout=TimeSpan.FromMinutes(20);
});

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
app.UseSession();
app.UseAuthorization();
app.UseEndpoints(endpoints => 
endpoints.MapControllerRoute(name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"));

app.MapRazorPages();

app.Run();
