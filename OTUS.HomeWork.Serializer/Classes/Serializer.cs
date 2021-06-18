using System;
using System.Text;
using System.Reflection;

namespace OTUS.HW5.Serializer.classes
{
    class Serializer : ISerializer
    {
        private readonly StringBuilder textdata = new StringBuilder();
        private static BindingFlags flags => BindingFlags.Instance | BindingFlags.Public;

        public string Serialize<MyObj>(MyObj obj)
        {
            textdata.Clear();

            var properties = obj.GetType().GetProperties(flags);
            foreach (var field in properties)
            {
                textdata.Append($"{field.Name}:{field.GetValue(obj)};");
            }
            return textdata.ToString();
        }

        public MyObj Deserialize<MyObj>(string data) where MyObj : new()
        {
            MyObj obj = (MyObj)typeof(MyObj).GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
            var properties = obj.GetType().GetProperties(flags);
            var values = data.Split(';', StringSplitOptions.RemoveEmptyEntries);
            if (properties.Length != values.Length)
                throw new FormatException("Количество переданных свойств не совпадает с объектом!");

            foreach (var value in values)
            {
                var arr = value.Split(':');
                var field = obj.GetType().GetProperty(arr[0], flags);
                if (field != null)
                {
                    field.SetValue(obj, Convert.ChangeType(arr[1], field.PropertyType));
                }
            }
            return obj;
        }
    }
}
