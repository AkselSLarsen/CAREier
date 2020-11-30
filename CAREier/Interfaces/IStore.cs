﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    public interface IStore : IUser {

        public List<string> Addresses { get; }
        public string BankAccount { get; }
    }
}
