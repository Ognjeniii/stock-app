using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using YahooFinanceApi;

namespace FicaTestiranje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string pathHigh = @"C:\Users\Ogi\Desktop\HighTest.txt";
        static string pathLow = @"C:\Users\Ogi\Desktop\LowTest.txt";

        DateTime startDate = DateTime.Today.AddDays(-1);
        DateTime endDate = DateTime.Today;

        static int numOfLinesHigh = File.ReadAllLines(pathHigh).Count();
        static int numOfLinesLow = File.ReadAllLines(pathLow).Count();

        static int numOfLines = numOfLinesHigh + numOfLinesLow;

        private async void Form1_Load(object sender, EventArgs e)
        {
            rtbResult.Text += "Stocks that achieved 52 week high and 52 week low price today: \n";

            progressBar.Maximum = numOfLines;
            progressBar.Value = 0;
            progressBar.Minimum = 0;

            DateTime t = DateTime.Now;

            await StockData.callBothMethods(pathHigh, pathLow, startDate, endDate, rtbResult, progressBar, lblHighPrice, lblLowPrice);
        }

       
        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (tbMonths.Text != string.Empty && tbStockName.Text != string.Empty)
            {
                Int32.TryParse(tbMonths.Text, out int monthsNum);
                if (monthsNum != 0)
                {
                    DateTime start = DateTime.Today.AddMonths(-monthsNum);
                    StockData.getStockData(tbStockName.Text, start, endDate, rtbOneStock);
                }
                else
                {
                    MessageBox.Show
                        (
                        "You must enter only numbers (digits) in field for months amount",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }

                tbMonths.Text = string.Empty;
                tbStockName.Text = string.Empty;
            }
            else
            {
                MessageBox.Show
                    (
                    "All fields are required. You must enter all fields.",
                    "Warnirng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbOneStock.Clear();
        }

        private void btnSearchDates_Click(object sender, EventArgs e)
        {
            string inputDate = tbSearchDates.Text;
            tbSearchDates.Text = string.Empty;

            DatesFile.searchForDate(inputDate, rtbHighLowDates);
        }

        private void btnClearDates_Click(object sender, EventArgs e)
        {
            rtbHighLowDates.Clear();
        }
    }
}
