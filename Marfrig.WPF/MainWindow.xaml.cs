using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Marfrig.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public ObservableCollection<TabItem> Tabs { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Tabs = new ObservableCollection<TabItem>();
            tabControlTelas.ItemsSource = Tabs;
        }

        private void menuNovaCompraGado_Click(object sender, RoutedEventArgs e)
        {
            AdicionarTab("Nova Compra", new CompraGadoCadastroPage());
        }

        private void menuNovaConsultaCompraGado_Click(object sender, RoutedEventArgs e)
        {
            AdicionarTab("Consulta de Compras", new CompraGadoConsultaPage());
        }

        public void AdicionarTab(string header, Page pagina)
        {
            var tab = new MetroTabItem
            {
                Header = header,
                Content = new Frame { Content = pagina },
                CloseButtonEnabled = true
            };

            Tabs.Add(tab);
            tabControlTelas.SelectedItem = tab;
        }

        public void RemoverTab(Page page)
        {
            var frame = page.TryFindParent<Frame>();
            var tab = frame.Parent as TabItem;
            Tabs.Remove(tab);
        }

    }
}
