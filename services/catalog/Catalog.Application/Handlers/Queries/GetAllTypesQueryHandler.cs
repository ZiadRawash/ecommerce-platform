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
	public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, IList<TypeResponseDto>>
	{
		private readonly Mapper _mapper;
		private readonly ITypeRepository _repository;
		public GetAllTypesQueryHandler(Mapper mapper, ITypeRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<IList<TypeResponseDto>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
		{
			var types = await _repository.GetAllTypes();
			var typesList = _mapper.Map<IList<ProductType>, IList<TypeResponseDto>>(types.ToList());
			return typesList;
		}
	}
}
