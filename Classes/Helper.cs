using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YahooFinanceApi;

namespace FicaTestiranje.Classes
{
    public class Helper
    {
        public static async Task getOnePriceAndWrite(string symbol, RichTextBox rtb)
        {
            Yahoo.IgnoreEmptyRows = true;
            try
            {
                var security = await Yahoo.Symbols(symbol).Fields(Field.FiftyTwoWeekHigh, Field.FiftyTwoWeekLow).QueryAsync();
                var ticker = security[symbol];
                var highPrice = ticker[Field.FiftyTwoWeekHigh];
                var lowPrice = ticker[Field.FiftyTwoWeekLow];

                string path = @"C:\Users\Ogi\Desktop\Stock\HighAndLows.txt";
                File.AppendAllText(path, symbol + " - high:" + highPrice + " low:" + lowPrice + "\n");
            }
            catch (Exception ex)
            {
                rtb.Text += ex.Message;
            }
        }

        public static List<string> readAllNames(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string fileContent = reader.ReadToEnd();
                    List<string> allNames = new List<string>();
                    allNames = fileContent.Split(',').ToList();
                    MessageBox.Show(fileContent);
                    return allNames;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
            return null;
        }

        public static async Task writeFile(RichTextBox rtb, string path)
        {
            List<string> allNames = new List<string>();
            allNames = readAllNames(path);

            foreach (var oneName in allNames)
            {
                await getOnePriceAndWrite(oneName, rtb);
            }
        }
    }
}
