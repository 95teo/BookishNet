using BookishNet.DataLayer;
using BookishNet.RepositoryLayer.Interfaces;
using BookishNet.RepositoryLayer.Repositories;
using BookishNet.ServiceLayer.Interfaces;
using BookishNet.ServiceLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookishNet.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
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
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();
        }
    }
}