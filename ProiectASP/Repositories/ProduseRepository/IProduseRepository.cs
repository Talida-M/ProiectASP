using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ProduseRepository
{
    public interface IProduseRepository : IGenericRepository<Produse>
    {
            Task<Produse> GetByName(string nume); //ok
            Task<Produse> GetByIdP(int id); //ok
            Task<List<Produse>> GetAllProduse(); //ok
            Task<List<Produse>> GetAllProduseWithPriceSorted(); //ruleaza dar nu afis
          //  Task<Produse> GetByIdWithImprimanta();


    }
}
