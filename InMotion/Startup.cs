using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InMotion.Areas.Identity;
using InMotion.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using InMotion.Services;
using InMotion.Data.Models;
using InMotion.Data.Access;
using System.Net.Http;

namespace InMotion {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration=configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services) {
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			
			services.AddDefaultIdentity<IdentityUser>(options => { 
					options.SignIn.RequireConfirmedAccount=true;
					options.Password.RequiredLength = 3;
					options.Password.RequireDigit = false;
					options.Password.RequireNonAlphanumeric=false;
					options.Password.RequireLowercase=false;
					options.Password.RequireUppercase=false;
					options.Password.RequireDigit=false;
					options.User.RequireUniqueEmail=true;
			})
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddTransient<IEmailSender, EmailSender>();
			services.Configure<AuthMessageSenderOptions>(Configuration);
			
			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
			services.AddScoped<IMessageService, MessageService>();
			services.AddScoped<INotificationService, NotificationService>();
			services.AddScoped<IMovieService, MovieService>();

			services.AddSingleton<HttpClient>();
			services.AddScoped<IMessagesRepository,MessagesRepository>();
			services.AddScoped<IMoviesRepository, MoviesRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			} else {
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
				endpoints.MapBlazorHub();
				endpoints.MapRazorPages();
				endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
}
