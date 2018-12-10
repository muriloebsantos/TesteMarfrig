using Marfrig.Application.DTO.ComprasGado;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
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

namespace Marfrig.WPF
{
    /// <summary>
    /// Interaction logic for RelatorioCompraPage.xaml
    /// </summary>
    public partial class RelatorioCompraPage : Page
    {
        public RelatorioCompraPage(CompraGadoRelatorioDTO relatorioDTO)
        {
            InitializeComponent();
            CarregarDadosRelatorio(relatorioDTO);
            CarregarRelatorio();
        }

        private void CarregarDadosRelatorio(CompraGadoRelatorioDTO relatorioDTO)
        {
            var dados = new Dictionary<string, IEnumerable>();

            dados.Add("Compra", new List<CompraGadoCabecalhoRelatorioDTO> { relatorioDTO.Cabecalho } );
            dados.Add("CompraItem", relatorioDTO.Itens);

            foreach (var dado in dados)
            {
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = dado.Key; //nome do DataSet no .rdlc
                reportDataSource.Value = dado.Value; // objeto(lista) de dados
                reportViewer.LocalReport.DataSources.Add(reportDataSource);
            }
        }

        private void CarregarRelatorio()
        {
            //carrega o relatorio que deve estar na pasta do executavel. o arquivo rdlc deve estar CopyToLocal
            reportViewer.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + @"Relatorios\ImpressaoCompra.rdlc";
            reportViewer.RefreshReport();
        }
    }
}
