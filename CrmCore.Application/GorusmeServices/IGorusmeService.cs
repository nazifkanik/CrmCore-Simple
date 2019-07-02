using CrmCore.Application.GorusmeServices.Dto;
using CrmCore.Core.Firma;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrmCore.Application.GorusmeServices
{
    public interface IGorusmeService
    {
        Task<List<Gorusme>> GetAll();
        Task<List<Gorusme>> GetAllByIdAsync(int firmaId);
        //Task<List<FirmaKontak>> GetAllByOwner(string userId);
        Task<Gorusme> GetAsync(int id);
        Task<Gorusme> CreateAsync(CreateGorusme input);
        Task<Gorusme> UpdateAsync(UpdateGorusme input);
        Task DeleteAsync(int id);
    }
}
