using Microsoft.AspNetCore.ResponseCompression;
using Scheduler.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
// Add services to the container.
builder.Services.AddSignalR(conf =>
{
    conf.MaximumReceiveMessageSize = null;
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
        .AllowAnyHeader()
        .AllowCredentials()
        .AllowAnyMethod();
    });
});
//builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.Use(async (context, next) =>
//{

//    if (context.Request.Method == "OPTIONS")
//    {

//        //允许处理跨域
//        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
//        context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
//        context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
//        await context.Response.CompleteAsync();
//    }
//    else
//    {

//        //允许处理跨域
//        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
//        context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
//        context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
//        await next();
//    }
//});
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors();

app.MapRazorPages();
app.MapControllers();
app.MapHub<ChatHub>("/chathub");

app.MapFallbackToFile("index.html");

app.Run();
