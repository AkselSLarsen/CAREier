using CAREier.Models;
using CAREier.Models.profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages {
    public class LoginModel : PageModel {

        public UserTypes UserType { get; set; }

        public LoginModel() {

        }

        public IActionResult OnGet(int id) {
            switch(id) {
                case 0: //UserType = Buyer
                    UserType = UserTypes.Buyer;
                    return Page();
                case 1: //UserType = Bringer
                    UserType = UserTypes.Bringer;
                    return Page();
                case 2: //UserType = Store
                    UserType = UserTypes.Store;
                    return Page();
                default:
                    return Page();
            }
        }
    }
}
