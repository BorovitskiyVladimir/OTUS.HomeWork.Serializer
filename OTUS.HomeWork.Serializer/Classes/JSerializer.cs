using Newtonsoft.Json;

namespace OTUS.HW5.Serializer.classes
{
    public class JSerializer : ISerializer
    {
        public string Serialize<MyObj>(MyObj obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public MyObj Deserialize<MyObj>(string data) where MyObj : new()
        {
            return JsonConvert.DeserializeObject<MyObj>(data);
        }
    }
}
