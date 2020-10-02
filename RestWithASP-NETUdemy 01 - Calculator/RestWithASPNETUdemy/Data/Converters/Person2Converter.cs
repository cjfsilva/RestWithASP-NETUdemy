using RestWithASPNETUdemy.Data.Converter;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converters
{
    public class Person2Converter : IParser<Person2VO, Person2>, IParser<Person2, Person2VO>
    {
        public Person2 Parse(Person2VO origin)
        {
            if (origin == null) return new Person2();
            return new Person2
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public Person2VO Parse(Person2 origin)
        {
            if (origin == null) return new Person2VO();
            return new Person2VO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person2> ParseList(List<Person2VO> origin)
        {
            if (origin == null) return new List<Person2>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Person2VO> ParseList(List<Person2> origin)
        {
            if (origin == null) return new List<Person2VO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
