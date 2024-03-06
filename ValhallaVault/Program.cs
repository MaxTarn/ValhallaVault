using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ValhallaVault.Components;
using ValhallaVault.Components.Account;
using ValhallaVault.Data;
using ValhallaVault.Data.Repositories;


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

            builder.Services.AddControllers();

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

            var DbString = builder.Configuration.GetConnectionString("BaseConnection") ?? throw new InvalidOperationException("Connection string 'BaseConnection' not found.");
            builder.Services.AddDbContext<ProgramDbContext>(options =>
                options.UseSqlServer(DbString));

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()  //H�R L�GGER VI TILL DENNA RADEN 
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            builder.Services.AddControllers();

            //Dependency injection
            builder.Services.AddScoped<AnswerRepo>();
            builder.Services.AddScoped<CategoryRepo>();
            builder.Services.AddScoped<QuestionRepo>();
            builder.Services.AddScoped<SegmentRepo>();
            builder.Services.AddScoped<SubcategoryRepo>();


            ////skapa users och roller som ska finnas med fr�n start

            //using (ServiceProvider sp = builder.Services.BuildServiceProvider())
            //{
            //    var context = sp.GetRequiredService<ApplicationDbContext>(); //plocka ut dessa ut v�r dependency injection container
            //    var signInManager = sp.GetRequiredService<SignInManager<ApplicationUser>>();
            //    var roleManagaer = sp.GetRequiredService<RoleManager<IdentityRole>>();

            //    context.Database.Migrate(); //har vi inte skapat databasen s� g�rs det nu

            //    ApplicationUser newAdmin = new()
            //    {
            //        UserName = "admin",
            //        Email = "adminuser@mail.com",
            //        EmailConfirmed = true
            //    };

            //    var admin = signInManager.UserManager.FindByNameAsync(newAdmin.UserName).GetAwaiter().GetResult();
            //    if (admin == null)
            //    {
            //        //skapa en ny user
            //        signInManager.UserManager.CreateAsync(newAdmin, "Password1234!").GetAwaiter().GetResult();



            //        //kolla om adminrollen existerar
            //        bool adminRoleExists = roleManagaer.RoleExistsAsync("Admin").GetAwaiter().GetResult();
            //        if (!adminRoleExists)
            //        {
            //            //edminrollen existerar ej, skapa den!

            //            IdentityRole adminRole = new()
            //            {
            //                Name = "Admin",
            //            };
            //            roleManagaer.CreateAsync(adminRole).GetAwaiter().GetResult();
            //        }
            //        //tilldela adminrollen till den nya anv�ndaren
            //        signInManager.UserManager.AddToRoleAsync(newAdmin, "Admin").GetAwaiter().GetResult();

            //    ApplicationUser newUser = new()
            //    {
            //        UserName = "user",
            //        Email = "user@mail.com",
            //        EmailConfirmed = true
            //    };

            //    var user = signInManager.UserManager.FindByNameAsync(newUser.UserName).GetAwaiter().GetResult();
            //    if (user == null)
            //    {
            //        //skapa en ny user
            //        signInManager.UserManager.CreateAsync(newUser, "Password1234!").GetAwaiter().GetResult();
            //    }
            //    }













            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                var context = sp.GetRequiredService<ApplicationDbContext>(); //plocka ut dessa ut v�r dependency injection container
                var signInManager = sp.GetRequiredService<SignInManager<ApplicationUser>>();
                var roleManagaer = sp.GetRequiredService<RoleManager<IdentityRole>>();

                context.Database.Migrate(); //har vi inte skapat databasen s� g�rs det nu

                ApplicationUser newAdmin = new()
                {
                    UserName = "admin",
                    Email = "adminuser@mail.com",
                    EmailConfirmed = true
                };

                var admin = signInManager.UserManager.FindByNameAsync(newAdmin.UserName).GetAwaiter().GetResult();
                if (admin == null)
                {
                    //skapa en ny user
                    signInManager.UserManager.CreateAsync(newAdmin, "Password1234!").GetAwaiter().GetResult();



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
                    //tilldela adminrollen till den nya anv�ndaren
                    signInManager.UserManager.AddToRoleAsync(newAdmin, "Admin").GetAwaiter().GetResult();
                }

                ApplicationUser newUser = new()
                {
                    UserName = "user",
                    Email = "user@mail.com",
                    EmailConfirmed = true
                };

                var user = signInManager.UserManager.FindByNameAsync(newUser.UserName).GetAwaiter().GetResult();
                if (user == null)
                {
                    //skapa en ny user
                    signInManager.UserManager.CreateAsync(newUser, "Password1234!").GetAwaiter().GetResult();
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

                app.MapControllers();

                // Add additional endpoints required by the Identity /Account Razor components.
                app.MapAdditionalIdentityEndpoints();

                app.Run();
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