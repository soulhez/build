﻿using Build;

namespace UnitTests
{
    namespace Fail_TestSet5
    {
        public interface IOtherRepository
        {
        }

        [Dependency(RuntimeInstance.None)]
        public class OtherRepository : NoSqlDataRepository, IOtherRepository
        {
            public OtherRepository(int param): base(null)
            {
            }
        }

        public class SqlDataRepository : IPersonRepository
        {
            public SqlDataRepository([Injection(typeof(SqlDataRepository))]ServiceDataRepository repository)
            {
            }

            public Person GetPerson(int personId)
            {
                // get the data from SQL DB and return Person instance.
                return new Person(this);
            }
        }

        [Dependency("Ho ho ho", RuntimeInstance.None)]
        public class ServiceDataRepository : IPersonRepository
        {
            public ServiceDataRepository([Injection("Ho ho ho")]ServiceDataRepository repository)
            {
                Repository = repository;
            }
            public IPersonRepository Repository { get; }
            public Person GetPerson(int personId)
            {
                // get the data from Web service and return Person instance.
                return new Person(this);
            }
        }


        public class NoSqlDataRepository
        {
            public NoSqlDataRepository([Injection(typeof(OtherRepository))]IOtherRepository other)
            {
            }

            public Person GetPerson(int personId)
            {
                // get the data from SQL DB and return Person instance.
                return new Person(null);
            }
        }
    }
}