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
        public static async void getStockData(string symbol, DateTime startTime, DateTime endDate, RichTextBox rtb)
        {
            try
            {
                symbol = symbol.ToUpper();
                var historicData = await Yahoo.GetHistoricalAsync(symbol, startTime, endDate);
                var security = await Yahoo.Symbols(symbol).Fields(Field.LongName).QueryAsync();
                var ticker = security[symbol];
                var companyName = ticker[Field.LongName];
                //var highVal = ticker[Field.FiftyTwoWeekHigh];

                rtb.Text += "  " + companyName + "\n";
                for (int i = 0; i < historicData.Count; i++)
                {

                    rtb.Text +=
                        "\n"
                        + "Closing price on "
                        + historicData.ElementAt(i).DateTime.Day + "/"
                        + historicData.ElementAt(i).DateTime.Month + "/"
                        + historicData.ElementAt(i).DateTime.Year +
                        ": $" + Math.Round(historicData.ElementAt(i).Close, 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static async Task<int> readHigh(string path, DateTime startDate, DateTime endDate, RichTextBox rtb, ProgressBar bar, Label lbl)
        {
            int highConter = 0;
            List<string> linesList = File.ReadAllLines(path).ToList();

            for (int i = 0; i < linesList.Count; i++)
            {
                try
                {
                    string nameOfStock = linesList[i].Substring(0, linesList[i].IndexOf(":"));
                    var h = await Yahoo.GetHistoricalAsync(nameOfStock, startDate, endDate);

                    var securities = await Yahoo.Symbols(nameOfStock).Fields(Field.Symbol, Field.FiftyTwoWeekHigh).QueryAsync();
                    var ticker = securities[nameOfStock];
                    var s = ticker[Field.FiftyTwoWeekHigh];
                    MessageBox.Show("For " + nameOfStock + " 52 h: " + s);

                    decimal currHigh = Math.Round(h.ElementAt(0).High, 2);

                    string oldHighValueStr = linesList[i].Substring(linesList[i].IndexOf(" ") + 1);
                    decimal oldHighValue = Convert.ToDecimal(oldHighValueStr);

                    if (currHigh > oldHighValue)
                    {
                        rtb.Text += "\nHIGH: " + nameOfStock + ":  " + currHigh + " $";
                        highConter++;

                        //linesList[i] = nameOfStock + ": " + currHigh;
                        //File.WriteAllLines((path), linesList.ToArray());
                    }
                    bar.Value++;
                } catch (Exception ex)
                {
                    rtb.Text += "\n" + ex.Message;
                }
            }
            lbl.Text = highConter.ToString();

            return highConter;
        }

        public static async Task<int> readLow(string path, DateTime startDate, DateTime endDate, RichTextBox rtb, ProgressBar bar, Label lbl)
        {
            int lowCounter = 0;
            List<string> linesList = File.ReadAllLines(path).ToList();

            for (int i = 0; i < linesList.Count; i++)
            {
                try
                {
                    string nameOfStock = linesList[i].Substring(0, linesList[i].IndexOf(":"));

                    var h = await Yahoo.GetHistoricalAsync(nameOfStock, startDate, endDate);
                    decimal currLow = Math.Round(h.ElementAt(0).Low, 2);

                    string oldLowValueS = linesList[i].Substring(linesList[i].IndexOf(" ") + 1);
                    decimal oldLowValue = Convert.ToDecimal(oldLowValueS);

                    if (currLow < oldLowValue)
                    {
                        rtb.Text += "\nLOW: " + nameOfStock + ":  " + currLow + " $";
                        lowCounter++;

                        //linesList[i] = nameOfStock + ": " + currLow;
                        //File.WriteAllLines((path), linesList.ToArray());
                    }
                    bar.Value++;
                }
                catch (Exception ex)
                {
                    rtb.Text += "\n" + ex.Message;
                }
            }

            lbl.Text = lowCounter.ToString();

            return lowCounter;
        }

        public static async void updateHighFile(string path, DateTime startDate, DateTime endDate)
        {
            List<string> linesList = File.ReadAllLines(path).ToList();
            for (int i = 0; i < linesList.Count; i++)
            {
                string nameOfStock = linesList[i].Substring(0, linesList[i].IndexOf(":"));

                var historicData = await Yahoo.GetHistoricalAsync(nameOfStock, startDate, endDate);
                decimal currHigh = Math.Round(historicData.ElementAt(0).High, 2);

                string oldHighValueS = linesList[i].Substring(linesList[i].IndexOf(" ") + 1);
                decimal oldHighValue = Convert.ToDecimal(oldHighValueS);

                if (currHigh > oldHighValue)
                {
                    linesList[i] = nameOfStock + ": " + currHigh;
                    File.WriteAllLines((path), linesList.ToArray());
                }
            }
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

        public static async Task callBothMethods(string pathHigh, string pathLow, DateTime startDate, DateTime endDate, RichTextBox rtb, ProgressBar bar, Label lblhigh, Label lbllow)
        {
            Task<int> highTask = readHigh(pathHigh, startDate, endDate, rtb, bar, lblhigh);
            Task<int> lowTask = readLow(pathLow, startDate, endDate, rtb, bar, lbllow);

            await Task.WhenAll(highTask, lowTask);

            int hPrices = highTask.Result;
            int lPrices = lowTask.Result;

            DatesFile.writeHighLow(hPrices, lPrices);
        }


        #region optimizacija

        private static async Task<List<string>> ReadAllLinesAsync(string path)
        {
            using (var reader = new StreamReader(path))
            {
                var linesList = new List<string>();
                while (!reader.EndOfStream)
                {
                    linesList.Add(await reader.ReadLineAsync());
                }
                return linesList;
            }
        }

        public static async Task HighAndLowToday(string path, ProgressBar bar, Label lblHighPrice, Label lblLowPrice, RichTextBox rtb)
        {
            List<string> lines = await ReadAllLinesAsync(path);
            int sumOfHighs = 0;
            int sumOfLows = 0;

            for(var i = 0; i < lines.Count; i++)
            {
                try
                {
                    string symbol = lines[i].Substring(0, lines[i].IndexOf(' '));

                    string subHigh = lines[i].Substring(lines[i].IndexOf(':') + 1);
                    string Highstr = subHigh.Substring(0, subHigh.IndexOf(' '));
                    string Lowstr = lines[i].Substring(lines[i].LastIndexOf(':') + 1);

                    double oldHigh = Convert.ToDouble(Highstr);
                    double oldLow = Convert.ToDouble(Lowstr);

                    var security = await Yahoo.Symbols(symbol).Fields(Field.FiftyTwoWeekHigh, Field.FiftyTwoWeekLow).QueryAsync();
                    var ticker = security[symbol];

                    var currHigh = ticker[Field.FiftyTwoWeekHigh];
                    var currLow = ticker[Field.FiftyTwoWeekLow];

                    if (oldHigh < currHigh && oldLow < currLow)
                    {
                        sumOfHighs++;
                        rtb.Text += "\nHigh for: " + symbol + " = " + currHigh;
                        lines[i] = symbol + " - high:" + currHigh + " low:" + oldLow;
                        File.WriteAllLines((path), lines.ToArray());
                    }

                    else if (oldLow > currLow && oldHigh > currHigh)
                    {
                        sumOfLows++;
                        rtb.Text += "\nLow for: " + symbol + " = " + currLow;
                        lines[i] = symbol + " - high:" + oldHigh + " low:" + currLow;
                        File.WriteAllLines((path), lines.ToArray());
                    }

                    else if(oldLow > currLow && oldHigh < currHigh)
                    {
                        sumOfHighs++;
                        sumOfLows++;
                        rtb.Text += "\nFor: " + symbol + " new high price: " + currHigh + ", and new low price: " + currLow;
                        lines[i] = symbol + " - high:" + currHigh + " low:" + currLow;
                        File.WriteAllLines((path), lines.ToArray());
                    }
            }
                catch (Exception ex)
            {
                rtb.Text += "\n\t" + ex.Message;
            }

            bar.Value++;

            }

            DatesFile.writeHighLow(sumOfHighs, sumOfLows);

            lblHighPrice.Text = sumOfHighs.ToString();
            lblLowPrice.Text = sumOfLows.ToString();
        }

        #endregion


    }
}
