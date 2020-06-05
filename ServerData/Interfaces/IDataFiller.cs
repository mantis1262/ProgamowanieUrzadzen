using System;
using System.Collections.Generic;
using System.Text;

namespace ServerData.Interfaces
{
    public interface IDataFiller
    {
        void Fill(DataContext dataContext);
    }
}
