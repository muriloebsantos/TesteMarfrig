﻿using System.Collections.Generic;

namespace Marfrig.Domain.Entities
{
    public abstract class DomainEntity
    {
        private List<string> validacoes;

        public DomainEntity()
        {
            validacoes = new List<string>();
        }

        public int Id { get; set; }

        protected void AdicionarErroValidacao(string erro)
        {
            validacoes.Add(erro);
        }

        protected void AdicionarErrosValidacao(IReadOnlyList<string> erros)
        {
            validacoes.AddRange(erros);
        }

        public IReadOnlyList<string> Validacoes => validacoes;
    }
}
