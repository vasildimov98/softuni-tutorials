namespace MiddlewareDemo
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;
    using static MiddlewareDemo.Startup;

    public static class CustomMiddlewareExtention
    {
        public static IApplicationBuilder UseCustom(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/home", app =>
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello from home page!");
                });
            });

            app.UseCustom();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("2");
                await next();
                await context.Response.WriteAsync("5");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("3");
                await next();
                await context.Response.WriteAsync("4");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello, World!");
            });
        }

        public class CustomMiddleware
        {
            private readonly RequestDelegate next;

            public CustomMiddleware(RequestDelegate next)
            {
                this.next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                await context.Response.WriteAsync("1");

                if (DateTime.UtcNow.Second % 2 == 0)
                    await this.next(context);

                await context.Response.WriteAsync("6");
            }
        }
    }
}
