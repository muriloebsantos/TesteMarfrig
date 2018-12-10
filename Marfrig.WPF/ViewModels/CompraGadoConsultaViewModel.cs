using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.Application.DTOs.Pecuaristas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Marfrig.WPF.ViewModels
{
    public class CompraGadoConsultaViewModel : ViewModelBase
    {
        public CompraGadoConsultaViewModel()
        {
            Paginas = new ObservableCollection<int>();
        }

        private int paginaAtual;
        private int quantidadePaginas;
        private int? id;
        private int? pecuaristaId;
        private DateTime? dataInicio;
        private DateTime? dataFim;
        private IEnumerable<PecuaristaDTO> pecuaristas;
        private ObservableCollection<CompraGadoConsultaDTO> comprasGado;
        private CompraGadoConsultaDTO compraGadoSelecionada;

        public ObservableCollection<int> Paginas { get; set; }
        public delegate void ConsultaNecessariaEventHandler();
        public event ConsultaNecessariaEventHandler ConsultaNecessariaEvent;

        public IEnumerable<PecuaristaDTO> Pecuaristas
        {
            get { return pecuaristas; }
            set
            {
                pecuaristas = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<CompraGadoConsultaDTO> ComprasGado
        {
            get { return comprasGado; }
            set
            {
                comprasGado = value;
                NotifyPropertyChanged();
            }
        }

        public CompraGadoConsultaDTO CompraGadoSelecionada
        {
            get { return compraGadoSelecionada; }
            set
            {
                compraGadoSelecionada = value;
                NotifyPropertyChanged();
                AtualizarEstadoBotoesAcao();
            }
        }

        public int PaginaAtual
        {
            get { return paginaAtual; }
            set
            {
                if (paginaAtual != value)
                {
                    paginaAtual = value;
                    AtualizarEstadoBotoesPaginacao();
                    ConsultaNecessariaEvent?.Invoke();
                    NotifyPropertyChanged();
                }   
            }
        }

        public int QuantidadePaginas
        {
            get { return quantidadePaginas; }
            set
            {
                if (quantidadePaginas != value)
                {
                    quantidadePaginas = value;
                    PreencherNumeroPaginas();
                    AtualizarEstadoBotoesPaginacao();
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("PaginaAtual");
                }
            }
        }

        public int? Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public int? PecuaristaId
        {
            get { return pecuaristaId; }
            set
            {
                pecuaristaId = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? DataInicio
        {
            get { return dataInicio; }
            set
            {
                dataInicio = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? DataFim
        {
            get { return dataFim; }
            set
            {
                dataFim = value;
                NotifyPropertyChanged();
            }
        }

        private void PreencherNumeroPaginas()
        {
            Paginas.Clear();
            for (int i = 1; i <= QuantidadePaginas; i++)
            {
                Paginas.Add(i);
            }
        }

        private void AtualizarEstadoBotoesPaginacao()
        {
            NotifyPropertyChanged("AnteriorEnabled");
            NotifyPropertyChanged("ProximoEnabled");
        }

        public void AtualizarEstadoBotoesAcao()
        {
            NotifyPropertyChanged("ImprimirEnabled");
            NotifyPropertyChanged("AlterarEnabled");
            NotifyPropertyChanged("ExcluirEnabled");
        }

        public void ReiniciarPesquisa()
        {
            paginaAtual = 1;
            ConsultaNecessariaEvent?.Invoke();
        }

        public bool AnteriorEnabled => paginaAtual > 1;
        public bool ProximoEnabled => paginaAtual < quantidadePaginas;
        public bool ImprimirEnabled => compraGadoSelecionada != null;
        public bool AlterarEnabled => compraGadoSelecionada != null && !compraGadoSelecionada.Impressa;
        public bool ExcluirEnabled => compraGadoSelecionada != null && !compraGadoSelecionada.Impressa;

        public bool AoMenosUmFiltroInformado()
        {
            return id > 0 || pecuaristaId > 0 || DataInicio != null || DataFim != null;
        }
    }
}
