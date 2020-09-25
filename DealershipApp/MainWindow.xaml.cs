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

namespace DealershipApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ComboBox Cars;
        double interest; //3.8%
        Database CarDB;

        public MainWindow()
        {
            InitializeComponent();
            Cars = CarSelection;
            LoadData();
        }

        private void LoadData()
        {
            CarDB = new Database();
            interest = CarDB.interest;
            foreach (KeyValuePair<string, int> entry in CarDB.data)
            {
                Cars.Items.Add(entry.Key);
            }
            Cars.SelectedIndex = 0;

            InterestRate.Content = "Interest: " + interest * 100 + "%";

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int price;
            CarDB.data.TryGetValue(Cars.SelectedItem.ToString(), out price);
            CarPrice.Content = "Price: $" + price;
        }

        private void ValidateNumber(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            var fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
            double val;
            e.Handled = !double.TryParse(fullText, out val);
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int price;
            int months = Int32.Parse(Months.Text);
            CarDB.data.TryGetValue(Cars.SelectedItem.ToString(), out price);
            double payment = (price * (1 + (interest / 12) * months)) / months;
            payment = Math.Ceiling(payment * 100) / 100;
            Output.Content = "Monthly Payment: $"+ payment;
        }
    }
}
