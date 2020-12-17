using System;

namespace CAREier.Interfaces {
    [Obsolete]
    public interface ILoginCredentials {
        public string Email { get; }
        public string Password { get; set; }
    }
}