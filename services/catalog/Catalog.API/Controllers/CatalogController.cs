using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
	public class CatalogController : BaseApiController
	{
		private readonly IMediator _mediator;

		public CatalogController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("GetProductById/{id}", Name = "GetProductById")]
		public async Task<ActionResult<ProductResponseDto>> GetProductById(string id)
		{
			var query = new GetProductByIdQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("GetProductByName/{productName}", Name = "GetProductByName")]
		public async Task<ActionResult<IList<ProductResponseDto>>> GetProductByName(string productName)
		{
			var query = new GetAllProductsByNameQuery(productName);
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("GetAllProducts", Name = "GetAllProducts")]
		public async Task<ActionResult<IList<ProductResponseDto>>> GetAllProducts()
		{
			var query = new GetAllProductsQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpPost("CreateProduct", Name = "CreateProduct")]
		public async Task<ActionResult<ProductResponseDto>> CreateProduct([FromBody] CreateProductCommand productCommand)
		{
			var result = await _mediator.Send(productCommand);
			return Ok(result);
		}

		[HttpPut("UpdateProduct", Name = "UpdateProduct")]
		public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand productCommand)
		{
			var result = await _mediator.Send(productCommand);
			return Ok(result);
		}

		[HttpDelete("DeleteProduct/{id}", Name = "DeleteProduct")]
		public async Task<ActionResult<bool>> DeleteProduct(string id)
		{
			var command = new DeleteProductCommand(id);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
