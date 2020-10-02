﻿using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETUdemy.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Person2> Persons2 { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}