using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IMerchandiseService
    {
        Task<MerchandiseDto> GetMerchandise(string id);
        Task<IEnumerable<MerchandiseDto>> GetMerchandises();
        Task SaveMerchandise(MerchandiseDto merchandise);
        Task UpdateMerchandise(MerchandiseDto merchandise);
    }
}
