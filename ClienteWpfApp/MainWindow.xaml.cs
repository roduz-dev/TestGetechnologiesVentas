using ClienteWpfApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClienteWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        List<Persona> listPersonas = new List<Persona>();
        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:7004/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            GetPersonas();
        }

        private async void GetPersonas()
        {
            var response = await client.GetStringAsync("Directorio/findPersonas");
            var personas = JsonConvert.DeserializeObject<List<Persona>>(response);
            listPersonas = personas;
            dgPersonas.DataContext = listPersonas;
        }

        private async void SavePersona(Persona persona)
        {
            var response = await client.PostAsJsonAsync("Directorio/storePersona", persona);
            listPersonas.Add(persona);
            dgPersonas.DataContext = null;
            dgPersonas.DataContext = listPersonas;
            dgPersonas.UpdateLayout();
        }

        private void btnEnviarPersona_Click(object sender, RoutedEventArgs e)
        {
            Persona persona = new Persona()
            {
                nombre = txtNombre.Text,
                apellidoPaterno = txtApPaterno.Text,
                apellidoMaterno = txtApMaterno.Text,
                identificacion = txtIdentificacion.Text
            };

            SavePersona(persona);
        }
    }
}