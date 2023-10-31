﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FicaTestiranje
{
    public class DatesFile
    {
        static string path = $"C:/Users/Ogi/Desktop/Dates.txt";

        public static void writeHighLow(int hPrices, int lPrices)
        {
            DateTime dateTime = DateTime.Now;
            string currDate = dateTime.Day.ToString() + "/" + dateTime.Month.ToString() + "/" + dateTime.Year.ToString();

            List<string> dates = File.ReadAllLines(path).ToList();

            string line = currDate + ": High-" + hPrices + " Low-" + lPrices;

            if (!dates.Contains(line))
            {
                File.AppendAllText(path, line + "\n");
            }
        }

        public static void searchForDate(string date, RichTextBox rtb)
        {
            List<string> dates = File.ReadAllLines(path).ToList();

            foreach (var line in dates)
            {
                if (line.StartsWith(date))
                {
                    string lh = line.Substring(date.Length + 1);
                    rtb.Text += "\nFor date " + date + ": \n" + lh + "\n";
                    return;
                }
            }

            rtb.Text += "\nNo data for " + date + "\n";
        }
    }
}
