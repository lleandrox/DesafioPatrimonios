using patrimonios.domain.Dtos;
using patrimonios.domain.Entities;
using Patrimonios.api.Inputs;
using Patrimonios.dado;
using Patrimonios.Negocio.Abstracao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patrimonios.Negocio
{
    public class PatrimonioNegocio 
    {
        private readonly PatrimonioRepository _patrimonioRepository;

        public PatrimonioNegocio()
        {
            _patrimonioRepository = new PatrimonioRepository();
        }

        public Patrimonio Alterar(int id, Patrimonio input)
        {
            var retorno = _patrimonioRepository.SelecionarPorId(id);

            input.PatrimonioId = id;
            _patrimonioRepository.Alterar(input);

            return _patrimonioRepository.SelecionarPorId(id);
        }

        public void Deletar(int id)
        {
            _patrimonioRepository.Deletar(id);
        }

        public int Inserir(PatrimonioInput input)
        {
            Random numeroAleatorio = new Random();
            int valor = numeroAleatorio.Next(1, 10000);
            
            var objPatrimonio = new Patrimonio()
            {
                Nome = input.Nome,
                MarcaId = input.MarcaId,
                Descricao = input.Descricao,
                NumeroTombo = valor,
            };

            return _patrimonioRepository.Inserir(objPatrimonio);
        }

        public IEnumerable<Patrimonio> Selecionar()
        {
            return _patrimonioRepository.Selecionar();
        }

        public Patrimonio SelecionarPorId(int id)
        {
            var obj = _patrimonioRepository.SelecionarPorId(id);

            return obj;
        }
    }
}
