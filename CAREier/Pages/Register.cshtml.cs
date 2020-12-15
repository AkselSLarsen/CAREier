using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAREier.Interfaces;
using CAREier.Models;
using CAREier.Models.profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages
{
    public class RegisterModel : PageModel
    {
        private UserTypes _userType;
        private string _name;
        private string _email;
        private string _username;
        private string _password;
        private User _user;
        private ICRUD<Buyer> _buyers;
        private ICRUD<Bringer> _bringers;
        private ICRUD<Store> _stores;


        public RegisterModel(IUser user, ICRUD<Buyer> buyers, ICRUD<Bringer> bringers, ICRUD<Store> stores) {
            User = (User)user;
            Buyers = buyers;
            Bringers = bringers;
            Stores = stores;
        }

        public UserTypes UserType { get { return _userType; } set { _userType = value; } }
        [BindProperty]
        public string Name { get { return _name; } set { _name = value; } }
        [BindProperty]
        public string Email { get { return _email; } set { _email = value; } }
        [BindProperty]
        public string Username { get { return _username; } set { _username = value; } }
        [BindProperty]
        public string Password { get { return _password; } set { _password = value; } }
        [BindProperty]
        public User User {
            get { return _user; }
            set { _user = value; }
        }
        public ICRUD<Buyer> Buyers {
            get { return _buyers; }
            set { _buyers = value; }
        }
        public ICRUD<Bringer> Bringers {
            get { return _bringers; }
            set { _bringers = value; }
        }

        public ICRUD<Store> Stores {
            get { return _stores; }
            set { _stores = value; }
        }

        public IActionResult OnGet(int id) {
            switch (id) {
                case 0: //UserType = Buyer
                    UserType = UserTypes.Buyer;
                    User.Profile = new Buyer();
                    return Page();
                case 1: //UserType = Bringer
                    UserType = UserTypes.Bringer;
                    User.Profile = new Bringer();
                    return Page();
                case 2: //UserType = Store
                    UserType = UserTypes.Store;
                    User.Profile = new Store();
                    return Page();
                default:
                    //This should not happen, please throw an exception here
                    return Page();
            }
        }

        public IActionResult OnPost() {
            object o = null;
            RouteData.Values.TryGetValue("id", out o);
            int i = int.Parse((string)o);
            UserType = (UserTypes)i;

            switch (UserType) {
                case UserTypes.Buyer: //UserType = Buyer
                    Buyer buyerTemp = null;
                    foreach (Buyer buy in _buyers.ReadAll()) {
                        if (Username == buy.Username) {
                            buyerTemp = buy;
                        }
                    }

                    if (buyerTemp != null) {
                        takenUsername();
                    } else {
                        return register(UserTypes.Buyer);
                    }
                    return Page();
                case UserTypes.Bringer: //UserType = Bringer
                    Bringer bringerTemp = null;
                    foreach (Bringer bri in _bringers.ReadAll()) {
                        if (Username == bri.Username) {
                            bringerTemp = bri;
                        }
                    }

                    if (bringerTemp != null) {
                        takenUsername();
                    } else {
                        return register(UserTypes.Bringer);
                    }
                    return Page();
                case UserTypes.Store: //UserType = Store
                    Store storeTemp = null;
                    foreach (Store sto in _stores.ReadAll()) {
                        if (Username == sto.Username) {
                            storeTemp = sto;
                        }
                    }

                    if (storeTemp != null) {
                        takenUsername();
                    } else {
                        return register(UserTypes.Store);
                    }
                    return Page();
                default:
                    //This should not happen, please throw an exception here
                    return Page();
            }
        }


        private IActionResult register(UserTypes type) {
            switch (type) {
                case UserTypes.Buyer:
                    User.Profile = new Buyer(Name, Email, "", "", Username, Password);
                    Buyers.Create((Buyer)User.Profile);
                    return RedirectToPage("ShopCart");
                case UserTypes.Bringer:
                    User.Profile = new Bringer(Name, Email, "", 0, new List<Order>(), Username, Password);
                    Bringers.Create((Bringer)User.Profile);
                    throw new NotImplementedException("We have no bringer pages yet");
                    return RedirectToPage("<Bringer Start Page Here>"); // send to start page for bringers
                case UserTypes.Store:
                    User.Profile = new Store(Name, Email, "", "", 0, Username, Password);
                    Stores.Create((Store)User.Profile);
                    return RedirectToPage("ProductCatalog");
                default:
                    //This should not happen, please throw an exception here
                    return Page();
            }
        }

        private void takenUsername() {

        }
    }
}
