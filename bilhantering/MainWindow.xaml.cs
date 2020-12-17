using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        string reg = "";
        string modell = "";
        int vikt;
        int hk;
        string elbil;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void spara_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                reg = textboxReg.Text;
                modell = textboxModell.Text;
                vikt = int.Parse(textboxVikt.Text);
                hk = int.Parse(textboxHästkrafter.Text);
               
                Listview.Items.Add($"| {reg} | {modell} | {vikt}  | {hk} | {elbil} |  ");
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

            elbil = "Elbil";
              
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
            elbil = "Inte Elbil";
        }
    }
}


