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

namespace Progetto_Account
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtNome.Focus();
            txtPassword.Focus();
            txtPrezzo.IsEnabled = false;
            txtQnantità.IsEnabled = false;
            cmbProdotto.IsEnabled = false;
            btnPulisci.IsEnabled = false;
            btnStampa.IsEnabled = false;
            btnRimuovi.IsEnabled = false;
        }
        private const string password = "password";
        private string[] prodotti = new string[] { "felpa", "pantaloni", "scarpe", "cappello", "giubbotto" };
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtNome.Text !="" && txtPassword.Text != "")
            {
                if(txtPassword.Text == password)
                {
                    string utente = txtNome.Text;
                    string pass = txtPassword.Text;

                    txtNome.IsEnabled = false;
                    txtPassword.IsEnabled = false;
                    btnAccedi.IsEnabled = false;

                    txtPassword.IsEnabled = true;
                    txtQnantità.IsEnabled = true;
                    cmbProdotto.IsEnabled = true;
                    btnPulisci.IsEnabled = true;
                    btnPulisci.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("La Password è errata", "Ritenta", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
            MessageBox.Show("Devi inserire le credenziali", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            txtNome.Text = "";
            txtPassword.Text = "";
            txtNome.Focus();
        }

        private void btnPulisci_Click(object sender, RoutedEventArgs e)
        {
            txtQnantità.Text = "";
            txtPrezzo.Text = "";
            cmbProdotto.SelectedIndex = -1;
        }

        private void btnstampa_Click(object sender, RoutedEventArgs e)
        {
            if(txtQnantità.Text != ""  && txtPrezzo.Text !="" && cmbProdotto.SelectedIndex != -1)
            {
                try
                {
                    double quantità = Convert.ToDouble(txtQnantità.Text);
                    double prezzo = Convert.ToDouble(txtPrezzo.Text);

                    double totale = quantità * prezzo;
                    string info = $"il cliente {txtNome.Text} ha acquistato il prodotto {cmbProdotto}";
                    cmbProdotto.Items.Add(info);

                    txtQnantità.Text = "";
                    txtPrezzo.Text = "";
                    cmbProdotto.SelectedIndex = -1;

                    lboAcquisti.IsEnabled = true;
                    btnRimuovi.IsEnabled = true;

                }
                catch (Exception)
                {
                    MessageBox.Show("La topologia dei dati messi è errata", "ERRORE", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Non tutti i dati sono messi", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void CaricaComboPrezzo_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var prod in prodotti)
            {
                cmbProdotto.Items.Add(prod);
            }
        }
        private void btnRimuovi_Click(object sender, RoutedEventArgs e)
        {
            int selezione = cmbProdotto.SelectedIndex;
            if (selezione >= 0)
            {
                cmbProdotto.Items.RemoveAt(selezione);
            }
            else
            {
                MessageBox.Show("Non è stato selezionato nessun elemento");
            }
            if(cmbProdotto.Items.Count == 0)
            {
                cmbProdotto.IsEnabled = false;
                btnRimuovi.IsEnabled = false;
            }
        }

        

    }
}
