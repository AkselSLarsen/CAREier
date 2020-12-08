using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    public interface IUser {
        public string Name { get; }
        public string Email { get; }
        public string Username { get; }
        public string Password { get; }
    }
}