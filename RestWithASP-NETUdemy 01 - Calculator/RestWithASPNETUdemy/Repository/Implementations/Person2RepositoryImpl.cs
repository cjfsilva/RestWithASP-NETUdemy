using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class Person2RepositoryImpl : GenericRepository<Person2>, IPerson2Repository
    {
        public Person2RepositoryImpl(MySQLContext context) : base (context) {}

        public List<Person2> FindByName(string firstName, string lastName)
        {
            if(string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Persons2.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            } 
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons2.Where(p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Persons2.Where(p => p.FirstName.Contains(firstName)).ToList();
            }
            else
            {
                return _context.Persons2.ToList();
            }
        }
    }
}
