using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace bilhantering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Bil
    {
        public string RegNr { get; set; }
        public string Modell { get; set; }
        public int Vikt { get; set; }
        public int Hk { get; set; }
        public bool Elbil { get; set; }
    }

    public partial class MainWindow : Window
    {
 
        bool elbil;
        List<Bil> bilar = new List<Bil>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void spara_Click(object sender, RoutedEventArgs e)
        {

            try
            {
               
                Bil bil = new Bil()
                {
                    RegNr = textboxReg.Text,
                    Modell = textboxModell.Text,
                    Vikt = int.Parse(textboxVikt.Text),
                    Hk = int.Parse(textboxHästkrafter.Text),
                    Elbil = elbil
                };

                bilar.Add(bil);

                //Serialize = Ta ett C# objekt och sedan göra det till json.
                string jsonString = JsonConvert.SerializeObject(bilar);
                File.WriteAllText(@"minabilar.json", jsonString);

                //TODO:
                //1. Läs från json-filen (Deserialisera). Se minabilar.json under \bilhantering\bilhantering\bin\Debug -> I debug mappen finns minabilar.json
                //2. Iterera genom arrayen.
                //3. Lägg till de sparade bilarna i ListView. Tips, döp om Listview till något annat. 
                //4. Snygga till listan genom att lägga till kolumnerna Registreringsnummer, Modell, Vikt, Hästkrafter, Elbil

                Listview.Items.Add($"| {bil.RegNr} | {bil.Modell} | {bil.Vikt}  | {bil.Hk} | {bil.Elbil} |  ");

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void tabort_Click(object sender, RoutedEventArgs e)
        {
            if (Listview.SelectedIndex == -1)
                MessageBox.Show("Markera en bil för att ta bort!");

            if (Listview.SelectedIndex > -1)
             Listview.Items.RemoveAt(Listview.SelectedIndex);
            
        }

        private void checkboxJa_Checked(object sender, RoutedEventArgs e)
        {
            elbil = true;
        }


        private void RensaFält_Click(object sender, RoutedEventArgs e)
        {
            textboxReg.Clear();
            textboxModell.Clear();
            textboxVikt.Clear();
            textboxHästkrafter.Clear();


        }

        private void checkboxNej_Checked(object sender, RoutedEventArgs e)
        {
            elbil = false;
        }
    }
}


