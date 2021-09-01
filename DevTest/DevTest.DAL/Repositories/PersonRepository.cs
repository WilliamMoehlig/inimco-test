using DevTest.BL.Interfaces;
using DevTest.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DevTest.DAL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DevTestContext _context;
        public PersonRepository(DevTestContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons
                .Include(p => p.SocialAccounts)
                .Include(p => p.SocialSkills)
                .ToList();
        }

        public IEnumerable<Person> FindBy(Expression<Func<Person, bool>> criteria)
        {
            return _context.Persons
                .Include(p => p.SocialAccounts)
                .Include(p => p.SocialSkills)
                .Where(criteria);
        }

        public Person FindById(int id)
        {
            return _context.Persons
                .Include(p => p.SocialAccounts)
                .Include(p => p.SocialSkills)
                .SingleOrDefault(x => x.PersonId == id);
        }

        public void Add(Person person)
        {
            _context.Persons.Add(person);
        }

        public void Edit(Person person)
        {
            _context.Persons.Attach(person);
        }

        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
