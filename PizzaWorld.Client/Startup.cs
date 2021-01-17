using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.Client
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
            services.AddControllersWithViews();
            services.AddDbContext<PizzaWorldContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("sqlserver"), opts =>
                {
                    opts.EnableRetryOnFailure(2);
                });
            });
            services.AddScoped<PizzaWorldRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // app.UseHttpsRedirection();
            // app.UseStaticFiles();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // endpoints.MapControllerRoute(
                //     name: "default",
                //     pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        // static void PrebuiltPizza()
        // {
        //     PizzaWorldRepository _repo = new PizzaWorldRepository(_ctx);
        //     if(_repo.ReadPizzas().Count()==0)
        //     {
        //         Console.WriteLine("No Pizza found in DB! Adding pizzas");
        //         Crust c=_repo.ReadCrust().FirstOrDefault(x => x.Name.Contains("Hand Tossed"));
        //         Size s=_repo.ReadSize().FirstOrDefault(x => x.Name.Contains("Medium"));
        //         Topping t1 =_repo.ReadTopping().FirstOrDefault(x => x.Name.Contains("Premium Chicken"));
        //         Topping t2 =_repo.ReadTopping().FirstOrDefault(x => x.Name.Contains("Cheese"));
        //         List<Topping> t = new List<Topping>{t1,t2};
        //         PrebuiltPizza meatpizza1 = new PrebuiltPizza(c,s,t);
        //         meatpizza1.Name = "Medium Hand Tossed Meat Pizza";
        //         _repo.Save(meatpizza1);

                
        //         c=_repo.ReadCrust().FirstOrDefault(x => x.Name.Contains("Cheese-Stuffed"));
        //         s=_repo.ReadSize().FirstOrDefault(x => x.Name.Contains("Large"));
        //         t1 =_repo.ReadTopping().FirstOrDefault(x => x.Name.Contains("Premium Chicken"));
        //         t2 =_repo.ReadTopping().FirstOrDefault(x => x.Name.Contains("Cheese"));
        //         Topping t3 = _repo.ReadTopping().FirstOrDefault(x => x.Name.Contains("Pulled Pork"));
        //         Topping t4 = _repo.ReadTopping().FirstOrDefault(x => x.Name.Contains("Mushroom"));
        //         t = new List<Topping>{t1,t2,t3,t4};
        //         PrebuiltPizza meatpizza2 = new PrebuiltPizza(c,s,t);
        //         meatpizza2.Name = "Large Cheese Stuffed King of Pizza";
        //         _repo.Save(meatpizza2);

        //         c=_repo.ReadCrust().FirstOrDefault(x => x.Name.Contains("Thin"));
        //         s=_repo.ReadSize().FirstOrDefault(x => x.Name.Contains("Small"));
        //         t1 =_repo.ReadTopping().FirstOrDefault(x => x.Name.Contains("Cheese"));
        //         t = new List<Topping>{t1};
        //         PrebuiltPizza cheesepizza = new PrebuiltPizza(c,s,t);
        //         cheesepizza.Name = "Small thin crust cheese pizza";
        //         _repo.Save(cheesepizza);
        //     }
        //     else
        //     {
        //         Console.WriteLine("All set! Welcome to the Pizza Ordering App!");
        //     }
        // }
              
    }
}
