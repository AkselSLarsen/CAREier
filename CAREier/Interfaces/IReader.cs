﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    [Obsolete]
    public interface IReader<Item> {

        public Item ReadState(string fileLocation);
    }
}