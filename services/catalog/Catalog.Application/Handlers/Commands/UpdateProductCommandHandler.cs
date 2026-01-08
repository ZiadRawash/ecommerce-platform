using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;


namespace Catalog.Application.Handlers.Commands
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
	{
		private readonly IProductRepository _repository;
		public UpdateProductCommandHandler(IProductRepository repository)
		{
			_repository = repository;
		}

		public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var updated = new Product()
			{
				Brand = request.Brand,
				Description = request.Description,
				Id = request.Id,
				ImageFile = request.ImageFile,
				Name = request.Name,
				Price = request.Price,
				Summary = request.Summary,
				Type = request.Type
			};
			var isUpdated = await _repository.UpdateProduct(updated);
			return isUpdated;
		}
	}
}
