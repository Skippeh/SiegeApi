using System.IO;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SiegeApi
{
    public class CustomJsonSerializer : ISerializer, IDeserializer
    {
        private readonly JsonSerializer serializer;

        public CustomJsonSerializer(JsonSerializer serializer)
        {
            this.serializer = serializer;
        }

        public string ContentType {
            get => "application/json";
            set {}
        }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    serializer.Serialize(jsonTextWriter, obj);

                    return stringWriter.ToString();
                }
            }
        }

        public T Deserialize<T>(IRestResponse response)
        {
            var content = response.Content;

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        public static CustomJsonSerializer Default => new CustomJsonSerializer(new JsonSerializer
        {
            Converters =
            {
                // add custom json converters here
            }
        });
    }
}