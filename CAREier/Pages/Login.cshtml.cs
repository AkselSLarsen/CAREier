using CAREier.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages {
    public class LoginModel : PageModel {



        public void OnGet(int id) {
            switch(id) {
                case 0: //UserType = Buyer
                    
                    break;
                case 1: //UserType = Bringer

                    break;
                case 2: //UserType = Store

                    break;


            }
        }
    }
}
