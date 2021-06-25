﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingList.DataAccess
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        ValueTask<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
