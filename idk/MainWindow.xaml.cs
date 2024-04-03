using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace idk
{
    public partial class MainWindow : Window
    {
        private int unitCount = 1;

        public MainWindow()
        {
            InitializeComponent();
            unitSelector.SelectionChanged += UnitSelector_SelectionChanged;
        }

        private void UnitSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertUnits();
        }

        private void ConvertUnits()
        {
            if (unitSelector.SelectedItem == null)
                return;

            string selectedItem = ((ComboBoxItem)unitSelector.SelectedItem).Content.ToString();
            string inputValue = inputBox.Text;
            double input;

            if (!double.TryParse(inputValue, out input))
            {
                outputBox.Text = "Invalid input";
                return;
            }

            double output = 0;

            switch (selectedItem) //převody
            {
                case "Meter to Centimeter":
                    output = input * 100;
                    break;
                case "Centimeter to Meter":
                    output = input / 100;
                    break;
                case "Meter to Inch":
                    output = input * 39.37; 
                    break;
                case "Inch to Meter":
                    output = input / 39.37; 
                    break;
            }

            outputBox.Text = output.ToString();
        }

        private void AddUnit_Click(object sender, RoutedEventArgs e)
        {
            unitCount++;
            unitSelector.Items.Add(new ComboBoxItem { Content = $"Unit {unitCount}" });
        }

        private void RemoveUnit_Click(object sender, RoutedEventArgs e)
        {
            if (unitCount > 1)
            {
                unitCount--;
                unitSelector.Items.RemoveAt(unitSelector.Items.Count - 1);
            }
        }
    }
}