using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Models.profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages.Profiles
{
    public class ProfileCreationModel : PageModel
    {
        private ICRUD<IUser> _newHandler;
        [BindProperty]
        public List<IUser> UserList { get; set; }

        [BindProperty]
        public IUser User { get; set; }

        public ProfileCreationModel(ICRUD<IUser> NewUser)
        {
            _newHandler = NewUser;
            UserList = new List<IUser>();
            foreach (var var in NewUser.ReadAll())
            {
                if (var is IUser)
                {
                    UserList.Add(var);
                }
            }
        }

        public IActionResult OnGet(int id)
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _newHandler.Create(User);
            return RedirectToPage("Login");
        }
    }

}
