using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface IPerson2Repository : IRepository<Person2>
    { 
        List<Person2> FindByName(string firstName, string lastName);
       
    }
}
