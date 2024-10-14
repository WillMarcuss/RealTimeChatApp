using Microsoft.AspNetCore.SignalR; // Add this namespace
using RealTimeChatApp.Hubs; // Update this with the appropriate namespace for your ChatHub class

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR(); // Add this line to register SignalR services

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

// Map Razor Pages and SignalR Hub
app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub"); // Map the ChatHub

app.Run();
