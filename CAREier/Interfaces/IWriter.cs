﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier.Interfaces {
    [Obsolete]
    public interface IWriter<Item> {

        public void WriteState(Item state, string fileLocation);
    }
}