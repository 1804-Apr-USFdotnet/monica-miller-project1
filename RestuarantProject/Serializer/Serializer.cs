using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Serializer
{
    public static class Serializer
    {
        public static void Serialize<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\RestaurantData.json", true))
            {
                file.WriteLine(json);
            }

        }

        public static T Deserialize<T>(string jsonStr)
        {
            T obj = JsonConvert.DeserializeObject<T>(jsonStr);
            return obj;
        }
    }
}
