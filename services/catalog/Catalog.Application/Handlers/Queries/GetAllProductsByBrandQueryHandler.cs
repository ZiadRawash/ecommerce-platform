using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries
{
	public class GetAllProductsByBrandQueryHandler : IRequestHandler<GetAllProductsByBrandQuery, IList<ProductResponseDto>>
	{
		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;
		public GetAllProductsByBrandQueryHandler(IProductRepository repository, IMapper mapper)
		{
			_mapper = mapper;
			_repository = repository;
		}
		public async Task<IList<ProductResponseDto>> Handle(GetAllProductsByBrandQuery request, CancellationToken cancellationToken)
		{
			var product = await _repository.GetAllProductsByBrand(request.Brand);
			var productResponse = _mapper.Map<IList<Product>, IList<ProductResponseDto>>(product.ToList());	
			return productResponse;
		}
	}
}
