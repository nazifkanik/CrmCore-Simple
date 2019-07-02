using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmCore.Application.FirmaKontakServices.Dto;
using CrmCore.Core.Firma;
using CrmCore.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CrmCore.Application.FirmaKontakServices
{
    public class FirmaKontakService : IFirmaKontakService
    {
        private ApplicationUserDbContext _context;
        public FirmaKontakService(ApplicationUserDbContext context)
        {
            _context = context;
        }

        public async Task<List<FirmaKontak>> GetAll()
        {
            var list = await _context.FirmaKontaklar
                .ToListAsync();
            return list;
        }

        public async Task<List<FirmaKontak>> GetAllByIdAsync(int firmaId)
        {
            List<FirmaKontak> result = await _context.FirmaKontaklar
                .Where(x => x.FirmaId == firmaId)
                .Include(y => y.Firma)
                .ToListAsync();
            return result;
        }

        public async Task<FirmaKontak> GetAsync(int id)
        {
            return await _context.FirmaKontaklar.FindAsync(id);
        }

        public async Task<FirmaKontak> CreateAsync(CreateFirmaKontak input)
        {
            var item = FirmaKontak.Create(input.AdiSoyadi, input.Telefon, input.EPosta, input.FirmaId, input.CreatorUserId);

            await _context.FirmaKontaklar.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<FirmaKontak> UpdateAsync(UpdateFirmaKontak input)
        {
            var willUpdate = await GetAsync(input.Id);
            willUpdate.AdiSoyadi = input.AdiSoyadi;
            willUpdate.Telefon = input.Telefon;
            willUpdate.EPosta = input.EPosta;

            _context.FirmaKontaklar.Update(willUpdate);
            await _context.SaveChangesAsync();
            return willUpdate;

        }

        public async Task DeleteAsync(int id)
        {
            var willDeleted = await GetAsync(id);
            _context.FirmaKontaklar.Remove(willDeleted);
            await _context.SaveChangesAsync();
        }
    }
}