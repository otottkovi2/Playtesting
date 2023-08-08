using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Playtesting
{
    public static class FileReader
    {
        public static Controller ReadFromCsv(Stream csvStream)
        {
            var lines = new StreamReader(csvStream).ReadToEnd().Split('\n');
            var readTesters = lines.Skip(1).Select(l =>
            {
                var split = l.Split(',');
                return new Tester(split[0], Convert.ToByte(split[1]), split[2], Convert.ToSingle(split[3]),
                    Convert.ToByte(split[4]), Convert.ToByte(split[5]), Convert.ToByte(split[6]),
                    Convert.ToByte(split[7]), Convert.ToByte(split[8]), Convert.ToByte(split[9]));
            }).ToList();
            return new Controller(readTesters);
        }

        public static Controller ReadFromJson(Stream jsonStream)
        {
            var readTesters = JsonSerializer.Deserialize(jsonStream, typeof(List<Tester>)) as List<Tester> ??
                              throw new InvalidOperationException();
            return new Controller(readTesters);
        }
    }
}