using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.WPF.Services;
using Marfrig.WPF.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Marfrig.WPF
{
    /// <summary>
    /// Interaction logic for CompraGadoConsultaPage.xaml
    /// </summary>
    public partial class CompraGadoConsultaPage : Page
    {
        private readonly CompraGadoConsultaViewModel viewModel;
        private bool loaded;

        public CompraGadoConsultaPage()
        {
            InitializeComponent();
            viewModel = new CompraGadoConsultaViewModel();
            viewModel.ConsultaNecessariaEvent += ViewModel_ConsultaNecessariaEvent;
            DataContext = viewModel;
            Loaded += CompraGadoConsultaPage_Loaded;
        }

        private async void CompraGadoConsultaPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!loaded)
            {
                await CarregarComboboxes();
                progressRing.IsActive = false;
                loaded = true;
            }
        }

        private async void ViewModel_ConsultaNecessariaEvent()
        {
            await Pesquisar();
        }

        private async Task CarregarComboboxes()
        {
            await CarregarPecuaristas();
        }

        private async Task Pesquisar()
        {
            try
            {
                if (!viewModel.AoMenosUmFiltroInformado())
                {
                    MessageBox.Show("Ao menos um filtro deve ser informado.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                    return;
                }

                progressRing.IsActive = true;
                btnPesquisar.IsEnabled = false;

                var comprasGado = await new CompraGadoService().ObterComprasGado(viewModel);

                viewModel.QuantidadePaginas = comprasGado.TotalPages;
                viewModel.PaginaAtual = comprasGado.CurrentPage;
                viewModel.ComprasGado = new ObservableCollection<CompraGadoConsultaDTO>(comprasGado.Data);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao consultar compras");
            }
            finally
            {
                progressRing.IsActive = false;
                btnPesquisar.IsEnabled = true;
            }
        }

        private async Task CarregarPecuaristas()
        {
            try
            {
                viewModel.Pecuaristas = await new PecuaristaService().ObterPecuaristas();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao carregar pecuaristas", "Erro", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ReiniciarPesquisa();
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PaginaAtual--;
        }

        private void btnProximo_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PaginaAtual++;
        }

        private async void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(MessageBox.Show("Deseja excluir a compra selecionada?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
                {
                    return;
                }

                progressRing.IsActive = true;

                var excluiu = await new CompraGadoService().ExcluirCompra(viewModel.CompraGadoSelecionada.Id);

                if (excluiu)
                {
                    viewModel.ComprasGado.Remove(viewModel.CompraGadoSelecionada);
                    MessageBox.Show("Excluído com sucesso", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }
                else
                {
                    MessageBox.Show("Não foi possível excluir", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao excluir", "Erro", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            finally
            {
                progressRing.IsActive = false;
            }
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            App.TelaPrincipal().AdicionarTab("Nova Compra", new CompraGadoCadastroPage());
        }

        private async void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                progressRing.IsActive = true;
                var compra = await new CompraGadoService().ObterCompra(viewModel.CompraGadoSelecionada.Id);
                App.TelaPrincipal().AdicionarTab($"Compra de Gado({compra.Id})", new CompraGadoCadastroPage(compra));
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao carregar compra", "Erro", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            finally
            {
                progressRing.IsActive = false;
            }
        }
    }
}
