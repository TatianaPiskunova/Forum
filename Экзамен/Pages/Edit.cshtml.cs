using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Экзамен.Models;

namespace Экзамен.Pages
{
    public class EditModel : PageModel
    {
        UserManager<User> userManager;

        public EditModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string Lastname { get; set; }
        [BindProperty]
        public string UserName { get; set; }


        public async Task OnGetAsync(string id)
        {


            User user = await userManager.FindByIdAsync(id);


            Id = id;
            Lastname = user.Lastname;
            UserName = user.UserName;

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(Id);
                if (user != null)
                {

                    user.UserName = UserName;
                    user.Lastname = Lastname;
                }
                var result = await userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }



            return RedirectToPage("Users", userManager.Users);
        }

    }
}
