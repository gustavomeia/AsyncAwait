using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfExemplo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            lblTitulo.Content = $"Calculando quantidade - Thread:{Thread.CurrentThread.ManagedThreadId}";

            var clientesId = await ConsultaQuantidadeClientesAsync();

            lblTitulo.Content = $"Total de {clientesId} clientes - Thread: {Thread.CurrentThread.ManagedThreadId}";
        }

        public async Task<int> ConsultaQuantidadeClientesAsync()
        {
            await Task.Delay(2_000);
            return 8;
        }
    }
}
