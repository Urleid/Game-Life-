using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urleid.Remember
{
    class Person
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        // Уровень отношений: 0 - знакомые, 1 - друзья, 2 - любовники, 3 - семья.
        private Dictionary<Person, uint> _relationship;
        public Dictionary<Person, uint> Relationship
        {
            get { return _relationship; }
            set { _relationship = value; }
        }


        public Person(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;

            _relationship = new Dictionary<Person, uint>();
        }
    }
}
