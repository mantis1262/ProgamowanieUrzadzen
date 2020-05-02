using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface IMerchandiseService
    {
        MerchandiseDto GetMerchandise(string id);
        IEnumerable<MerchandiseDto> GetMerchandises();
    }
}
