using System.Windows;

namespace LoginWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Utenti utenti;
        public MainWindow()
        {
            InitializeComponent();
            string jsonPath = @"..\..\..\dati.json";
            utenti = new Utenti(jsonPath);
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Password;

            if (utenti.AutenticaUtente(username, password))
                MessageBox.Show("Login effettuato con successo.");
            else
                MessageBox.Show("L'utente non esiste nell'elenco di tutti gli utenti registrati.");

            usernameText.Clear();
            passwordText.Clear();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            string name = nameText1.Text;
            string surname = surnameText1.Text;
            string username = usernameText1.Text;
            string password = passwordText1.Password;

            if (utenti.RegistraUtente(name, surname, username, password))
                MessageBox.Show("Registrazione effettuata con successo.");
            else
                MessageBox.Show("Non è stato possibile effettuare la registrazione.");

            nameText1.Clear();
            surnameText1.Clear();
            usernameText1.Clear();
            passwordText1.Clear();
        }
    }
}
