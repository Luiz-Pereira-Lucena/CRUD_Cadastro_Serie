using CRUDCadatro.Interfaces;
using System;
using System.Collections.Generic;

namespace CRUDCadatro
{
    class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            //Colocar o objeto na posição do vetor
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            //Exclui informação do vetor, mas não exclui o vetor
            listaSerie[id].Exclui();
        }

        public void Insere(Serie objeto)
        {
            //Método Add para adcionar
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            //Retorna toda a lista
            return listaSerie;
        }

        public int ProximoId()
        {
            //retorna o próximo começando da posição zero
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int Id)
        {
            //Retornando a serie que esta na posição do Id informado
            return listaSerie[Id];
        }
    }
}
