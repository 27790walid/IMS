using IMS.Model;
using IMS.Model.Models;
using IMS.Model.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System;

namespace IMS.BL
{
    public class ProductBL : BaseBL
    {
        public ProductBL(ApplicationDbContext applicationDbContext)
        {
            unitOfWork = new UnitOfWork(applicationDbContext);
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await unitOfWork.Products.Get();
        }
        public async Task<IEnumerable<Product>> SearchProducts(string code, string title, DateTime? creationDate, int? quantity, string qtyOperator)
        {
            var vowels =new string[] { "a", "b", "C" };
            //vowels[]
            return await unitOfWork.Products.Get(x => 
               (string.IsNullOrEmpty(code) || x.Code == code)
            && (string.IsNullOrEmpty(title) || x.Title == title)            
            && (creationDate == null || x.CreationDate == creationDate)
            && (quantity == null ||
            (qtyOperator == "=" && x.Quantity == quantity)
            || (qtyOperator == ">" && x.Quantity > quantity)
            || (qtyOperator == "<" && x.Quantity < quantity)
            ));
        }
        public async Task<IEnumerable<Product>> GetProductById(int id)
        {
            return await unitOfWork.Products.Get(o => o.Id == id);
        }
        public async Task<int> AddProduct(Product entity)
        {
            unitOfWork.Products.Insert(entity);
            return await unitOfWork.Commit();
        }

        public async Task<int> EditProduct(Product entity)
        {
            unitOfWork.Products.Update(entity);
            return await unitOfWork.Commit();
        }

        public async Task<int> DeleteProduct(int productID)
        {
            var entity = unitOfWork.Products.Get(o => o.Id == productID).Result.FirstOrDefault();
            if (entity != null)
            {
                unitOfWork.Products.Delete(entity);
                return await unitOfWork.Commit();
            }
            return 0;
        }
    }
    public class ProductSearch
    {
        //string code, string title, DateTime? creationDate, int? quantity, string qtyOperator)
        public string Code { get; set; }
        public string Title { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Quantity { get; set; }
        public string QtyOperator { get; set; }

    }
}
