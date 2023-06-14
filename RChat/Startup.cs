using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RChat.BLL.Interfaces;
using RChat.BLL.Services;
using RChat.DAL.Interfaces;
using RChat.DAL.Repositories;



namespace RChat
{
    public class Startup
    {
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddTransient<IUserRepository, UserRepositoryTest>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IUserService, UserService>();
   
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
