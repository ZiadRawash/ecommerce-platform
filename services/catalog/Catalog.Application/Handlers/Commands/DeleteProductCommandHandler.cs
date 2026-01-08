using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Commands
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
	{
		private readonly IProductRepository _repository;
		public DeleteProductCommandHandler(IProductRepository repository)
		{

			_repository = repository;
		}
		public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			var isDeleted = await _repository.DeleteProduct(request.Id);
			return isDeleted;
		}
	}
}
