using CAREier.Interfaces;
using CAREier.Models;
using CAREier.Models.profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages {
    public class LoginModel : PageModel {

        public UserTypes UserType { get; set; }
        private User _user;
        private ICRUD<Buyer> _buyers;
        private ICRUD<Bringer> _bringers;
        private ICRUD<Store> _stores;

        public LoginModel(IUser user)
        {
            User = (User)user;
        }

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
                    return Page();
            }
        }

        public void OnPost()
        {
            string password;
            string username;
            switch (UserType)
            {
                case UserTypes.Buyer: //UserType = Buyer
                    password = User.Password;
                    username = User.Username;
                    Buyer buyerTemp = null;
                    foreach (var buy in _buyers.ReadAll())
                    {
                        if (username==buy.Username)
                        {
                            buyerTemp = buy;
                        }


                    }

                    if (buyerTemp == null)
                    {
                        //invalidUsername();
                    }

                    if (password == buyerTemp.Password)
                    {
                        //login(UserTypes.Buyer);
                    }
                    else
                    {
                        //invalidPassword();
                    }
                    break;
                case UserTypes.Bringer: //UserType = Bringer
                    password = User.Password;
                    username = User.Username;
                    Bringer bringerTemp = null;
                    foreach (var bri in _bringers.ReadAll())
                    {
                        if (username == bri.Username)
                        {
                            bringerTemp = bri;
                        }


                    }

                    if (bringerTemp == null)
                    {
                        //invalidUsername();
                    }

                    if (password == bringerTemp.Password)
                    {
                        //login(UserTypes.Bringer);
                    }
                    else
                    {
                        //invalidPassword();
                    }
                    break;
                case UserTypes.Store: //UserType = Store
                    password = User.Password;
                    username = User.Username;
                    Store storeTemp = null;
                    foreach (var sto in _stores.ReadAll())
                    {
                        if (username == sto.Username)
                        {
                            storeTemp = sto;
                        }


                    }

                    if (storeTemp == null)
                    {
                        //invalidUsername();
                    }

                    if (password == storeTemp.Password)
                    {
                        //login(UserTypes.Store);
                    }
                    else
                    {
                        //invalidPassword();
                    }
                    break;
                default:
                    //dør baby
                    break;
            }
        }
    }
}
