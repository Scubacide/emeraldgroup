using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Net;

namespace DealershipApp
{
    class Database
    {
        public Dictionary<string, int> data = new Dictionary<string, int>(); //Where we store rainfall data for the session
        public double interest;
        public Database()
        { //Constructor, initializies the 'DataBase' 
      
            using (TextFieldParser csvParser = new TextFieldParser(@"CarData.csv"))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                bool firstline = true;

                while (!csvParser.EndOfData)
                {
                    if (firstline)
                    {
                        firstline = !firstline;
                        string[] fields = csvParser.ReadFields();
                        interest = double.Parse(fields[3]) / 100;
                    } else { 
                        // Read current line fields, pointer moves to the next line.
                        //Field 4 is the data in the csv file, field 126 is the "Daily Sum" of the rain in 1/100ths of an inch
                        string[] fields = csvParser.ReadFields();
                        string CarModel = fields[0];
                        int Price = Int32.Parse(fields[1]);
                        data.Add(CarModel, Price );
                    }
                }
            }
        }


    }
}
