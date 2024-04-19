using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{


    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }




        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "cheese123";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "Ad12 MIN"
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");

                if (!_context.Cheeses.Any())
                {
                    var cheeses = GetCheeses();
                    _context.Cheeses.AddRange(cheeses);
                    await _context!.SaveChangesAsync();
                }

                private List<Cheese> GetCheeses()
                {
                    return [

                        new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Medium", Price = 5.99m },
                        new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and mild", Strength = "Mild", Price = 7.49m },
                        new Cheese { Name = "Gouda", Type = "Semi-hard", Description = "Smooth and nutty", Strength = "Medium", Price = 6.99m },
                        new Cheese { Name = "Blue Cheese", Type = "Soft", Description = "Bold and tangy with blue veins", Strength = "Strong", Price = 8.99m },
                        new Cheese { Name = "Camembert", Type = "Soft", Description = "Creamy and earthy", Strength = "Medium", Price = 9.99m },
                        new Cheese { Name = "Parmesan", Type = "Hard", Description = "Salty and granular", Strength = "Strong", Price = 10.99m },
                        new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and elastic", Strength = "Mild", Price = 6.49m },
                        new Cheese { Name = "Gruyere", Type = "Semi-hard", Description = "Rich and nutty", Strength = "Medium", Price = 11.49m },
                        new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly", Strength = "Medium", Price = 8.49m },
                        new Cheese { Name = "Roquefort", Type = "Blue", Description = "Sharp and tangy with blue veins", Strength = "Strong", Price = 12.99m },
                        new Cheese { Name = "Havarti", Type = "Semi-soft", Description = "Buttery and mild", Strength = "Mild", Price = 9.49m },
                        new Cheese { Name = "Provolone", Type = "Semi-hard", Description = "Sharp and smoky", Strength = "Medium", Price = 7.99m },
                        new Cheese { Name = "Emmental", Type = "Hard", Description = "Swiss cheese with large holes", Strength = "Medium", Price = 10.49m },
                        new Cheese { Name = "Manchego", Type = "Hard", Description = "Spanish sheep's milk cheese", Strength = "Medium", Price = 13.49m },
                        new Cheese { Name = "Edam", Type = "Semi-hard", Description = "Mild and nutty", Strength = "Medium", Price = 8.99m },
                        new Cheese { Name = "Fontina", Type = "Semi-soft", Description = "Buttery and mild", Strength = "Medium", Price = 11.99m },
                        new Cheese { Name = "Monterey Jack", Type = "Semi-hard", Description = "Mild and creamy", Strength = "Mild", Price = 7.49m },
                        new Cheese { Name = "Colby", Type = "Semi-hard", Description = "Mild and creamy", Strength = "Mild", Price = 6.99m },
                        new Cheese { Name = "Gorgonzola", Type = "Blue", Description = "Sharp and tangy with blue veins", Strength = "Strong", Price = 9.99m },
                        new Cheese { Name = "Stilton", Type = "Blue", Description = "Strong and creamy with blue veins", Strength = "Strong", Price = 14.49m }
                        ];

                }

            }
        }
    }
}

        

    
  
    




