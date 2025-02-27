using BSD2_24.Data;
using Microsoft.EntityFrameworkCore;

namespace BSD2_24.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new BSD2_24Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<BSD2_24Context>>()))
            {

                if(context.Produit.Any())
                {
                    return;
                }

                context.Produit.AddRange(
                    new Produit { 
                        Nom = "Kebab",
                        DateDeSortie = DateTime.Parse("2025-02-12"),
                        Prix = 7.99M
                    },
                    new Produit { 
                        Nom = "pizza",
                        DateDeSortie = DateTime.Parse("2025-02-02"),
                        Prix = 14.99M
                    },
                    new Produit { 
                        Nom = "hot dog",
                        DateDeSortie = DateTime.Parse("2025-03-12"),
                        Prix = 5.99M
                    },
                    new Produit { 
                        Nom = "donuts",
                        DateDeSortie = DateTime.Parse("2025-01-12"),
                        Prix = 1.99M
                    }
                );

                context.SaveChanges();

            }
        }

    }
}
