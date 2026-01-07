using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries
{
	public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponseDto>
	{
		private readonly IProductRepository _repository;
		private readonly Mapper _mapper;
		public GetProductByIdQueryHandler(IProductRepository repository, Mapper mapper)
		{
			_mapper=mapper;
			_repository = repository;
		}
		public async Task<ProductResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			var product = await _repository.GetProductById(request.Id);
			var productReturn = _mapper.Map<ProductResponseDto>(product);
			return productReturn;
		}
	}
}
