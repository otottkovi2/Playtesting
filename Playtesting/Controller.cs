using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;

namespace Playtesting
{
    public class Controller
    {
        private readonly List<Tester> testers;
        public List<Tester> Testers => testers;

        public Controller(List<Tester> testers)
        {
            this.testers = testers;
        }

        public void SaveToJson(Stream stream)
        {
            FileWriter.SaveToJson(stream,testers);
        }

        public void SaveToCsv(Stream stream)
        {
            FileWriter.SaveToCsv(stream,testers);
        }

        public void SetBindingTo(ItemsControl control)
        {
            var binding = new Binding("Testers")
            {
                Mode = BindingMode.OneWay,
                Source = this
            };
            control.SetBinding(ItemsControl.ItemsSourceProperty, binding);
        }
    }
}