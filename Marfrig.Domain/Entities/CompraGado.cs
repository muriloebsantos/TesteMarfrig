using System;
using System.Collections.Generic;
using System.Linq;

namespace Marfrig.Domain.Entities
{
    public class CompraGado : DomainEntity
    {
        public DateTime DataEntrega { get; set; }
        public int PecuaristaId { get; set; }
        public virtual Pecuarista Pecuarista { get; set; }
        public virtual ICollection<CompraGadoItem> CompraGadoItens { get; set; }

        public bool PodeSalvar()
        {
            var podeSalvar = true;

            if (!InformouDataValida())
                podeSalvar = false;

            if (!InformouPecuarista())
                podeSalvar = false;

            if (!InformouAoMenosUmItem())
                podeSalvar = false;

            if (!NaoHaItensRepetidos())
                podeSalvar = false;

            return podeSalvar; 
        }

        public bool InformouDataValida()
        {
            if (DataEntrega == DateTime.MinValue)
            {
                AdicionarErroValidacao("A data da compra não foi informada.");
                return false;
            }
            return true;
        }

        public bool InformouPecuarista()
        {
            if(PecuaristaId == 0)
            {
                AdicionarErroValidacao("O pecuarista não foi informado.");
                return false;
            }
            return true;
        }

        public bool InformouAoMenosUmItem()
        {
            if(CompraGadoItens?.Count == 0)
            {
                AdicionarErroValidacao("Nenhum item foi adicionado.");
                return false;
            }
            return true;
        }

        public bool NaoHaItensRepetidos()
        {
            if (CompraGadoItens?.Count == 0)
                return true;

            var qtdeItens = CompraGadoItens.Count;
            var itensAgrupadosPorAnimal = CompraGadoItens.GroupBy(i => i.AnimalId);
            var qtdeGrupos = itensAgrupadosPorAnimal.Count();
            
            if(qtdeItens != qtdeGrupos)
            {
                AdicionarErroValidacao("Há itens repetidos.");
                return false;
            }

            return true;
        }
    }
}
