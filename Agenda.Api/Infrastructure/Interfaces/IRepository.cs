﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Agenda.Api.Infrastructure.Interfaces
{
    public interface IRepository <T>
    {

        public IEnumerable<T> GetAll();

        public T GetById(int id);

        public T Create(T model);

        public T Update(T model);

        public void Delete(int id);
    }
}
