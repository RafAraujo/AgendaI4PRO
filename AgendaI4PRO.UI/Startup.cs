using AgendaI4PRO.Application.Services;
using AgendaI4PRO.Application.Services.Base;
using AgendaI4PRO.Application.Services.Interfaces;
using AgendaI4PRO.Data.Repositories.Base;
using AgendaI4PRO.Data.Repositories.Interfaces;
using AgendaI4PRO.Domain.Models;
using AgendaI4PRO.UI.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AgendaI4PRO.UI
{
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
            services.AddControllersWithViews();

            ConfigureApplicationServices(services);
            ConfigureRepositories(services);
            ConfigureAutoMapper(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IBaseService<Contato>, BaseService<Contato>>();
            services.AddScoped<IBaseService<Email>, BaseService<Email>>();
            services.AddScoped<IBaseService<Telefone>, BaseService<Telefone>>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Contato>, BaseRepository<Contato>>();
            services.AddScoped<IBaseRepository<Email>, BaseRepository<Email>>();
            services.AddScoped<IBaseRepository<Telefone>, BaseRepository<Telefone>>();
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
