﻿using RestWithASPNETUdemy.Model.Base;

namespace RestWithASPNETUdemy.Model
{
    public class Person2 : BaseEntity
    {
        //public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
