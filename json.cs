using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace bo1tool
{
    public class json<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            string json = FormatJsonText((new JavaScriptSerializer()).Serialize(this));
            File.WriteAllText(fileName, json);
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            try
            {

                if (File.Exists(fileName))
                    t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
            }
            catch
            {
                MessageBox.Show("Could not parse a value. Check the file and try again!");
                t = default(T);
            }
            return t;
        }

        string FormatJsonText(string jsonString)
        {
            var doc = JsonDocument.Parse(jsonString, new JsonDocumentOptions
            {
                AllowTrailingCommas = true
            }
            );
            MemoryStream memoryStream = new MemoryStream();
            using (
                var utf8JsonWriter = new Utf8JsonWriter(
                    memoryStream,
                    new JsonWriterOptions
                    {
                        Indented = true
                    }
                )
            )
            {
                doc.WriteTo(utf8JsonWriter);
            }
            return new System.Text.UTF8Encoding().GetString(memoryStream.ToArray());
        }
    }
}
