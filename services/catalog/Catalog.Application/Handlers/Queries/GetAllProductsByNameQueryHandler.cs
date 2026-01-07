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
	public class GetAllProductsByNameQueryHandler : IRequestHandler<GetAllProductsByNameQuery, IList<ProductResponseDto>>
	{
		private readonly IProductRepository _repository;
		private readonly Mapper _mapper;
		public GetAllProductsByNameQueryHandler(IProductRepository repository, Mapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<IList<ProductResponseDto>> Handle(GetAllProductsByNameQuery request, CancellationToken cancellationToken)
		{
			var products = await _repository.GetAllProductsByBrand(request.Name);
			var productList = _mapper.Map<IList<Product>, IList<ProductResponseDto>>(products.ToList());
			return productList;
		}
	}
}
