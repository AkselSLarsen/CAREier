using CAREier.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages {
    public class LoginModel : PageModel {

        public UserType UserType { get; set; }



        public void OnGet(int id) {
            switch(id) {
                case 0: //UserType = Buyer
                    UserType = UserType.Buyer;
                    break;
                case 1: //UserType = Bringer
                    UserType = UserType.Bringer;
                    break;
                case 2: //UserType = Store
                    UserType = UserType.Store;
                    break;
                default:

                    break;


            }
        }
    }
}
