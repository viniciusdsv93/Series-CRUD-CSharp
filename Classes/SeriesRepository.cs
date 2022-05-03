using System;
using System.Collections.Generic;
using _21seriesCRUD.Interfaces;

namespace _21seriesCRUD
{
    public class SeriesRepository : IRepository<Serie>
    {
        private List<Serie> seriesList = new List<Serie>();

        public void Delete(int Id)
        {
            seriesList[Id].Delete();
        }

        public void Insert(Serie entity)
        {
            seriesList.Add(entity);
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public Serie ReturnById(int Id)
        {
            return seriesList[Id];
        }

        public List<Serie> ReturnList()
        {
            return seriesList;
        }

        public void Update(int Id, Serie entity)
        {
            seriesList[Id] = entity;
        }
    }
}