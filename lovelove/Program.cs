using Microsoft.Extensions.DependencyInjection;
using FireSharp.Config;
using FireSharp;
using FireSharp.Interfaces;
using lovelove.Dbconfig;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

//Configura o FirebaseClient
builder.Services.AddSingleton<DbSettings>();
builder.Services.AddScoped<IFirebaseClient>(provider =>
{
    var settings = provider.GetRequiredService<DbSettings>();
    return new FirebaseClient(settings.Config);
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
