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
            bool tolerance = true;

            for (int i = 0; i < person1.Relationships.Count; i++)
            {
                if (person1.Relationships[i].Person1 == person1 && person1.Relationships[i].Person2 == person2)
                {
                    Console.WriteLine("ОШИБКА! Эти персонажи уже знакомы");
                    tolerance = false;
                    break;
                }
            }

            if (tolerance == true)
            {
                // Поочередное внесение отношений в список отношений обоих персонажей (параметры отношений должны быть зеркальны для обоих персонажей).
                person1.Relationships.Add(new Relationships(person1, person2));
                person2.Relationships.Add(new Relationships(person2, person1));
                Console.WriteLine($"{person1.FirstName} и {person2.FirstName} познакомились");
            }
        }

        /// <summary>
        /// Изменение отношений.
        /// </summary>
        /// <param name="person1">Первый персонаж.</param>
        /// <param name="person2">Второй персонаж.</param>
        /// <param name="relationshipProcess">Процесс отношений (0-300 - знакомые, 600 - друзья, 900 - любовники, 1200 - семья.</param>
        public static void EditRelationships(Person person1, Person person2, int relationshipProcess)
        {
            bool tolerance = false;

            for (int i = 0; i < person1.Relationships.Count; i++)
            {
                if (person1.Relationships[i].Person1 == person1 && person1.Relationships[i].Person2 == person2)
                {
                    // Изменяем значение прогресса.
                    person1.Relationships[i].RelationshipProcess += relationshipProcess;
                    person2.Relationships[i].RelationshipProcess += relationshipProcess;
                    
                    // Если значение прогресса позволяет перейти на новый уровень отношений, то делаем это.
                    if (person1.Relationships[i].RelationshipProcess >= person1.Relationships[i].RelationshipLevel * 300)
                    {
                        if (person1.Relationships[i].RelationshipLevel < 4)
                        {
                            // Производим повышение отношений до тех пор, пока позволяет значение прогресса.
                            while (person1.Relationships[i].RelationshipProcess >= person1.Relationships[i].RelationshipLevel * 300)
                            {
                                person1.Relationships[i].RelationshipProcess -= person1.Relationships[i].RelationshipLevel * 300;
                                person2.Relationships[i].RelationshipProcess -= person2.Relationships[i].RelationshipLevel * 300;
                                person1.Relationships[i].RelationshipLevel++;
                                person2.Relationships[i].RelationshipLevel++;
                            }
                        }

                        // Если уровень получился выше 4, то мы его возвращаем на максимальное значение (4-ый) с максимальным значением прогресса.
                        if (person1.Relationships[i].RelationshipLevel > 4)
                        {
                            person1.Relationships[i].RelationshipLevel = 4;
                            person1.Relationships[i].RelationshipProcess = person1.Relationships[i].RelationshipLevel * 300;
                            person2.Relationships[i].RelationshipLevel = 4;
                            person2.Relationships[i].RelationshipProcess = person1.Relationships[i].RelationshipLevel * 300;
                        }

                        // Выводим результат изменений отношений.
                        switch (person1.Relationships[i].RelationshipLevel)
                        {
                            case 1:
                                Console.WriteLine($"{person1.FirstName} и {person2.FirstName} теперь знакомые.");
                                break;
                            case 2:
                                Console.WriteLine($"{person1.FirstName} и {person2.FirstName} теперь друзья.");
                                break;
                            case 3:
                                Console.WriteLine($"{person1.FirstName} и {person2.FirstName} теперь любовники.");
                                break;
                            case 4:
                                Console.WriteLine($"{person1.FirstName} и {person2.FirstName} теперь семья.");
                                break;
                        }
                    }
                    tolerance = true;
                    break;
                }
            }

            if (tolerance == false)
            {
                Console.WriteLine("ОШИБКА! Эти персонажи еще не знакомы");
            }
        }


    }
}
