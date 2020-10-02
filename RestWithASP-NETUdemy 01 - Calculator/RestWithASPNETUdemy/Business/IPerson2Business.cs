using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace RestWithASPNETUdemy.Business
{
    public interface IPerson2Business
    {
        Person2VO Create(Person2VO person2);
        Person2VO FindById(long id);
        List<Person2VO> FindAll();
        List<Person2VO> FindByName(string firstNAme, string lastName);

        PagedSearchDTO<Person2VO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        Person2VO Update(Person2VO person2);
        void Delete(long id);
    }
}
