using Marfrig.Application.DTOs.Animais;
using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.Application.DTOs.Pecuaristas;
using Marfrig.WPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marfrig.WPF.ViewModels
{
    public class CompraGadoCadastroViewModel : ViewModelBase
    {
        private readonly CompraGadoInputDTO inputDto;
        private IEnumerable<PecuaristaDTO> pecuaristas;
        private IEnumerable<AnimalDTO> animais;
        private CompraGadoCadastroItemViewModel itemSelecionado;

        public CompraGadoCadastroViewModel()
        {
            inputDto = new CompraGadoInputDTO()
            {
                CompraGadoItens = new List<CompraGadoItemInputDTO>()
            };
            Itens = new ObservableCollection<CompraGadoCadastroItemViewModel>();
        }

        public CompraGadoCadastroViewModel(CompraGadoInputDTO inputDto)
        {
            this.inputDto = inputDto;
            Itens = new ObservableCollection<CompraGadoCadastroItemViewModel>();

            foreach (var item in inputDto.CompraGadoItens)
            {
                Itens.Add(new CompraGadoCadastroItemViewModel(item, this));
            }
        }

        public IEnumerable<PecuaristaDTO> Pecuaristas
        {
            get { return pecuaristas; }
            set
            {
                pecuaristas = value;
                NotifyPropertyChanged();
            }
        }

        public IEnumerable<AnimalDTO> Animais
        {
            get { return animais; }
            set
            {
                animais = value;
                NotifyPropertyChanged();
                foreach (var item in Itens)
                    item.AtualizarAnimais();
            }
        }

        public CompraGadoCadastroItemViewModel ItemSelecionado
        {
            get { return itemSelecionado; }
            set
            {
                itemSelecionado = value;
                NotifyPropertyChanged();
            }
        }

        public int Id => inputDto.Id;
        public ObservableCollection<CompraGadoCadastroItemViewModel> Itens { get; set; }
        public decimal ValorTotal => Itens.Sum(i => i.ValorTotal);

        [Range(1, int.MaxValue, ErrorMessage = "Pecuarista é obrigatório")]
        public int PecuaristaId
        {
            get { return inputDto.PecuaristaId; }
            set
            {
                inputDto.PecuaristaId = value;
                NotifyPropertyChanged();
            }
        }

        [Required(ErrorMessage = "Data de entrega é obrigatório")]
        public DateTime? DataEntrega
        {
            get { return inputDto.DataEntrega == DateTime.MinValue ? (DateTime?)null : inputDto.DataEntrega; }
            set
            {
                if (value != null)
                    inputDto.DataEntrega = value.Value;
                else
                    inputDto.DataEntrega = DateTime.MinValue;

                ValidateProperty(value);
                NotifyPropertyChanged();
            }
        }

        public void RemoverItem(CompraGadoCadastroItemViewModel itemViewModel, CompraGadoItemInputDTO input)
        {
            inputDto.CompraGadoItens.Remove(input);
            Itens.Remove(itemViewModel);
            AtualizarTotal();
        }

        public CompraGadoCadastroItemViewModel InserirItem()
        {
            var novoItemDTO = new CompraGadoItemInputDTO
            {
                CompraGadoId = inputDto.Id,
                Quantidade = 1
            };

            var novoItemViewModel = new CompraGadoCadastroItemViewModel(novoItemDTO, this);

            inputDto.CompraGadoItens.Add(novoItemDTO);
            Itens.Add(novoItemViewModel);

            return novoItemViewModel;
        }

        public void AtualizarTotal()
        {
            NotifyPropertyChanged("ValorTotal");
        }

        private bool Validar()
        {
            Validate();

            var valido = IsValid;

            foreach (var item in Itens)
            {
                item.Validar();
                if (!item.IsValid)
                    valido = false;
            }

            return valido;
        }

        public async Task<CompraGadoInputDTO> Salvar()
        {
            if (!Validar())
                return null;

            CompraGadoInputDTO novaCompra;
            if (inputDto.Id == 0)
                 novaCompra = await new CompraGadoService().CadastrarCompra(inputDto);
            else
                novaCompra = await new CompraGadoService().AtualizarCompra(inputDto);

            return novaCompra;
        }
    }
}
