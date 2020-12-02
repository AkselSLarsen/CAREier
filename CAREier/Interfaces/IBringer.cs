using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    public interface IBringer : IUser {

        public string PhoneNumber { get; }
        public string CreditCard { get; }
    }
}
