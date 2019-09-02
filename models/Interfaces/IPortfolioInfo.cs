using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioApi.Models.Interfaces
{
	interface IPortfolioInfo<T>
	{
		void Update(T model);
	}
}
