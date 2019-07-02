using CrmCore.Application.FirmaKontakServices.Dto;
using CrmCore.Core.Firma;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrmCore.Application.FirmaKontakServices
{
    public interface IFirmaKontakService
    {
        Task<List<FirmaKontak>> GetAll();
        Task<List<FirmaKontak>> GetAllByIdAsync(int firmaId);
        //Task<List<FirmaKontak>> GetAllByOwner(string userId);
        Task<FirmaKontak> GetAsync(int id);
        Task<FirmaKontak> CreateAsync(CreateFirmaKontak input);
        Task<FirmaKontak> UpdateAsync(UpdateFirmaKontak input);
        Task DeleteAsync(int id);
    }
}
