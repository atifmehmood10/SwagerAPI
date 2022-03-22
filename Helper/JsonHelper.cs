using System;
using System.IO;
using Newtonsoft.Json;

namespace SwaggerAPITesting.Helper{

    public class JsonHelper{

        // Json helper for serialize and deserialize
        public static string Serialize<T>(T body){

            return JsonConvert.SerializeObject(body, Formatting.Indented);
        }

        public static T DeSerialize<T>(string file){

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }

    }
}
