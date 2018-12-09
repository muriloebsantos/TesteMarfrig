namespace Marfrig.Domain.Entities
{
    public class CompraGadoItem : DomainEntity
    {
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int CompraGadoId { get; set; }
        public int AnimalId { get; set; }
        public  virtual CompraGado CompraGado { get; set; }
        public virtual Animal Animal { get; set; }

        public bool PodeSalvar()
        {
            var podeSalvar = true;

            if (!InformouQuantidadeValida())
                podeSalvar = false;

            if (!InformouAnimal())
                podeSalvar = false;

            return podeSalvar;
        }

        public bool InformouQuantidadeValida()
        {
            if(Quantidade <= 0)
            {
                AdicionarErroValidacao("A quantidade do item deve ser maior que zero.");
                return false;
            }
            return true;
        }

        public bool InformouAnimal()
        {
            if(AnimalId == 0)
            {
                AdicionarErroValidacao("O animal deve ser informado.");
                return false;
            }
            return true;
        }
    }
}
