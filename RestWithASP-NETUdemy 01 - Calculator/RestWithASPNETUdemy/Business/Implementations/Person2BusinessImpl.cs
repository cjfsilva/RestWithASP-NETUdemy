using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class Person2BusinessImpl : IPerson2Business
    {
        private IPerson2Repository _repository;

        private readonly Person2Converter _converter;

        public Person2BusinessImpl(IPerson2Repository repository)
        {
            _repository = repository;
            _converter = new Person2Converter();
        }

        public Person2VO Create(Person2VO person2)
        {
            var person2Entity = _converter.Parse(person2);
            person2Entity = _repository.Create(person2Entity);
            return _converter.Parse(person2Entity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person2VO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public Person2VO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<Person2VO> FindByName(string firstName, string lastName)
        {
            return _converter.ParseList(_repository.FindByName(firstName, lastName));
        }

        public PagedSearchDTO<Person2VO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            //page = page > 0 ? page - 1 : 0;
            string query = @"SELECT * FROM persons2 p WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" AND p.FirstName LIKE '%{name}%'"; 
            query = query + $" ORDER BY p.FirstName {sortDirection} LIMIT {pageSize} OFFSET {page}";

            string countQuery = @"SELECT COUNT(*) FROM persons2 p WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" AND p.FirstName LIKE '%{name}%'";

            var persons2 = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchDTO<Person2VO>
            {
                CurrentPage = page,
                List = _converter.ParseList(persons2),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }

        public Person2VO Update(Person2VO person2)
        {
            var person2Entity = _converter.Parse(person2);
            person2Entity = _repository.Update(person2Entity);
            return _converter.Parse(person2Entity);
        }
    }
}
