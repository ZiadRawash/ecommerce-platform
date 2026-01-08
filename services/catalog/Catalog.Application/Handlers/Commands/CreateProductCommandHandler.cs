using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Commands
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
	{
		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;
		public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
		{
			_mapper = mapper;
			_repository = repository;
		}
		public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var product = _mapper.Map<Product>(request);
			var newProduct= await _repository.CreateProduct(product);
			var productResponse= _mapper.Map<ProductResponseDto>(newProduct);
			return productResponse;
		}
	}
}
