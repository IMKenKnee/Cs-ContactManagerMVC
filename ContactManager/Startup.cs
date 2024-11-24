//Kenny Hedlund
//Chapter 4 Contact 
//COP.4813

// Adding database interaction and data context
using Microsoft.EntityFrameworkCore;
using ContactManager.Data;

// Startup class configures services and the HTTP request pipeline for the application
public class Startup(IConfiguration configuration)
{
    // Configuration properties to access the app settings
    public IConfiguration Configuration { get; set; } = configuration;

    // Method gets called by runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Registers MVC controllers and views with service container
        services.AddControllersWithViews();

        // Enable dependency injection for DbContext objects
        // Configure SQL Server with connection stream -> links to appsettings.json
        services.AddDbContext<ContactManagerContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ContactManagerContext")));
    }

    // Method gets called by runtime. Use this method to configure HTTP requests pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Enables high detailed error pages during development
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Configures a generic error handler for production environments -> outside of scope of project
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Redirect to HTTPS for security practices
        app.UseHttpsRedirection();

        // Serves static files from wwwroot folder
        app.UseStaticFiles();

        // Initializing routing for the application
        app.UseRouting();

        // Enables authorization middleware -> not used
        app.UseAuthorization();

        // Sets the default route to use the Home controller and Index action
        // Optionally allows an "id" parameter
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}