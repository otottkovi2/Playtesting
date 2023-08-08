using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Playtesting
{
    public static class FileWriter
    {

        public static void SaveToJson(Stream stream, object objectToSave)
        {
            JsonSerializer.Serialize(stream, objectToSave, objectToSave.GetType());
            stream.Flush();
            stream.Close();
        }

        public static void SaveToCsv(Stream stream, IEnumerable<Tester> testers)
        {
            var allLines = testers.Select(t => t.ToString()).Aggregate((c, n) => c + "\n" + c);
            var sw = new StreamWriter(stream);
            sw.Write(allLines);
            sw.Flush();
            sw.Close();
        }
    }
}