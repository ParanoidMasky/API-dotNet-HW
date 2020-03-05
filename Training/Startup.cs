using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;
using Training.API.Contracts;
using Training.API.Contracts.Services;
using Training.API.Operations.Users;
using Training.API.Operations.Products;
using Training.Data;
using Training.Data.Repositories;
using Training.Exceptions;
using Training.Services;
using Training.API.Operations.Orders;

namespace Training
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
            var connection = Configuration.GetConnectionString("sqlserver");
            services.AddDbContext<StoreContext>
                (options => options.UseSqlServer(connection));
            services.AddTransient<ErrorHandlingMiddleware>();
            ConfigureAuthentication(services);
            ConfigureOperations(services);
            ConfigureRepositories(services);
            ConfigureInfrastructureServices(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);   
        }

        public void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "bearer";
            }).AddJwtBearer("bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["serverSigningPassword"])),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero //the default for this setting is 5 minutes
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        //execute all repo operations
        public void ConfigureOperations(IServiceCollection services)
        {
            services.AddTransient<GetAll>();
            services.AddTransient<SignUp>();
            services.AddTransient<SignIn>();
            services.AddTransient<GetAllProducts>();
            services.AddTransient<GetAllOrders>();
            services.AddTransient<AddOrder>();
            services.AddTransient<GetOrdersByUser>();
        }

        public void ConfigureInfrastructureServices(IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenService, TokenService>();
        }


        //configure repos, initialize
        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IUsersRepository,UsersRepository>();
            services.AddTransient<IProductsRepository,ProductsRepository>();
            services.AddTransient<IOrdersRepository,OrdersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseErrorHandlingMiddleware();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
