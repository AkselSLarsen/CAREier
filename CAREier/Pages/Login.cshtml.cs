using CAREier.Interfaces;
using CAREier.Models;
using CAREier.Models.profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace CAREier.Pages {
    public class LoginModel : PageModel {
        private UserTypes _userType;
        private string _username;
        private string _password;
        private User _user;
        private ICRUD<Buyer> _buyers;
        private ICRUD<Bringer> _bringers;
        private ICRUD<Store> _stores;
        

        public LoginModel(IUser user, ICRUD<Buyer> buyers, ICRUD<Bringer> bringers, ICRUD<Store> stores)
        {
            _user = (User)user;
            Buyers = buyers;
            Bringers = bringers;
            Stores = stores;
        }

        public UserTypes UserType { get { return _userType; } set { _userType = value; } }
        [BindProperty]
        public string Username { get { return _username; } set { _username = value; } }
        [BindProperty]
        public string Password { get { return _password; } set { _password = value; } }
        public ICRUD<Buyer> Buyers
        {
            get { return _buyers; }
            set { _buyers = value; }
        }
        public ICRUD<Bringer> Bringers
        {
            get { return _bringers; }
            set { _bringers = value; }
        }
        public ICRUD<Store> Stores
        {
            get { return _stores; }
            set { _stores = value; }
        }
        public string Error { get; set; }

        public IActionResult OnGet(int id) {
            switch(id) {
                case 0: //UserType = Buyer
                    UserType = UserTypes.Buyer;
                    _user.Profile=new Buyer();
                    return Page();
                case 1: //UserType = Bringer
                    UserType = UserTypes.Bringer;
                    _user.Profile = new Bringer();
                    return Page();
                case 2: //UserType = Store
                    UserType = UserTypes.Store;
                    _user.Profile = new Store();
                    return Page();
                default:
                    //This should not happen, please throw an exception here
                    return Page();
            }
        }

        public IActionResult OnPost()
        {
            object o = null;
            RouteData.Values.TryGetValue("id", out o);
            int i = int.Parse((string)o);
            UserType = (UserTypes)i;

            switch (UserType)
            {
                case UserTypes.Buyer: //UserType = Buyer
                    Buyer buyerTemp = null;
                    foreach (Buyer buy in _buyers.ReadAll())
                    {
                        if (Username==buy.Username)
                        {
                            buyerTemp = buy;
                        }
                    }

                    if (buyerTemp == null) {
                        invalidUsername();
                    } else {
                        if (Password == buyerTemp.Password) {
                            return login(UserTypes.Buyer, buyerTemp);
                        } else {
                            invalidPassword();
                        }
                    }
                    return Page();
                case UserTypes.Bringer: //UserType = Bringer
                    Bringer bringerTemp = null;
                    foreach (Bringer bri in _bringers.ReadAll())
                    {
                        if (Username == bri.Username)
                        {
                            bringerTemp = bri;
                        }
                    }

                    if (bringerTemp == null)
                    {
                        invalidUsername();
                    } else {
                        if (Password == bringerTemp.Password) {
                            return login(UserTypes.Bringer, bringerTemp);
                        } else {
                            invalidPassword();
                        }
                    }
                    return Page();
                case UserTypes.Store: //UserType = Store
                    Store storeTemp = null;
                    foreach (Store sto in _stores.ReadAll())
                    {
                        if (Username == sto.Username)
                        {
                            storeTemp = sto;
                        }
                    }

                    if (storeTemp == null) {
                        invalidUsername();
                    } else {
                        if (Password == storeTemp.Password) {
                            return login(UserTypes.Store, storeTemp);
                        } else {
                            invalidPassword();
                        }
                    }
                    return Page();
                default:
                    //This should not happen, please throw an exception here
                    return Page();
            }
        }


        private IActionResult login(UserTypes type, IUser user) {
            _user.Profile = user;

            switch(type) {
                case UserTypes.Buyer:
                    return RedirectToPage("ShopCart");
                case UserTypes.Bringer:
                    throw new NotImplementedException("We have no bringer pages yet");
                    return RedirectToPage("<Bringer Start Page Here>"); // send to start page for bringers
                case UserTypes.Store:
                    return RedirectToPage("/Catalog/ProductCatalog");
                default:
                    //This should not happen, please throw an exception here
                    return Page();
            }
        }

        private void invalidUsername() {
            Error = "No user with that username exists";
        }

        private void invalidPassword() {
            Error = "Incorrect password";
        }

        public int UserTypeToInt() {
            switch (UserType) {
                case UserTypes.Buyer:
                    return 0;
                case UserTypes.Bringer:
                    return 1;
                case UserTypes.Store:
                    return 2;
                default:
                    //This should not happen, please throw an exception here
                    return -1;
            }
        }
    }
}