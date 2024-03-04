using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ValhallaVault.Components;
using ValhallaVault.Components.Account;
using ValhallaVault.Data;

namespace ValhallaVault
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()  //HÄR LÄGGER VI TILL DENNA RADEN 
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();





            //skapa users och roller som ska finnas med från start

            using (ServiceProvider sp = builder.Services.BuildServiceProvider())
            {
                var context = sp.GetRequiredService<ApplicationDbContext>(); //plocka ut dessa ut vår dependency injection container
                var signInManager = sp.GetRequiredService<SignInManager<ApplicationUser>>();
                var roleManagaer = sp.GetRequiredService<RoleManager<IdentityRole>>();

                context.Database.Migrate(); //har vi inte skapat databasen så görs det nu

                ApplicationUser newUser = new()
                {
                    UserName = "admin",
                    Email = "adminuser@mail.com",
                    EmailConfirmed = true
                };
                var user = signInManager.UserManager.FindByEmailAsync(newUser.Email).GetAwaiter().GetResult(); //vi vill att det ska köras synkront, därvav de två sista metoderna
                if (user == null)
                {
                    //skapa en ny user
                    signInManager.UserManager.CreateAsync(newUser, "Password1234!").GetAwaiter().GetResult();



                    //kolla om adminrollen existerar
                    bool adminRoleExists = roleManagaer.RoleExistsAsync("Admin").GetAwaiter().GetResult();
                    if (!adminRoleExists)
                    {
                        //edminrollen existerar ej, skapa den!

                        IdentityRole adminRole = new()
                        {
                            Name = "Admin",
                        };
                        roleManagaer.CreateAsync(adminRole).GetAwaiter().GetResult();
                    }
                    //tilldela adminrollen till den nya användaren
                    signInManager.UserManager.AddToRoleAsync(newUser, "Admin").GetAwaiter().GetResult();
                }
            }











            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}
