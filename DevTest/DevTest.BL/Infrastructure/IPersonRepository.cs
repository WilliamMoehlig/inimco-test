using DevTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevTest.BL.Infrastructure
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        IEnumerable<Person> FindBy(Expression<Func<Person, bool>> criteria);
        Person FindById(int id);
        void Add(Person person);
        void Edit(Person person);
        void Delete(Person person);
        void Save();
    }
}
