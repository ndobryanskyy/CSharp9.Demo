using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

await Task.Delay(TimeSpan.FromSeconds(10));

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.Configure(app =>
        {
            app.UseRouting();
            app.UseEndpoints(x =>
            {
                x.MapGet("/hello", async httpContext =>
                {
                    await httpContext.Response.WriteAsJsonAsync(new { Easy = true, Message = "Thanks Everyone" });
                });
            });
        });
    })
    .Build().Run();

return 1;
        
            
