using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
	public class GetAllProductsByBrandQuery:IRequest<IList<ProductResponseDto>>
	{
		public string Brand { get; set; }
		public GetAllProductsByBrandQuery(string brand)
		{
			Brand = brand;
			
		}
	}
}
