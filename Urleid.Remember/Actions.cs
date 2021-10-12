using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urleid.Remember
{
    class Actions
    {
        /// <summary>
        /// Знакомство персонажей.
        /// </summary>
        /// <param name="person1">Первый персонаж.</param>
        /// <param name="person2">Второй персонаж.</param>
        public static void Acquaintance(Person person1, Person person2)
        {
            if (person1.Relationship.ContainsKey(person2))
            {
                Console.WriteLine($"{person1.FirstName} и {person2.FirstName} уже знакомы");
            }
            else
            {
                BuildingRelationships(person1, person2, 0);
                Console.WriteLine($"{person1.FirstName} и {person2.FirstName} теперь знакомые");
            }
        }

        /// <summary>
        /// Возникновение дружбы.
        /// </summary>
        /// <param name="person1">Первый персонаж.</param>
        /// <param name="person2">Второй персонаж.</param>
        public static void Friendship(Person person1, Person person2)
        {
            uint relationshipLevel;

            if (!person1.Relationship.ContainsKey(person2))
            {
                Console.WriteLine($"{person1.FirstName} и {person2.FirstName} не знакомы");
            }
            else
            {
                person1.Relationship.TryGetValue(person2, out relationshipLevel);

                if (relationshipLevel == 1) // Уровень отношений - друзья.
                {
                    Console.WriteLine($"{person1.FirstName} и {person2.FirstName} уже друзья");
                }
                else
                {
                    EditRelationships(person1, person2, 1);
                    Console.WriteLine($"{person1.FirstName} и {person2.FirstName} теперь друзья");
                }
            }
        }
        
        /// <summary>
        /// Возникновение любовных отношений.
        /// </summary>
        /// <param name="person1">Первый персонаж.</param>
        /// <param name="person2">Второй персонаж.</param>
        public static void LoveRelationship(Person person1, Person person2)
        {
            uint relationshipLevel;

            if (!person1.Relationship.ContainsKey(person2))
            {
                Console.WriteLine($"{person1.FirstName} и {person2.FirstName} не знакомы");
            }
            else
            {
                person1.Relationship.TryGetValue(person2, out relationshipLevel);

                if (relationshipLevel == 2) // Уровень отношений - любовники.
                {
                    Console.WriteLine($"{person1.FirstName} и {person2.FirstName} уже любовники");
                }
                else
                {
                    EditRelationships(person1, person2, 2);
                    Console.WriteLine($"Между {person1.FirstName} и {person2.FirstName} возникают любовные отношения");
                }
            }
        }

        /// <summary>
        /// Создание семьи.
        /// </summary>
        /// <param name="person1">Первый персонаж.</param>
        /// <param name="person2">Воорой персонаж.</param>
        public static void Wedding(Person person1, Person person2)
        {
            uint relationshipLevel;

            if (!person1.Relationship.ContainsKey(person2))
            {
                Console.WriteLine($"{person1.FirstName} и {person2.FirstName} не знакомы");
            }
            else
            {
                person1.Relationship.TryGetValue(person2, out relationshipLevel);

                if (relationshipLevel == 3) // Уровень отношений - семья.
                {
                    Console.WriteLine($"{person1.FirstName} и {person2.FirstName} уже в браке");
                }
                else
                {
                    EditRelationships(person1, person2, 3);
                    Console.WriteLine($"{person1.FirstName} и {person2.FirstName} заключают брак");
                }
            }
        }

        /// <summary>
        /// Создание отношений.
        /// </summary>
        /// <param name="person1">Первый персонаж.</param>
        /// <param name="person2">Второй персонаж.</param>
        /// <param name="relationshipLevel">Уровень отношений (0 - знакомые, 1 - друзья, 2 - любовники, 3 - семья.</param>
        private static void BuildingRelationships(Person person1, Person person2, uint relationshipLevel)
        {
            person1.Relationship.Add(person2, relationshipLevel);
            person2.Relationship.Add(person1, relationshipLevel);
        }

        /// <summary>
        /// Изменение отношений.
        /// </summary>
        /// <param name="person1">Первый персонаж.</param>
        /// <param name="person2">Второй персонаж.</param>
        /// <param name="relationshipLevel">Уровень отношений (0 - знакомые, 1 - друзья, 2 - любовники, 3 - семья.</param>
        private static void EditRelationships(Person person1, Person person2, uint relationshipLevel)
        {
            person1.Relationship[person2] = relationshipLevel;
            person2.Relationship[person1] = relationshipLevel;
        }
    }
}
