using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MegaDeskWeb.Data;
using System;
using System.Linq;

namespace MegaDeskWeb.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskWebContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MegaDeskWebContext>>()))
            {
                // Look for any desktop surface materials
                if (context.DesktopSurfaceMaterial.Any())
                {
                    return;   // Table has been seeded
                }
                else
                {
                    context.DesktopSurfaceMaterial.AddRange(
                        new DesktopSurfaceMaterial
                        {
                            Name = "Pine",
                            Cost = 50
                        },
                        new DesktopSurfaceMaterial
                        {
                            Name = "Laminate",
                            Cost = 100
                        },
                        new DesktopSurfaceMaterial
                        {
                            Name = "Veneer",
                            Cost = 125
                        },
                        new DesktopSurfaceMaterial
                        {
                            Name = "Oak",
                            Cost = 200
                        },
                        new DesktopSurfaceMaterial
                        {
                            Name = "Rosewood",
                            Cost = 300
                        }
                    );
                }

                // Look for any rush order options
                if (context.RushOrderOption.Any())
                {
                    return;   // Table has been seeded
                }
                else
                {
                    context.RushOrderOption.AddRange(
                        new RushOrderOption
                        {
                            Option = "14 day",
                            CostSmall = 0,
                            CostMedium = 0,
                            CostLarge = 0
                        },
                        new RushOrderOption
                        {
                            Option = "7 day",
                            CostSmall = 30,
                            CostMedium = 35,
                            CostLarge = 40
                        },
                        new RushOrderOption
                        {
                            Option = "5 day",
                            CostSmall = 40,
                            CostMedium = 50,
                            CostLarge = 60
                        },
                        new RushOrderOption
                        {
                            Option = "3 day",
                            CostSmall = 60,
                            CostMedium = 70,
                            CostLarge = 80
                        }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}
