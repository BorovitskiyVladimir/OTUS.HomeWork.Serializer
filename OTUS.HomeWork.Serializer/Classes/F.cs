﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OTUS.HW5.Serializer.classes
{
    class F
    {
        public int i1 { get; set; }
        public int i2 { get; set; }
        public int i3 { get; set; }
        public int i4 { get; set; }
        public int i5 { get; set; }
        public static F GetTestClass() => new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
    }

}
