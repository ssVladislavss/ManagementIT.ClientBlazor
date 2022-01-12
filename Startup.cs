using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using UIBlazor.Data;
using UIBlazor.Services;


namespace UIBlazor
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
            services.AddRazorPages();
            services.AddScoped<TokenProvider>();
            services.AddHttpClient();

            services.AddTransient<DataManager>();

            #region  
            //services.AddAccessTokenManagement();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
                options.DefaultForbidScheme = "oidc";
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme
            , options =>
            {
                options.SlidingExpiration = true;

            }).AddJwtBearer("OpenIdConnect", options =>
            {
                options.ForwardSignOut = "https://localhost:2001/";
                options.ForwardSignIn = "https://localhost:2001/";
            })
              .AddOpenIdConnect("oidc", options =>
              {
                  options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                  options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
                  options.Authority = Configuration["OIDC:Authority"];

                  options.ClientId = Configuration["OIDC:ClientId"];
                  options.ClientSecret = Configuration["OIDC:ClientSecret"];

                  options.ResponseType = OpenIdConnectResponseType.Code;

                  options.Scope.Add("ManagementIT.WebHost.Swagger");
                  options.Scope.Add("ManagementIT.WebHost.Blazor");
                  options.Scope.Add("openid");
                  options.Scope.Add("profile");
                  options.Scope.Add("email");

                  options.SaveTokens = true;
                  options.RequireHttpsMetadata = true;

                  options.SignedOutRedirectUri = "https://localhost:2001/";
                  options.SignedOutCallbackPath = "/account/logout/";

                  options.GetClaimsFromUserInfoEndpoint = true;
                  options.ClaimActions.MapJsonKey(ClaimTypes.Role, ClaimTypes.Role);

                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      NameClaimType = JwtClaimTypes.Name,
                      RoleClaimType = JwtClaimTypes.Role
                  };

                  options.Events = new OpenIdConnectEvents
                  {
                      OnAccessDenied = context =>
                      {
                          context.HandleResponse();
                          context.Response.Redirect("/");
                          return Task.CompletedTask;
                      },
                      OnTokenValidated = context =>
                      {
                          context.Options.RefreshInterval = TimeSpan.FromHours(1);
                          return Task.CompletedTask;
                      }
                  };

              });

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = options.DefaultPolicy;
            });

            services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddMicrosoftIdentityUI();

            services.AddServerSideBlazor()
                .AddMicrosoftIdentityConsentHandler();

            #endregion

            services.AddHttpContextAccessor();

            // MudServices https://mudblazor.com/
            services.AddMudServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy(cookiePolicyOptions);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
