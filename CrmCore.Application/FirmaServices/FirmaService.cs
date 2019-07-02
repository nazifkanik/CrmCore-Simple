using CrmCore.Core.Firma;
using CrmCore.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmCore.Application
{
    public class FirmaService : IFirmaService
    {
        private ApplicationUserDbContext _context;
        public FirmaService(ApplicationUserDbContext context)
        {
            _context = context;
        }

        public async Task<List<Firma>> GetAll()
        {
            var list = await _context.Firmalar
                .ToListAsync();
            return list;
        }

        public async Task<List<Firma>> GetAllByOwner(string userId)
        {
            var list = await _context.Firmalar
                .Where(x => x.CreatorUserId == userId).ToListAsync();
            return list;
        }

        public async Task<Firma> Get(int id)
        {
            var item = await _context
                .Firmalar
                .Where(x => x.Id == id)
            //    .Include(x => x.BazaarListItems)
                .FirstOrDefaultAsync();
            return item;
        }

        public async Task<Firma> Create(CreateFirma input)
        {
            Firma newFirma = Firma.Create(input.Adi, input.WebSitesi,input.EPosta,input.Telefon, input.Adres, input.FaturaAdresi, input.CreatorUserId);
            await _context.Firmalar.AddAsync(newFirma);
            await _context.SaveChangesAsync();
            return newFirma;
        }

        public async Task<Firma> Update(UpdateFirma input)
        {
            var updateFirma = await Get(input.Id);
            updateFirma.Adi = input.Adi;
            //updateBazaarList.Description = input.Description;
            _context.Firmalar.Update(updateFirma);
            await _context.SaveChangesAsync();
            return updateFirma;
        }

        public async Task Delete(int id)
        {
            var item = await Get(id);
            _context.Firmalar.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
