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
	public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponseDto>>
	{
		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;
		public GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;		
		}
		public async Task<IList<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			var products = await _repository.GetAllProducts();
			var productList = _mapper.Map<IList<Product>, IList<ProductResponseDto>>(products.ToList());
			return productList;
		}
	}
}
