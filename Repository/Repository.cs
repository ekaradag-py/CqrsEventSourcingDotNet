using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class Repository : IRepository
    {
        private readonly DbContext _dbContext;
        private DbSet<ProductModel> _entities;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<ProductModel>();
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
                throw new NotImplementedException();
            }
            var getEntity = GetById(id);
            _entities.Remove(getEntity);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Delete(List<ProductModel> entities)
        {
            if (!entities.Any())
                return false;

            entities.Select(s =>
            {
                _entities.Remove(s);
                return s;
            }).ToList();

            _dbContext.SaveChanges();
            return true;
        }
        public List<ProductModel> GetAll()
        {
            return _entities.ToList();
        }

        public ProductModel? GetById(int id)
        {
            return _entities.FirstOrDefault(f => f.ID == id);
        }

        public bool Insert(ProductModel entity)
        {
            entity.ID = 0;
            _entities.Add(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(ProductModel productModel)
        {
            var getEntity = GetById(productModel.ID);
            if (productModel == null || getEntity == null)
                return false;

            _dbContext.Entry(getEntity).CurrentValues.SetValues(productModel);

            _dbContext.SaveChanges();

            return true;
        }
    }
}
