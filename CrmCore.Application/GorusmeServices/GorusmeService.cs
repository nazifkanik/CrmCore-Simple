using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmCore.Application.GorusmeServices.Dto;
using CrmCore.Core.Firma;
using CrmCore.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CrmCore.Application.GorusmeServices
{
    public class GorusmeService : IGorusmeService
    {
        private ApplicationUserDbContext _context;
        public GorusmeService(ApplicationUserDbContext context)
        {
            _context = context;
        }

        public async Task<List<Gorusme>> GetAll()
        {
            var list = await _context.Gorusmeler
                .ToListAsync();
            return list;
        }

        public async Task<List<Gorusme>> GetAllByIdAsync(int firmaId)
        {
            //kontakId nasıl eklenecek?...
            List<Gorusme> result = await _context.Gorusmeler
                .Where(x => x.FirmaId == firmaId)
                .Include(y => y.Firma)
                .ToListAsync();
            return result;
        }

        public async Task<Gorusme> GetAsync(int id)
        {
            //kontakId nasıl eklenecek?...
            return await _context.Gorusmeler.FindAsync(id);
        }

        public async Task<Gorusme> CreateAsync(CreateGorusme input)
        {
            var item = Gorusme.Create(input.Konu, input.Detay, input.FirmaId, input.FirmaKontakId, input.CreatorUserId);

            await _context.Gorusmeler.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Gorusme> UpdateAsync(UpdateGorusme input)
        {
            var willUpdate = await GetAsync(input.Id);
            willUpdate.Konu = input.Konu;
            willUpdate.Detay = input.Detay;

            _context.Gorusmeler.Update(willUpdate);
            await _context.SaveChangesAsync();
            return willUpdate;
        }

        public async Task DeleteAsync(int id)
        {
            var willDeleted = await GetAsync(id);
            _context.Gorusmeler.Remove(willDeleted);
            await _context.SaveChangesAsync();
        }
    }
}
