using Newtonsoft.Json;
using System;
using System.IO;

namespace LightNode.Formatter
{
    public class JsonNetContentFormatter : LightNode.Formatter.ContentFormatterBase
    {
        private readonly JsonSerializer serializer;
        
        public JsonNetContentFormatter(string mediaType = "application/json", string ext = "json")
            : base(mediaType, ext)
        {
            serializer = new JsonSerializer();
        }
        
        public JsonNetContentFormatter(JsonSerializer serializer, string mediaType = "application/json", string ext = "json")
            : base(mediaType, ext)
        {
            this.serializer = serializer;
        }

        public override void Serialize(System.IO.Stream stream, object obj)
        {
            using (var sw = new StringWriter())
            using (var jw = new JsonTextWriter(sw)) {
                serializer.Serialize(jw, obj);
                var json = sw.GetStringBuilder().ToString();
                var enc = System.Text.Encoding.UTF8.GetBytes(json);
                stream.Write(enc, 0, enc.Length);
            }
        }

        public override object Deserialize(Type type, System.IO.Stream stream)
        {
            using (var sr = new StreamReader(stream))
            using (var jr = new JsonTextReader(sr))
            {
                return serializer.Deserialize(jr, type);
            }
        }
    }
}
