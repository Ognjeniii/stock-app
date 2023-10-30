using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YahooFinanceApi;

namespace FicaTestiranje
{
    public class StockData
    {
        // Proveri da li se trenutni datum nalazi u fajlovima, ako se nalazi, ne treba da se pozove funkcija za ispis.
        // ako ne postoji, trebalo bi da se automatski pozove f-ja, i da se ispise u fajl.
        //EMP
        public static async void getStockData(string symbol, DateTime startTime, DateTime endDate, RichTextBox rtb)
        {
            try
            {
                symbol = symbol.ToUpper();
                var historicData = await Yahoo.GetHistoricalAsync(symbol, startTime, endDate);
                var security = await Yahoo.Symbols(symbol).Fields(Field.LongName).QueryAsync();
                var ticker = security[symbol];
                var companyName = ticker[Field.LongName];
                rtb.Text += "  " + companyName + "" + "\n";
                for (int i = 0; i < historicData.Count; i++)
                {
                    
                    rtb.Text +=
                        "\n"
                        + "Closing price on "
                        + historicData.ElementAt(i).DateTime.Day + "/"
                        + historicData.ElementAt(i).DateTime.Month + "/"
                        + historicData.ElementAt(i).DateTime.Year +
                        ": $" + Math.Round(historicData.ElementAt(i).Close, 2);
                    // ovde vidi sta jos treba od podataka
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static async Task getH(string path, RichTextBox rtb, DateTime startDate, DateTime endDate)
        {
            List<string> linesList = File.ReadAllLines(path).ToList();

            for(int i = 0; i < linesList.Count; i++)
            {
                string nameOfStock = linesList[i].Substring(0, linesList[i].IndexOf(":"));

                var h = await Yahoo.GetHistoricalAsync(nameOfStock, startDate, endDate);
                decimal currHigh = Math.Round(h.ElementAt(0).High, 2);

                rtb.Text += "\nHIGH: " + nameOfStock + ":  " + currHigh + " $";
            }
        }

        public static async Task<int> readHigh(string path, DateTime startDate, DateTime endDate, RichTextBox rtb, ProgressBar bar, Label lbl)
        {
            int highConter = 0;
            List<string> linesList = File.ReadAllLines(path).ToList();

            bar.Value = 0;
            bar.Minimum = 0;

            for (int i = 0; i < linesList.Count; i++)
            {
                try
                {
                    string nameOfStock = linesList[i].Substring(0, linesList[i].IndexOf(":"));

                    var h = await Yahoo.GetHistoricalAsync(nameOfStock, startDate, endDate);
                    decimal currHigh = Math.Round(h.ElementAt(0).High, 2);

                    string oldHighValueStr = linesList[i].Substring(linesList[i].IndexOf(" ") + 1);
                    decimal oldHighValue = Convert.ToDecimal(oldHighValueStr);

                    if (currHigh > oldHighValue)
                    {
                        rtb.Text += "\nHIGH: " + nameOfStock + ":  " + currHigh + " $";
                        highConter++;
                    }
                    bar.Value++;
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            lbl.Text = highConter.ToString();

            return highConter;
        }

        public static async void updateHighFile(string path, DateTime startDate, DateTime endDate)
        {
            List<string> linesList = File.ReadAllLines(path).ToList();
            for (int i = 0; i < linesList.Count; i++)
            {
                string nameOfStock = linesList[i].Substring(0, linesList[i].IndexOf(":"));

                var historicData = await Yahoo.GetHistoricalAsync(nameOfStock, startDate, endDate);
                decimal currHigh = Math.Round(historicData.ElementAt(0).High, 2);

                //decimal currHigh = await getOneHigh(nameOfStock, startDate, endDate);
                string oldHighValueS = linesList[i].Substring(linesList[i].IndexOf(" ") + 1);
                decimal oldHighValue = Convert.ToDecimal(oldHighValueS);
                if (currHigh > oldHighValue)
                {
                    linesList[i] = nameOfStock + ": " + currHigh;
                    File.WriteAllLines((path), linesList.ToArray());
                }
            }
        }

        public static async Task<int> readLow(string path, DateTime startDate, DateTime endDate, RichTextBox rtb, ProgressBar bar, Label lbl)
        {
            int lowCounter = 0;
            List<string> linesList = File.ReadAllLines(path).ToList();
            bar.Value = 0;
            bar.Minimum = 0;

            for (int i = 0; i < linesList.Count; i++)
            {
                string nameOfStock = linesList[i].Substring(0, linesList[i].IndexOf(":"));

                var h = await Yahoo.GetHistoricalAsync(nameOfStock, startDate, endDate);
                decimal currLow = Math.Round(h.ElementAt(0).Low, 2);

                string oldLowValueS = linesList[i].Substring(linesList[i].IndexOf(" ") + 1);
                decimal oldLowValue = Convert.ToDecimal(oldLowValueS);

                if (currLow < oldLowValue)
                {
                    //rtb.ForeColor = Color.Red;
                    rtb.Text += "\nLOW: " + nameOfStock + ":  " + currLow + " $";
                    lowCounter++;
                }
                bar.Value++;
            }
            lbl.Text = lowCounter.ToString();

            return lowCounter;
        }

        public static async void updateLowFile(string path, DateTime startDate, DateTime endDate)
        {
            List<string> linesList = File.ReadAllLines(path).ToList();
            for (int i = 0; i < linesList.Count; i++)
            {
                string nameOfStock = linesList[i].Substring(0, linesList[i].IndexOf(":"));

                var historicData = await Yahoo.GetHistoricalAsync(nameOfStock, startDate, endDate);
                decimal currLow = Math.Round(historicData.ElementAt(0).Low, 2);

                //decimal currLow = await getOneHigh(nameOfStock, startDate, endDate);
                string oldLowValueS = linesList[i].Substring(linesList[i].IndexOf(" ") + 1);
                decimal oldLowValue = Convert.ToDecimal(oldLowValueS);
                if (currLow < oldLowValue)
                {
                    linesList[i] = nameOfStock + ": " + currLow;
                    File.WriteAllLines((path), linesList.ToArray());
                }
            }
        }

        public static async Task<string> callBothMethods(string pathHigh, string pathLow, DateTime startDate, DateTime endDate, RichTextBox rtb, ProgressBar bar, Label lbl)
        {
            int hPrices = await readHigh(pathHigh, startDate, endDate, rtb, bar, lbl);
            int lPrices = await readLow(pathLow, startDate, endDate, rtb, bar, lbl);

            DateTime dateTime = DateTime.Now;

            return dateTime.ToString("d") + " - high: " + hPrices + ", low: " + lPrices;
        }
        

        #region Metode za upis u fajlove
        public async Task<int> getLowPrice(string symbol, DateTime startDate, DateTime endDate)
        {
            try
            {
                var historicData = await Yahoo.GetHistoricalAsync(symbol, startDate, endDate);
                var security = await Yahoo.Symbols(symbol).Fields(Field.LongName).QueryAsync();
                var ticker = security[symbol];
                var companyName = ticker[Field.LongName];

                List<decimal> prices = new List<decimal>();

                for (int i = 0; i < historicData.Count; i++)
                {
                    //Console.WriteLine("Low price for company " + symbol + " is " + historicData.ElementAt(i).Low);
                    prices.Add(historicData.ElementAt(i).Low);
                }
                decimal lowPrice = Math.Round(prices.Min(), 3);

                string path = @"C:\Users\Ogi\Desktop\Low.txt";
                File.AppendAllText(path, symbol + ": " + lowPrice + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t" + ex.Message);
            }
            return 1;
        }

        public async Task<int> getHighPrice(string symbol, DateTime startDate, DateTime endDate)
        {
            try
            {
                var historicData = await Yahoo.GetHistoricalAsync(symbol, startDate, endDate);
                var security = await Yahoo.Symbols(symbol).Fields(Field.LongName).QueryAsync();
                var ticker = security[symbol];
                var companyName = ticker[Field.LongName];

                List<decimal> prices = new List<decimal>();

                for (int i = 0; i < historicData.Count; i++)
                {
                    prices.Add(historicData.ElementAt(i).High);
                }
                decimal highPrice = Math.Round(prices.Max(), 3);

                string path = @"C:\Users\Ogi\Desktop\High.txt";
                File.AppendAllText(path, symbol + ": " + highPrice + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t" + ex.Message);
            }
            return 1;
        }
        #endregion

    }
}
