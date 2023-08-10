using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Playtesting
{
    /// <summary>
    /// Interaction logic for NewTesterWindow.xaml
    /// </summary>
    public partial class NewTesterWindow : Window
    {
        public NewTesterWindow(Controller controller)
        {
            InitializeComponent();
            AddButton.Click += (_, _) =>
            {
                var name = NameField.Text;
                var age = GetNumberInRange(AgeField.Text, 1, 99);
                if (age is null) return;
                var version = VersionField.Text;
                var playtime = GetNumberInRange(TimeField.Text);
                if (playtime is null) return;
                var hwTier = GetNumberInRange(HwField.Text);
                if (hwTier is null) return;
                var perf = GetNumberInRange(PerfField.Text);
                if (perf is null) return;
                var gameplay = GetNumberInRange(GameplayField.Text);
                if (gameplay is null) return;
                var story = GetNumberInRange(StoryField.Text);
                if (story is null) return;
                var visuals = GetNumberInRange(VisualsField.Text);
                if (visuals is null) return;
                var musicScore = GetNumberInRange(MusicField.Text);
                if (musicScore is null) return;
                var newTester = new Tester(name,(byte)age, version,(byte) playtime, (byte) hwTier, 
                    (byte) perf, (byte) gameplay, (byte) story, (byte) visuals,
                    (byte) musicScore);
                controller.AddTester(newTester);
                MessageBox.Show("Sor hozzáadva!", "Sikeres hozzáadás!", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                Close();
            };
        }

        private static void ShowError(IFrameworkInputElement box, string errorMessage)
        {
            MessageBox.Show("A(z) " + box.Name + " dobozba nem megfelelő adatok kerültek! Hiba: \n" + errorMessage,
                "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private float? GetNumberInRange(string str, byte min = 1, byte max = 10)
        {
            try
            {
                var number = Convert.ToByte(str);
                if (number < min || number > max) throw new InvalidOperationException(
                    "A megadott érték nem felel meg a határértékeknek.");
                return number;
            }
            catch (Exception e)
            {
                ShowError(AgeField, e.ToString());
                return null;
            }
        }

        
    }
}
