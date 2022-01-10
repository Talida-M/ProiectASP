using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ImprimanteFilamenteRepository
{
    public class ImprimanteFilamentRepository : GenericRepository<ImprimanteFilament>, IImprimanteFilamentRepository
    {

        public ImprimanteFilamentRepository(Context context) : base(context) { }


        public async Task<List<ImprimanteFilament>> GetAllImprimanteFilamente()
        {
            return await _context.ImprimanteFilament.ToListAsync();
        }
        public async Task<ImprimanteFilament> GetByIdFilament(int idF)
        {
            return await _context.ImprimanteFilament.Where(a => a.IdFilament.Equals(idF)).FirstOrDefaultAsync();

        }
        public async Task<ImprimanteFilament> GetByIdImprimants(int idI)
        {
            return await _context.ImprimanteFilament.Where(a => a.IdFilament.Equals(idI)).FirstOrDefaultAsync();

        }

        /////Sa se afiseze numele produsului si numele imprimantei compatibile

        //public async IEnumerable<> GetProdusSiImprimantaSiTipFilament(int codF)
        //{
        //    return await _context.ImprimanteFilament
        //        .GroupJoin(_context.Imprimante, _context.Produse, _context.Filament,
        //         prod => prod.IdFilament,
        //         filament => filament.IdFilament,
        //         impFlm => impFlm.IdFilament,
        //         imp => imp.IdImprimanta,
        //         (prod, filament, impFlm, imp) => new
        //         {
        //             IdFilament = impFlm.IdFilament,
        //             Nume = prod.Nume,
        //             TipFilament = filament.TipFilament,
        //             Nume = imp.Nume
        //         }
        //         )
        //         .Where(a => a.IdFilament == codF)
        //         .ToListAsync();
        //}
    }
}
