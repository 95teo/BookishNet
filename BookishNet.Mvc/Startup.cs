using BookishNet.DataLayer;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Repositories;
using BookishNet.ServiceLayer.Interfaces;
using BookishNet.ServiceLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace BookishNet.Mvc
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            //_env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*if (!_env.IsDevelopment())
            {
                services.Configure<MvcOptions>(o => o.Filters.Add(new RequireHttpsAttribute()));
            }*/

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddDbContext<BookishNetContext>();
            // Add framework services.
            services.AddMvc();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("CorsPolicy"));
            });
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "BookishNet API", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("CorsPolicy");
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseCsp(options => options.DefaultSources(s => s.Self()));
            //app.UseHsts(h => h.MaxAge(days: 365));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var cookieOptions = new CookieAuthenticationOptions
            {
                AuthenticationScheme = "BookishNetCookie",
                LoginPath = new PathString("/account/login"),
                AccessDeniedPath = new PathString("/Account/Forbidden/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            };

            app.UseCookieAuthentication(cookieOptions);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookishNet API V1"); });
        }
    }
}