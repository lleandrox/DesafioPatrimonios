using patrimonios.domain.Dtos;
using patrimonios.domain.Entities;
using Patrimonios.api.Inputs;
using Patrimonios.dado;
using System;
using System.Collections.Generic;

namespace Patrimonios.Negocio
{
    public class MarcaNegocio
    {
        private readonly MarcaRepository _marcaRepositorio;

        public MarcaNegocio()
        {
            _marcaRepositorio = new MarcaRepository();
        }
        public Marca Alterar(int id, Marca input)
        {
           
            var retorno = _marcaRepositorio.SelecionarPorId(id);

            input.MarcaId = id;
            _marcaRepositorio.Alterar(input);

            return _marcaRepositorio.SelecionarPorId(id);
        }

        public void Deletar(int id)
        {
            _marcaRepositorio.Deletar(id);
        }

        public int Inserir(MarcaInput input)
        {
            var retorno = _marcaRepositorio.Selecionar();

            foreach (var item in retorno)
            {
                if (input.Nome == item.Nome)
                {
                    throw new Exception("Nome da marca já existe");
                } 
            }
          
            var objMarca = new Marca()
            {
                    Nome = input.Nome
            };
            
            return _marcaRepositorio.Inserir(objMarca);
        }

        public IEnumerable<Marca> Selecionar()
        {
            return _marcaRepositorio.Selecionar();
        }

        public Marca SelecionarPorId(int id)
        {
          var obj  = _marcaRepositorio.SelecionarPorId(id);

            return obj;
        }
        public IEnumerable<MarcaDto> SelecionarPatrimonioPorMarcaId(int Id)
        {
            var obj = _marcaRepositorio.SelecionarPatrimonioPorMarcaId(Id);

            return obj;
        }
    }
}
