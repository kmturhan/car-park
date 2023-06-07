using CarPark.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.Repository.Abstract
{
	public interface IRepository<TEntity> where TEntity : class, new()
	{
		GetManyResult<TEntity> AsQueryable();
		Task<GetManyResult<TEntity>> AsQueryableAsync();
	}
}
