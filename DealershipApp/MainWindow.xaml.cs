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
        double discount = 0;
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

        //Gui Validations
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int price;
            CarDB.data.TryGetValue(Cars.SelectedItem.ToString(), out price);
            CarPrice.Content = "Price: $" + price;
            calculate();
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

        private void inputDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (discountLabel == null) return;
            double newdiscount;
            bool success = double.TryParse(inputDiscount.Text, out newdiscount);
            if (success)
            {
                discount = newdiscount / 100;
                discountLabel.Content = "Discount: " + discount * 100 + "%";
                calculate();
            }
            else
            {
                discountLabel.Content = "Discount: INVALID FORMAT example: 3.8% -> 3.8";
            }

        }
        private void inputYears_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (inputYears == null || lengthLabel == null) return;
            lengthLabel.Content = inputYears.Text != "" ? "Loan Length (Years)" : "PLEASE INPUT # YEARS";
            if (inputYears.Text != "")
                calculate();
        }

        private void calculate()
        {
            if (inputYears == null || inputDiscount == null || monthlyLabel == null) return;
            int price;
            int years;
            bool check = Int32.TryParse(inputYears.Text, out years);
            bool check2 = CarDB.data.TryGetValue(Cars.SelectedItem.ToString(), out price);

            if (check && check2 && years > 0)
            {
                double total = PaymentCalculator.CalculateTotal(price, CarDB.interest, years);
                total = (total - (total * discount));
                double monthly = total / (years * 12);
                totalLabel.Content = "Total: $" + total;
                monthlyLabel.Content = "Monthly: $" + Math.Ceiling(monthly*100)/100;
            }
        }
    }
}
