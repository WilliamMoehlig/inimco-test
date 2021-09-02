using DevTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevTest.BL.Persons.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAll();
        IEnumerable<Person> FindBy(Expression<Func<Person, bool>> criteria);
        Task<Person> FindById(int id);
        void Add(Person person);
        void Edit(Person person);
        void Delete(Person person);
        Task Save();
    }
}
