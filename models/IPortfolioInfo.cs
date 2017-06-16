using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioApi.Models
{
    interface IPortfolioInfo<T>
    {
        void Update(T model);
    }
}
