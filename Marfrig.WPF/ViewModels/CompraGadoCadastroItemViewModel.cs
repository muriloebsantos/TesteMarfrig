using Marfrig.Application.DTOs.Animais;
using Marfrig.Application.DTOs.ComprasGado;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marfrig.WPF.ViewModels
{
    public class CompraGadoCadastroItemViewModel : ViewModelBase
    {
        private readonly CompraGadoCadastroViewModel viewModelCompra;
        private readonly CompraGadoItemInputDTO inputDTO;

        public CompraGadoCadastroItemViewModel(CompraGadoItemInputDTO inputDTO, CompraGadoCadastroViewModel viewModelCompra)
        {
            this.inputDTO = inputDTO;
            this.viewModelCompra = viewModelCompra;
        }

        
        public IEnumerable<AnimalDTO> Animais => viewModelCompra.Animais;
        public decimal ValorTotal => Quantidade * Preco;

        [Range(1, int.MaxValue, ErrorMessage = "Animal é obrigatório")]
        public int AnimalId
        {
            get { return inputDTO.AnimalId; }
            set
            {
                inputDTO.AnimalId = value;
                NotifyPropertyChanged();
                BuscarPreco();
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Quantidade é obrigatório")]
        public int Quantidade
        {
            get { return inputDTO.Quantidade; }
            set
            {
                inputDTO.Quantidade = value;
                ValidateProperty(value);
                NotifyPropertyChanged();
                AtualizarTotal();
            }
        }

        public decimal Preco
        {
            get { return inputDTO.Preco; }
            private set
            {
                inputDTO.Preco = value;
                NotifyPropertyChanged();
                AtualizarTotal();
            }
        }


        private void BuscarPreco()
        {
            Preco = Animais.FirstOrDefault(a => a.Id == AnimalId).Preco;
        }

        private void AtualizarTotal()
        {
            NotifyPropertyChanged("ValorTotal");
            viewModelCompra.AtualizarTotal();
        }

        public void AtualizarAnimais()
        {
            NotifyPropertyChanged("Animais");
        }

        public bool Validar()
        {
            Validate();

            return IsValid;
        }

        public void Remover()
        {
            viewModelCompra.RemoverItem(this, inputDTO);
        }
    }
}
