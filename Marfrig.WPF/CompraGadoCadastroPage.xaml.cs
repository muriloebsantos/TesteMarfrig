using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.WPF.Services;
using Marfrig.WPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Marfrig.WPF
{
    /// <summary>
    /// Interaction logic for CompraGadoCadastroPage.xaml
    /// </summary>
    public partial class CompraGadoCadastroPage : Page
    {
        private CompraGadoCadastroViewModel viewModel;
        private bool loaded;
        public CompraGadoCadastroPage(CompraGadoInputDTO compraDTO = null)
        {
            InitializeComponent();

            if (compraDTO == null)
                viewModel = new CompraGadoCadastroViewModel();
            else
                viewModel = new CompraGadoCadastroViewModel(compraDTO);

            DataContext = viewModel;
            Loaded += CompraGadoCadastroPage_Loaded;
        }

        private async void CompraGadoCadastroPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!loaded)
            {
                await CarregarComboBoxes();
                progressRing.IsActive = false;
                loaded = true;
            }
        }

        private async Task CarregarComboBoxes()
        {
            await CarregarPecuaristas();
            await CarregarAnimais();
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

        private async Task CarregarAnimais()
        {
            try
            {
                viewModel.Animais = await new AnimalService().ObterAnimais();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao carregar animais", "Erro", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            var novoItem = viewModel.InserirItem();
            dgrItens.ScrollIntoView(novoItem);
            dgrItens.SelectedItem = novoItem;
        }

        private async void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                progressRing.IsActive = true;
                btnSalvar.IsEnabled = false;

                var novaCompa = await viewModel.Salvar();

                if (novaCompa != null)
                {
                    viewModel = new CompraGadoCadastroViewModel(novaCompa);
                    DataContext = viewModel;
                    await CarregarComboBoxes();
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            finally
            {
                progressRing.IsActive = false;
                btnSalvar.IsEnabled = true;
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ItemSelecionado.Remover();
        }
    }
}
