using CrmCore.Core.Firma;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrmCore.Application
{
    public interface IFirmaService
    {
        Task<List<Firma>> GetAll();
        //Task<List<FirmaKontak>> GetAllByIdAsync(int firmaId);
        Task<List<Firma>> GetAllByOwner(string userId);

        Task<Firma> Get(int id);

        Task<Firma> Create(CreateFirma input);

        Task<Firma> Update(UpdateFirma input);

        Task Delete(int id);

    }
}
