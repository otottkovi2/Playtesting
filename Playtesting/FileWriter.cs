using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            var allLines = testers
                .Select(t => $"{t.Name}, {t.Age}, {t.Version}, {t.Playtime}, {t.HwTier}, {t.PerformanceScore}," +
                                               $" {t.GameplayScore}, {t.StoryScore}, {t.VisualsScore}, {t.MusicScore}")
                .Aggregate((c, n) => c + "\n" + n);
            var sw = new StreamWriter(stream,Encoding.UTF8);
            sw.WriteLine("Név,Kor,Verzió,Játékidő (h),HW Tier,Teljesítmény,Játékmenet,Történet,Látvány,Zene");
            sw.Write(allLines);
            sw.Flush();
            sw.Close();
        }
    }
}