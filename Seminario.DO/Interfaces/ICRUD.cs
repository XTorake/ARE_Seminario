﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Seminario.DO.Interfaces
{
    public interface ICrud<T>
    {
        void Insert(T t);
        void Updated(T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
        T GetOneById(int id);
        T GetOneById(string id);
        T GetOne(Expression<Func<T, bool>> predicado);
    }
}
