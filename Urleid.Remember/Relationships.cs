using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urleid.Remember
{
    class Relationships
    {
        private Person _person1;
        public Person Person1
        {
            get { return _person1; }
            set { _person1 = value; }
        }

        private Person _person2;
        public Person Person2
        {
            get { return _person2; }
            set { _person2 = value; }
        }

        // Уровень отношений: 1 - знакомые, 2 - друзья, 3 - любовники, 4 - семья.
        private int _relationshipLevel;
        public int RelationshipLevel
        {
            get { return _relationshipLevel; }
            set { _relationshipLevel = value; }
        }

        private int _relationshipProcess;
        public int RelationshipProcess
        {
            get { return _relationshipProcess; }
            set { _relationshipProcess = value; }
        }

        public Relationships(Person person1, Person person2)
        {
            _person1 = person1;
            _person2 = person2;

            _relationshipLevel = 1;
            _relationshipProcess = 0;
        }
    }
}
