using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RChat.BLL.Interfaces;
using RChat.BLL.Services;
using RChat.DAL.Context;
using RChat.DAL.Interfaces;
using RChat.DAL.Repositories;



namespace RChat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddTransient<IUserRepository, UserRepositoryTest>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddDbContext<RChatContext>(options =>
     options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                /*endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                */
                /*
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                */
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
        }
    }
}
