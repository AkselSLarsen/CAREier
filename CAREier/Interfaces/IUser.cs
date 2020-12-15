using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    public interface IUser {
        public string Name { get; }
        public string Email { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public WorldPoint Location { get; set; }
    }
}