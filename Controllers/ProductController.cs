using Ecommerce.Core.IReboseitry;
using Ecommerce.Infastructoure.Reboseitry;
using EcommerceCore.Entities;
using EcommerceInfastructoure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly IProductRebositery productRebositery;

		public ProductController(ApplicationDbContext context ,IProductRebositery productRebositery)
		{
			this.context = context;
			this.productRebositery = productRebositery;
		}
		[HttpGet]
		public ActionResult GetAll()
		{
			var products = productRebositery.GetAll();
			return Ok(products);
		}
		[HttpGet("{id}")]
		public ActionResult GetById(int id)
		{
			var Product = productRebositery.GetById(id);
			return Ok(Product);
		}
		[HttpPost]
		public ActionResult AddNewProduct(Product newProduct)
		{
			productRebositery.CreateNew(newProduct);
			//context.Products.Add(newProduct);
			context.SaveChanges();
			return Ok();
		}
		[HttpPut]
		public ActionResult UpdateProduct(Product model)
		{
			productRebositery.Update(model);
			//context.Products.Update(model);
			context.SaveChanges();
			return Ok(model);
		}
		[HttpDelete("{id}")]
		public ActionResult Delete(int id )
		{
			productRebositery.Delete(id);
			//var product = context.Products.Find(id);
			context.Remove(id);
			context.SaveChanges();
			return Ok();

		}
	}
}
