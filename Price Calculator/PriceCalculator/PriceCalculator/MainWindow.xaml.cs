using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

/// <summary>
/// Members: Ashley Gellert, Tahira Mursleen, Abhinav Pathak, Parmeet Singh, Haoyang Zhang
/// 
/// !!!!IMPORTANT!!!! This requires a NuGet in order to install
/// Installion
/// 1. Right click on 'Price Calculator' in the Solution Menu
/// 2. Manage NuGet Packages...
/// 3. Browse for Newtonsoft.Json
/// 4. Install
/// </summary>
namespace Price_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //switches between the themes
        private Theme _theme = Theme.light;

        enum Theme
        {
            dark,
            light,
        }

        /// <summary>
        /// loads xaml file and converts it to an instance of the obj
        /// </summary>
        private void DarkTheme_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary rd;
            rd = Application.LoadComponent(new Uri("DarkTheme.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
            _theme = Theme.dark;
            Application.Current.Resources = rd;
        }

        private void LightTheme_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary rd;
            rd = Application.LoadComponent(new Uri("LightTheme.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
            _theme = Theme.light;
            Application.Current.Resources = rd;
        }

        private Ledger ledger;

        ///<summary>
        ///Gets the path of current user's desktop using environment.specialfolder path and appends name of the json file
        ///</summary>

        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/ledger.json";

        public object JsonSerializer { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            ///<summary>
            ///This currently creates JSON file on desktop if file not found
            ///</summary>
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader r = new StreamReader(path))
                    {
                        string json = r.ReadToEnd();
                        ledger = JsonConvert.DeserializeObject<Ledger>(json);
                        if (ledger != null)
                        {
                            r.Close();
                            PrittifyText();
                            ClearButton.IsEnabled = true;
                        }
                        else
                        {
                            ledger = new Ledger();
                        }
                    }
                }
                catch (Exception entry)
                {
                    MessageBox.Show(messageBoxText: "no JSON file found" + entry.Message);
                }
            }
            else
            {
                ledger = new Ledger();
            }
        }

        private void Btn_Calculate(object sender, RoutedEventArgs e)
        {
            ///<summary>
            /// bill instance will contain the converted string to int that will
            /// pass price to Bill and passes the calculated price to the view (total_with_tax)
            /// </summary>
            if (Price.Text != "" && Tip.Text != "" && Tax.Text != "")
            {
                Bill bill = new Bill(
                    Math.Round(
                    Decimal.Parse(Price.Text), 2), 
                    Decimal.Parse(Tip.Text), 
                    Decimal.Parse(Tax.Text), 
                    Restaurant.Text, 
                    DateTime.Now.ToString());
                Total_With_Tax.Text = bill.Total.ToString();
                ledger.Add(bill);
            }
            else
            {
                MessageBox.Show("Please Enter All The Values.", "Error");
            }
        }

        //saves the desired user data to the JSON file
        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            ClearButton.IsEnabled = true;
            PrittifyText();

            string jsonLedger = JsonConvert.SerializeObject(ledger);

            //clear textboxes after saving data
            Price.Text = "0";
            Total_With_Tax.Text = "";
            Tip.Text = "15";
            Tax.Text = "7";
            Restaurant.Text = "";

            try
            {
                using (StreamWriter outputFile = new StreamWriter(path, false))
                {
                    outputFile.Write(jsonLedger);
                }
            }
            catch (Exception entry)
            {
                MessageBox.Show(entry.Message, "Warning: No file found", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //reduces the length of the stream of byte to 0
        //Note: any file must be closed after it is opened because of security and to free the stream for other operations
        private void Btn_Clear(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path))
            {
                FileStream fileStream = File.Open(path, FileMode.Open);
                fileStream.SetLength(0);
                fileStream.Close();

                SavedLedger.Text = "";

                ledger = new Ledger();
            }
            ClearButton.IsEnabled = false;
        }

        //this displays a JSON string in a legible format
        private void PrittifyText()
        {
            string savedBills = "";
            foreach (Bill bill in ledger)
            {
                savedBills = string.Concat(savedBills, 
                    "Resturant Name: " + bill.Resturant + Environment.NewLine + 
                    "Price: " + bill.Price + Environment.NewLine + 
                    "Total: " + bill.Total + Environment.NewLine  + 
                    "Date: " + bill.Date + 
                    Environment.NewLine + Environment.NewLine);
            }
            SavedLedger.Text = savedBills;
        }

        //splices string after decimal
        private void Price_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Price.Text.Contains("."))
            {
                decimal splice = decimal.Parse(Price.Text);
                splice = Math.Round(splice, 2);

                Price.Text = splice.ToString();
            }
        }

        private void Tip_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            decimal splice = decimal.Parse(Tip.Text);
            splice = Math.Round(splice, 2);

            Tip.Text = splice.ToString();
        }

        private void Tax_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            decimal splice = decimal.Parse(Tax.Text);
            splice = Math.Round(splice, 2);

            Tax.Text = splice.ToString();
        }

        private void Price_GotFocus(object sender, RoutedEventArgs e)
        {
            Price.Text = "";
        }

        //allows only numbers and decimal to be entered into textbox
        //allows only one decimal within textbox
        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char ch = e.Text[0];

            if (!Char.IsDigit(ch))
            {
                if (ch == '.')
                {
                    if (Price.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void Tip_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char ch = e.Text[0];

            if (!Char.IsDigit(ch))
            {
                if (ch == '.')
                {
                    if (Tip.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void Tax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char ch = e.Text[0];

            if (!Char.IsDigit(ch))
            {
                if (ch == '.')
                {
                    if (Tax.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
