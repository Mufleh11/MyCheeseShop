using Microsoft.AspNetCore.Identity;
using MyCheeseShop.Context;
using MyCheeseShop.Model;
using DatabaseContext dbcontext


namespace MyCheeseShop.Context
{
    public class UserProvider
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;

        public UserProvider(DatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public User? GetUserByUsername(string? username)
        {
            return _context.User.FirstOrDefault(user => user.UserName == username);
        }
    }
}
