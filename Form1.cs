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

        static string lowHighPath = @"C:\Users\Ogi\Desktop\Stock\Test.txt";

        DateTime endDate = DateTime.Today;

        static int numOfLines = File.ReadAllLines(lowHighPath).Count();

        private async void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("If you didn't run application more than 1 day, you need to update HighsAndLow.txt file.");
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

        private async void btnGet52DataToday_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure that you want to retrieve new data?" +
                "\nAll data will be changed in HighsAndLows.txt file." +
                "\nHighs and lows on this day will be added to the file dates.",
                "Yes/No",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                progressBar.Maximum = numOfLines;
                progressBar.Value = 0;
                progressBar.Minimum = 0;

                rtbResult.Text += "\nStocks that achieved 52 week high and 52 week low price today:\n";
                await StockData.HighAndLowToday(lowHighPath, progressBar, lblHighPrice, lblLowPrice, rtbResult);
            }
        }

        private async void btnUpdateFile_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure that you want to update old 52 week highs and lows to today values?" +
                "\nAll values will be changed in file HighsAndLows.txt",
                "Update file",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await StockData.UpdateFile(lowHighPath);
                    MessageBox.Show("File updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
