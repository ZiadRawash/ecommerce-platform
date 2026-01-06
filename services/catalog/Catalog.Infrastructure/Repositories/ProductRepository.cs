using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository, IBrandRepository, ITypeRepository
	{
		public ICatalogContext _context {  get; set; }
		public ProductRepository(ICatalogContext context)
		{
			_context = context;
		}
		public async Task<Product> GetProductById(string id)
		{
			return await _context.Products.Find(n=>n.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			return await _context.Products
				.Find(p=>true).ToListAsync();
		}


		public async Task<IEnumerable<Product>> GetAllProductsByName(string name)
		{
			return await _context.Products
				.Find(x=>x.Name == name).ToListAsync();
		}

		public async Task<IEnumerable<Product>> GetAllProductsByBrand(string name)
		{
			return await _context.Products.Find(x => x.Brand.Name == name).ToListAsync();
		}

		public async Task<Product> CreateProduct(Product product)
		{
			await _context.Products.InsertOneAsync(product);
			return product;
		}

		public async Task<bool> UpdateProduct(Product product)
		{
			var updatedProduct= await _context.Products
				.ReplaceOneAsync(p=>p.Id==product.Id, product);
			return updatedProduct.IsAcknowledged&& updatedProduct.ModifiedCount>0;
		}

		public async Task<bool> DeleteProduct(string id)
		{
			var deletedProduct = await _context.Products.DeleteOneAsync(x => x.Id == id);
			return deletedProduct.IsAcknowledged && deletedProduct.DeletedCount > 0;
		}

		public async Task<IEnumerable<ProductBrand>> GetAllBrands()
		{
			return await _context.Brands.Find(x=>true).ToListAsync();
		}

		public async Task<IEnumerable<ProductType>> GetAllTypes()
		{
			return await _context.Types.Find(x => true).ToListAsync();
		}
	}
}
