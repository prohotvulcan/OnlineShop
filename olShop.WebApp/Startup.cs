using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using olShop.Application.AutoMapper;
using olShop.Application.Interfaces;
using olShop.Application.Service;
using olShop.Data.EF;
using olShop.Data.EF.EFContext;
using olShop.Data.Entities;
using olShop.Infrastructure.Interfaces;
using olShop.WebApp.Authorization;
using olShop.WebApp.Extensions;
using olShop.WebApp.Helpers;
using olShop.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace olShop.WebApp
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
            // add connection string
            services.AddDbContext<OlShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("olShopSolutionDb"),
                options => options.MigrationsAssembly("olShop.Data.EF")));

            // add identity
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<OlShopDbContext>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();
            services.AddMinResponse();

            // configure identity
            services.Configure<IdentityOptions>(options =>
            {
                // pass settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // lockout setting
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // user setting
                options.User.RequireUniqueEmail = true;
            });

            // add recaptcha

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
            });

            services.AddImageResizer();
            services.AddAutoMapper(typeof(Startup));

            // add 2 factor authenticate

            // add application service
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            var mappingConfig = AutoMapperConfig.RegisterMappings();
            services.AddSingleton(mappingConfig.CreateMapper());
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 60
                    });
                options.CacheProfiles.Add("Never",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
            }).AddViewLocalization(
                    LanguageViewLocationExpanderFormat.Suffix,
                    opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization()
                .AddNewtonsoftJson(
                options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:3000")
                        .AllowCredentials();
                }));

            services.Configure<RequestLocalizationOptions>(
              opts =>
              {
                  var supportedCultures = new List<CultureInfo>
                  {
                        new CultureInfo("en-US"),
                        new CultureInfo("vi-VN")
                  };

                  opts.DefaultRequestCulture = new RequestCulture("en-US");
                  // Formatting numbers, dates, etc.
                  opts.SupportedCultures = supportedCultures;
                  // UI strings that we have localized.
                  opts.SupportedUICultures = supportedCultures;
              });

            #region DI configure
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IViewRenderService, ViewRenderService>();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepositoryBase<,>));

            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IPageService, PageService>();
            //services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();

            services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();
            #endregion

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/shop-{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseImageResizer();
            app.UseMinResponse();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });


        }
    }
}
