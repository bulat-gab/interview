﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Hashmap;

namespace Test.Hashmap.DesignHashSetUtil;
internal interface ICommand
{
    bool Execute(DesignHashset hashset, int value);
}
