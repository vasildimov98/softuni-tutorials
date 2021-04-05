namespace AspNetCoreMVC
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Services;
    using Data;
    using Filters;
    using AspNetCoreMVC.ModelBinders;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews(options => 
            {
                options.ModelBinderProviders.Insert(0, new YearEntittyBinderProvider());
            });
            services.AddRazorPages();

            services.AddSingleton<ISimpleViewService, SimpleViewService>();
            services.AddSingleton<SampleActionFilter>();

            ////singleton register:
            //services.AddSingleton<IInstaceService, InstanceService>();

            ////scope register
            //services.AddScoped<IInstaceService, InstanceService>();

            //transient register
            services.AddTransient<IInstaceService, InstanceService>();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExeptionFilter));
                options.Filters.Add(typeof(ResourceFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseExceptionHandler("/Home/Error");
            //// app.UseStatusCodePagesWithRedirects("/Home/Error?status-code={0}");
            // app.UseStatusCodePagesWithReExecute("/Home/Error", "?status-code={0}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Fancy Table",
                    pattern: "/FancyTable/{year}/{month}/{day}",
                    defaults: new { controller = "Information", action = "Table" },
                    constraints: new { year = @"[0-9]{4}", month = @"[0-9]{2}", day = @"[0-9]{2}" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
