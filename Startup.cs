using Article_Management_Backend.Commands;
using Article_Management_Backend.DataContext;
using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using Article_Management_Backend.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Article_Management_Backend
{
    public class Startup
    {
        public IConfiguration Configuration
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<ArticleDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Local")));

            // Add services to the container.
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddTransient<IValidator<SaveArticleCommand>, SaveArticleCommandValidator>();
            services.AddTransient<IValidator<UpdateArticleCommand>, UpdatedArticleCommandValidator>();
            services.AddTransient<IValidator<DeleteArticleCommand>, DeleteArticleCommandValidator>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IDictionaryRepository, DictionaryRepository>();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {


            app.UseCors("AllowOrigin");

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()
            );

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();


        }
    }
}