using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository
    {

        List<ProductModel> GetAll();
        ProductModel GetById(int id);
        bool Delete(int id);
        bool Delete(List<ProductModel> entities);
        bool Insert(ProductModel entity);
        bool Update(ProductModel productModel);

    }
}
