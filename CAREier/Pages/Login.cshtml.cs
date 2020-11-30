using CAREier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages {
    public class LoginModel : PageModel {

        public UserType UserType { get; set; }

        public LoginModel() {

        }

        public IActionResult OnGet(int id) {
            switch(id) {
                case 0: //UserType = Buyer
                    UserType = UserType.Buyer;
                    return Page();
                case 1: //UserType = Bringer
                    UserType = UserType.Bringer;
                    return Page();
                case 2: //UserType = Store
                    UserType = UserType.Store;
                    return Page();
                default:
                    return Page();
            }
        }
    }
}
