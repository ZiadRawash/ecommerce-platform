using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Commands
{
	public class DeleteProductCommand:IRequest<bool>
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id {  get; set; }
		public DeleteProductCommand(string id)
		{
			Id= id;
		}
	}
}
