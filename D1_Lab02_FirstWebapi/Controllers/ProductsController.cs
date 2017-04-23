using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using D1_Lab02_FirstWebapi.Models;
using Newtonsoft.Json;

namespace D1_Lab02_FirstWebapi.Controllers
{
    public class ProductsController : ApiController
    {
        private Northwind db = new Northwind();

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> GetProduct(int id)
        public async Task<HttpResponseMessage> GetProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                //return NotFound();
                Request.CreateResponse(HttpStatusCode.NotFound);
            }

            //return Ok(product);
            return Request.CreateResponse(HttpStatusCode.Found, JsonConvert.SerializeObject(product));
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PUT: api/Patch/5
        [ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PatchProduct(int id, Product product)
        public async Task<IHttpActionResult> PatchProduct(int id, Product patchData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patchData.ProductID)
            {
                return BadRequest();
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // 異動 Product 物件部分欄位
            product.ProductName = patchData.ProductName;
            db.Entry(product).State = EntityState.Modified;

            var excluded = new[] { "UnitPrice" };
            var entry = db.Entry(product);
            entry.State = EntityState.Modified;
            foreach (var name in excluded)
            {
                entry.Property(name).IsModified = false;
            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}