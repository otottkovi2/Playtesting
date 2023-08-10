using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;

namespace Playtesting
{
    public class Controller
    {
        public List<Tester> Testers { get; }

        public Controller(List<Tester> testers)
        {
            Testers = testers;
        }

        public void SaveToJson(Stream stream)
        {
            FileWriter.SaveToJson(stream, Testers);
        }

        public void SaveToCsv(Stream stream)
        {
            FileWriter.SaveToCsv(stream, Testers);
        }

        public void SetBindingFor(ItemsControl control)
        {
            control.ClearValue(ItemsControl.ItemsSourceProperty);
            var binding = new Binding("Testers")
            {
                Mode = BindingMode.OneWay,
                ValidationRules = { new ExceptionValidationRule(),new NotifyDataErrorValidationRule()},
                Source = this
            };
            control.SetBinding(ItemsControl.ItemsSourceProperty, binding);
        }

        public bool DeleteTester(Tester item)
        {
            return Testers.Remove(item);
        }

        public void AddTester(Tester item)
        {
            Testers.Add(item);
        }
    }
}