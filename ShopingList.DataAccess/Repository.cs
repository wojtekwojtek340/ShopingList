﻿using Microsoft.EntityFrameworkCore;
using ShopingList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingList.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ShopingListContext context;
        private readonly DbSet<T> entities;

        public Repository(ShopingListContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task Delete(int id)
        {
            T entity = await entities.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentNullException("this id no exist");
            }

            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async ValueTask<T> GetById(int id)
        {
            return await entities.FindAsync(id);
        }

        public Task Insert(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("null entity");
            }

            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("null entity");
            }

            entities.Update(entity);
            return context.SaveChangesAsync();
        }
    }
}
