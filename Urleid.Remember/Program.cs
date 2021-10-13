using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urleid.Remember
{
    /*
     * Обработать момент, если мы принимаем в изменениях отношений отрицательное значение.
     * Создать систему полов и запретить переходить однопольным персонажам в касту любовников или семьи.
     * На максимальном значении прогресса избегать манипуляций.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Алексей", "Прохоров", 20);
            Person p2 = new Person("Елизавета", "Лапина", 20);
            Person p3 = new Person("Екатерина", "Никифорова", 18);
            Person p4 = new Person("Андрей", "Никифоров", 17);

            Actions.Acquaintance(p1, p2);
            Actions.Acquaintance(p1, p2);
            Actions.Acquaintance(p1, p3);
            Actions.Acquaintance(p1, p2);
            Actions.Acquaintance(p1, p3);
            Actions.Acquaintance(p2, p3);
            Actions.Acquaintance(p3, p1);

            Actions.EditRelationships(p1, p2, 300);

        }
    }
}
