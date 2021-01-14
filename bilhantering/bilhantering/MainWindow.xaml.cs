using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

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
            //Skapar upp json-filen första gången programmet körs.
            if (Properties.Settings.Default.FirstRun == true)
            {
                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();

                var temp = JsonConvert.SerializeObject(new List<Bil>());
                File.WriteAllText(@"minabilar.json", temp);

            }

            //Hämtar alla bilar från json-filen och visar dessa i vår lista.
            string jsonFile = File.ReadAllText(@"minabilar.json");
            bilar = JsonConvert.DeserializeObject<List<Bil>>(jsonFile);

            InitializeComponent();


            foreach (var bilen in bilar)
            {
                Listview.Items.Add($"| {bilen.RegNr} | {bilen.Modell} | {bilen.Vikt} | {bilen.Hk} | {bilen.Elbil} |  ");
            }
        }

        private void Spara_Click(object sender, RoutedEventArgs e)
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

                string jsonFile = File.ReadAllText(@"minabilar.json");
                bilar = JsonConvert.DeserializeObject<List<Bil>>(jsonFile);

                bilar.Add(bil);

                string jsonString = JsonConvert.SerializeObject(bilar);
                File.WriteAllText(@"minabilar.json", jsonString);

                Listview.Items.Add($"| {bil.RegNr} | {bil.Modell} | {bil.Vikt}  | {bil.Hk} | {bil.Elbil} |  ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void Tabort_Click(object sender, RoutedEventArgs e)
        {
            if (Listview.SelectedIndex == -1)
                MessageBox.Show("Markera en bil för att ta bort!");

            if (Listview.SelectedIndex > -1)
                Listview.Items.RemoveAt(Listview.SelectedIndex);

        }

        private void CheckboxJa_Checked(object sender, RoutedEventArgs e)
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

        private void CheckboxNej_Checked(object sender, RoutedEventArgs e)
        {
            elbil = false;
        }
    }
}




