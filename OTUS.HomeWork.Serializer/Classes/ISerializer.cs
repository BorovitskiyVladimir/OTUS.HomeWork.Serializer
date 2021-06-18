using System;
using System.Collections.Generic;
using System.Text;

namespace OTUS.HW5.Serializer.classes
{
    interface ISerializer
    {
        string Serialize<MyObj>(MyObj obj);

        MyObj Deserialize<MyObj>(string data) where MyObj : new();
    }
}
