using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Экзамен.Models;

namespace Экзамен.Pages
{
    public class UsersModel : PageModel
    {
        AccountDbContext db;
        UserManager<User> userManager;
        RoleManager<IdentityRole> roleManager;

        public UsersModel(AccountDbContext db, 
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public List<User> Users { get; private set; }
        public void OnGet()
        {
            Users = db.Users.ToList();
        }
        public async Task OnPostDelete(string id)
        {

            User user = await userManager.FindByIdAsync(id);

            if (user != null && !(await userManager.GetRolesAsync(user)).Contains("admin"))
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                db.SaveChanges();
            }
            Users = db.Users.ToList();

        }
    }
}
