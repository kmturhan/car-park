using CarPark.Core.Models;
using CarPark.Core.Repository.Abstract;
using CarPark.Core.Settings;
using CarPark.DataAccess.Context;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DataAccess.Repository
{
	public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
	{
		private readonly MongoDbContext _context;
		private readonly IMongoCollection<TEntity> _collection;
		public MongoRepositoryBase(IOptions<MongoSettings> settings)
		{
			_context = new MongoDbContext(settings);
			_collection = _context.GetCollection<TEntity>();
		}
		public GetManyResult<TEntity> AsQueryable()
		{
			var result = new GetManyResult<TEntity>();
			try
			{
				var data = _collection.AsQueryable().ToList();
				if (data != null)
				{
					result.Result = data;
				}
			}
			catch (Exception ex)
			{
				result.Message = $"AsQueryable {ex.Message}";
				result.Success = false;
				result.Result = null;
			}
			return result;
		}

		public async Task<GetManyResult<TEntity>> AsQueryableAsync()
		{
			var result = new GetManyResult<TEntity>();
			try
			{
				var data = await _collection.AsQueryable().ToListAsync();
				if (data != null)
				{
					result.Result = data;
				}
			}
			catch (Exception ex)
			{
				result.Message = $"AsQueryable {ex.Message}";
				result.Success = false;
				result.Result = null;
			}
			return result;
		}
	}
}
