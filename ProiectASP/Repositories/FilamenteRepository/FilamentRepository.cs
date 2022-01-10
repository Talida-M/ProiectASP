using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.FilamenteRepository
{
    public class FilamentRepository : GenericRepository<Filament>, IFilamentRepository
    {

        public FilamentRepository(Context context) : base(context) { }

        public async Task<List<Filament>> GetAllFilamente()
        {
            return await _context.Filament.ToListAsync();

        }


        public async Task<List<Filament>> GetAllFilamentByGramajDesc()
        {
            return  await _context.Filament
                //.Include(a => a.Produse)
                .OrderByDescending(a => a.Gramaj).ToListAsync();
            
        }


        public async Task<Filament> GetByTipFilament(string tip)
        {
            return await _context.Filament.Where(a => a.TipFilament.Equals(tip)).FirstOrDefaultAsync();
        }

        public async Task<IActionResult> GetInformatii(int idF)
        {
            var filamente = _context.Filament;
            var join = await _context.Produse.Join(filamente,
                       p => p.IdProdus,
                       f => f.IdFilament,
                       (p, f) => new
                       {
                           p.Nume,
                           p.CostProducere,
                           f.TipFilament,
                           f.IdFilament,
                           dif = (100 * p.CantitateFilament) / f.Gramaj
                       }).Where(d => d.IdFilament == idF).ToListAsync();
            return (IActionResult)join;
        }

    }
}
