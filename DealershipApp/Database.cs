using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Net;
using System.Windows;

namespace DealershipApp
{
    class Database
    {
        public Dictionary<string, int> data = new Dictionary<string, int>();
        public double interest;
        public Database()
        { //Constructor, initializies the 'DataBase' 
      
            using (TextFieldParser csvParser = new TextFieldParser(@"CarData.csv"))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                bool firstline = true;
                int line = 1;
                while (!csvParser.EndOfData)
                {
                    if (firstline)
                    {
                        firstline = !firstline;
                        string[] fields = csvParser.ReadFields();
                        bool pass = double.TryParse(fields[3], out interest) ;
                        if (!pass) { 
                            MessageBoxResult result = MessageBox.Show("Interest value is malformed! Please fix it! \nEx: 3.8", "CarDB.CSV");
                            Environment.Exit(-1);
                        }
                        interest /= 100;

                    } else { 

                        string[] fields = csvParser.ReadFields();
                        string CarModel = fields[0];
                        int Price = 0;
                        line++;

                        bool pass = Int32.TryParse(fields[1], out Price);
                        if (!pass)
                        {
                            MessageBoxResult result = MessageBox.Show("Price for: "+fields[0]+" At line: "+line+" is not a valid number!" , "CarDB.CSV");
                            Environment.Exit(-1);
                        }

                        data.Add(CarModel, Price);
                    }
                }
            }
        }
        public void SetInterest(double i)
        {
            this.interest = i;
        }

    }
}
