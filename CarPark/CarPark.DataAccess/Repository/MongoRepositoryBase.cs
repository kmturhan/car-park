using CarPark.Core.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
namespace CarPark.DataAccess.Repository
{
	public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
	{
	}
}
