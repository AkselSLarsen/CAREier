using CAREier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Models.profiles {
    public class User : IUser {
        public Buyer _buyer;
        private Bringer _bringer;
        private Store _store;

        public User() {

        }

        public IUser Profile {
            get {
                if(_buyer != null) {
                    return _buyer;
                } else if(_bringer != null) {
                    return _bringer;
                } else if(_store != null) {
                    return _store;
                } else {
                    //Så dør baby
                    return null;
                }
            }
            set {
                if (value is Buyer) {
                    _buyer = (Buyer)value;
                    _bringer = null;
                    _store = null;
                } else if (value is Bringer) {
                    _buyer = null;
                    _bringer = (Bringer)value;
                    _store = null;
                } else if (value is Store) {
                    _buyer = null;
                    _bringer = null;
                    _store = (Store)value;
                } else {
                    //Så dør baby
                    _buyer = null;
                    _bringer = null;
                    _store = null;
                }
            }
        }

        public string Name => Profile.Name;

        public string Email => Profile.Email;

        public string Username => Profile.Username;

        public string Password => Profile.Password;

        public WorldPoint Location { get; set; }
    }
}
