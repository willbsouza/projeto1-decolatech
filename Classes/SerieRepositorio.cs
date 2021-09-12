using System;
using System.Collections.Generic;
using DIO.CadastroSeries.Interfaces;

namespace DIO.CadastroSeries
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> Series = new List<Serie>();

        public void Atualizar(int id, Serie obj)
        {
            Series[id] = obj;
        }

        public void Excluir(int id)
        {
            Series[id].ExcluirBoolean();
        }

        public void Inserir(Serie obj)
        {
            Series.Add(obj);
        }

        public List<Serie> Listar()
        {
            return Series;
        }
        public int ProximoId()
        {
            return Series.Count;
        }

        public Serie RetornarPorId(int id)
        {
            return Series[id];
        }
    }
}