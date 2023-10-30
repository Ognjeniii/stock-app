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

        static string pathHigh = @"C:\Users\Ogi\Desktop\High.txt";
        static string pathLow = @"C:\Users\Ogi\Desktop\Low.txt";

        StockData stock = new StockData();

        DateTime startDate = DateTime.Today.AddDays(-1);
        DateTime endDate = DateTime.Today;

        static int numOfLinesHigh = File.ReadAllLines(pathHigh).Count();
        static int numOfLinesLow = File.ReadAllLines(pathLow).Count();

        static int numOfLines = numOfLinesHigh + numOfLinesLow;

        private async void Form1_Load(object sender, EventArgs e)
        {
            rtbResult.Text += "Stocks that achieved 52 week high and 52 week low price today: \n";

            progressBar.Maximum = numOfLines;

            DateTime t = DateTime.Now;

            await StockData.getH(pathHigh, rtbResult, startDate, endDate);

            //string s = await StockData.callBothMethods(pathHigh, pathLow, startDate, endDate, rtbResult, progressBar, lblHighPrice);

            //await StockData.readHigh(pathHigh, startDate, endDate, rtbResult, progressBar, lblHighPrice);
            //await StockData.readLow(pathLow, startDate, endDate, rtbResult, progressBar, lblLowPrice);

            //int highPrice = Int32.Parse(lblHighPrice.Text);
            //int lowPrice = Int32.Parse(lblLowPrice.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show
                (
                "Are you sure that you want to update all 52 week high prices?",
                "Update file",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (dialogResult == DialogResult.Yes)
            {
                StockData.updateHighFile(pathHigh, startDate, endDate);
            }
        }

        private void btnData_Click(object sender, EventArgs e)
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

        private void btnUpdateLow_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show
                (
                "Are you sure that you want to update all 52 week low prices?",
                "Update file",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (dialogResult == DialogResult.Yes)
            {
                StockData.updateLowFile(pathLow, startDate, endDate);
            }
        }
    }
}
