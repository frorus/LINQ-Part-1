using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Part_1
{
    namespace PhoneBook
    {
        class Program
        {
            static void Main(string[] args)
            {
                //  создаём пустой список с типом данных Contact
                var phoneBook = new List<Contact>
                {
                    // добавляем контакты
                    new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
                    new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
                    new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
                    new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
                    new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
                    new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
                };

                var sortedPhoneBook = phoneBook
                    .OrderBy(c => c.Name)
                    .ThenBy(c => c.LastName);

                Console.WriteLine("Введите номер страницы: ");

                while (true)
                {
                    // Читаем введенный с консоли символ
                    var input = Console.ReadKey().KeyChar;

                    // проверяем, число ли это
                    var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                    // если не соответствует критериям - показываем ошибку
                    if (!parsed || pageNumber < 1 || pageNumber > 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Страницы не существует");
                    }
                    // если соответствует - запускаем вывод
                    else
                    {
                        // пропускаем нужное количество элементов и берем 2 для показа на странице
                        var pageContent = sortedPhoneBook.Skip((pageNumber - 1) * 2).Take(2);
                        Console.WriteLine();

                        // выводим результат
                        foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                        Console.WriteLine();
                    }
                }
            }
        }

        // модель класса
        public class Contact 
        {
            // метод-конструктор
            public Contact(string name, string lastName, long phoneNumber, string email) 
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public string Name { get; }
            public string LastName { get; }
            public long PhoneNumber { get; }
            public string Email { get; }
        }
    }
}
