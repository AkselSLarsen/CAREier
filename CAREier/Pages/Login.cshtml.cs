using CAREier.Interfaces;
using CAREier.Models;
using CAREier.Models.profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            User = (User)user;
            Buyers = buyers;
            Bringers = bringers;
            Stores = stores;
        }

        public UserTypes UserType { get { return _userType; } set { _userType = value; } }
        public string Username { get { return _username; } set { _username = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        [BindProperty]
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
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

        public IActionResult OnGet(int id) {
            switch(id) {
                case 0: //UserType = Buyer
                    UserType = UserTypes.Buyer;
                    User.Profile=new Buyer();
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

        public void OnPost()
        {
            object o = null;
            RouteData.Values.TryGetValue("id", out o);
            int i = int.Parse((string)o);
            UserType = (UserTypes)i;

            switch (UserType)
            {
                case UserTypes.Buyer: //UserType = Buyer
                    Buyer buyerTemp = null;
                    foreach (var buy in _buyers.ReadAll())
                    {
                        if (Username==buy.Username)
                        {
                            buyerTemp = buy;
                        }


                    }

                    if (buyerTemp == null) {
                        //invalidUsername();
                    } else {
                        if (Password == buyerTemp.Password) {
                            //login(UserTypes.Bringer);
                        } else {
                            //invalidPassword();
                        }
                    }
                    break;
                case UserTypes.Bringer: //UserType = Bringer
                    Bringer bringerTemp = null;
                    foreach (var bri in _bringers.ReadAll())
                    {
                        if (Username == bri.Username)
                        {
                            bringerTemp = bri;
                        }


                    }

                    if (bringerTemp == null)
                    {
                        //invalidUsername();
                    } else {
                        if (Password == bringerTemp.Password) {
                            //login(UserTypes.Bringer);
                        } else {
                            //invalidPassword();
                        }
                    }
                    break;
                case UserTypes.Store: //UserType = Store
                    Store storeTemp = null;
                    foreach (var sto in _stores.ReadAll())
                    {
                        if (Username == sto.Username)
                        {
                            storeTemp = sto;
                        }


                    }

                    if (storeTemp == null) {
                        //invalidUsername();
                    } else {
                        if (Password == storeTemp.Password) {
                            //login(UserTypes.Bringer);
                        } else {
                            //invalidPassword();
                        }
                    }
                    break;
                default:
                    //This should not happen, please throw an exception here
                    break;
            }
        }
    }
}
