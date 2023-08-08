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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Playtesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller? controller;

        public MainWindow()
        {
            InitializeComponent();
            LoadButton.Click += (_, _) =>
            {
                var fileDialog = new OpenFileDialog
                {
                    Filter = "minden támogatott fájl |*.csv;*.json|szöveges adatok |*.csv|JSON export fájl|*.json|Minden fájl |*.*",
                    Multiselect = false,
                    Title = "Forrás betöltése"
                };
                fileDialog.FileOk += (_, _) =>
                {
                    controller = fileDialog.SafeFileName.EndsWith(".json")
                        ? FileReader.ReadFromJson(fileDialog.OpenFile())
                        : FileReader.ReadFromCsv(fileDialog.OpenFile());
                    SaveButton.IsEnabled = true;
                    controller.SetBindingTo(Grid);
                };
                fileDialog.ShowDialog();
            };
            SaveButton.Click += (_, _) =>
            {
                var fileDialog = new SaveFileDialog
                {
                    Filter = "minden támogatott fájl |*.csv;*.json|szöveges adatok |*.csv|JSON export fájl | *.json|Minden fájl |*.*",
                    Title = "Mentés"
                };
                fileDialog.FileOk += (_, _) =>
                {
                    controller!.SaveToJson(fileDialog.OpenFile());
                    MessageBox.Show("Fájl elmentve!");
                };
                fileDialog.ShowDialog();
            };
        }
    }
}
