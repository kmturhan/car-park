using CarPark.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.Repository.Abstract
{
	public interface IRepository<TEntity> where TEntity : class, new()
	{
		GetManyResult<TEntity> AsQueryable();
		Task<GetManyResult<TEntity>> AsQueryableAsync();
		GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
		Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter);
		GetOneResult<TEntity> GetById(string id);
		Task<GetOneResult<TEntity>> GetByIdAsync(string id);
		GetOneResult<TEntity> InsertOne(TEntity entity);
		GetOneResult<TEntity> InsertOneAsync(TEntity entity);
	}
}
