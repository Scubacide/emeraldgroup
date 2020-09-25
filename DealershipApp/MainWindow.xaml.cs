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
        Database CarDB;

        public MainWindow()
        {
            InitializeComponent();
            Cars = CarSelection;
            LoadData();
            UpdateList();
        }

        private void LoadData() //Loads finacial data
        {
            CarDB = new Database();
            InterestRate.Content = "Interest: " + CarDB.interest * 100 + "%";
        }

        private void UpdateList() //Updates cars combobox
        {
            foreach (KeyValuePair<string, int> entry in CarDB.data)
            {
                Cars.Items.Add(entry.Key);
            }
            Cars.SelectedIndex = 0;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e) //validates GUI inputs then requests payment calculation
        {
            int price;
            int months;
            bool check = Int32.TryParse(Months.Text, out months);
            bool check2 = CarDB.data.TryGetValue(Cars.SelectedItem.ToString(), out price);

            if (check && check2 && months > 0) {
                Output.Content = "Monthly Payment: $"+ PaymentCalculator.CalculateMonthly(price, CarDB.interest, months);
            } else
            {
                Output.Content = "Error: Invalid months. \nPlease ensure it is not a decimal & > 0.";
            }
        }



        //Gui Validations
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int price;
            CarDB.data.TryGetValue(Cars.SelectedItem.ToString(), out price);
            CarPrice.Content = "Price: $" + price;
        }

        private void ValidateNumber(object sender, TextCompositionEventArgs e) //restrict non-numbers from textbox
        {
            var textBox = sender as TextBox;
            var fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
            double val;
            e.Handled = !double.TryParse(fullText, out val);
        }

        private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e) //Prevent pasting of non-numbers into textbox
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
