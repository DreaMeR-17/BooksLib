using System;
using System.Collections.Generic;

namespace BooksLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddBook = "1";
            const string CommandDeleteBook = "2";
            const string CommandShowAllBooks = "3";
            const string CommandSearchBookByName = "4";
            const string CommandQuit = "5";

            bool isWork = true;

            Library library = new Library();

            while (isWork)
            {
                Console.Clear();

                Console.WriteLine($"{CommandAddBook}. Добавить книгу");
                Console.WriteLine($"{CommandDeleteBook}. Удалить книгу");
                Console.WriteLine($"{CommandShowAllBooks}. Показать все книги");
                Console.WriteLine($"{CommandSearchBookByName}. Найти книгу по названию");
                Console.WriteLine($"{CommandQuit}. Выйти");
                Console.Write("Выберите действие: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddBook:
                        library.AddBook();
                        break;

                    case CommandDeleteBook:
                        library.DeleteBook();
                        break;

                    case CommandSearchBookByName:
                        library.SearchBookByName();
                        break;

                    case CommandShowAllBooks:
                        library.ShowAllBooks();
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;

                    case CommandQuit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод, попробуйте еще раз.");
                        break;
                }
            }
        }

        class Book
        {
            public Book(int number, string name, string chapter, string author, string yearOfIssue)
            {
                Number = number;
                Name = name;
                Chapter = chapter;
                Author = author;
                YearOfIssue = yearOfIssue;
            }

            public int Number { get; private set; }
            public string Name { get; private set; }
            public string Chapter { get; private set; }
            public string Author { get; private set; }
            public string YearOfIssue { get; private set; }

            public override string ToString()
            {
                return $"Номер: {Number}, Название: {Name}, Глава: {Chapter}, Автор: {Author}, Год выпуска: {YearOfIssue}.";
            }
        }

        class Library
        {
            public Library()
            {
                _books.Add(new Book(CreateBookNumber(), "Колесо Времени", "1 - Око Мира", "Роберт Джордан", "1990"));
                _books.Add(new Book(CreateBookNumber(), "Колесо Времени", "4 - Восходящая Тень", "Роберт Джордан", "1992"));
                _books.Add(new Book(CreateBookNumber(), "Колесо Времени", "7 - Корона Мечей", "Роберт Джордан", "1996"));
                _books.Add(new Book(CreateBookNumber(), "Волкодав", "4 - Самоцветные Горы", "Мария Семенова", "2003"));
                _books.Add(new Book(CreateBookNumber(), "Кровоцвет", "1", "Кристал Смит", "2020"));
                _books.Add(new Book(CreateBookNumber(), "Скандинавские Боги", "1", "Нил Гейман", "2018"));
            }

            private List<Book> _books = new List<Book>();
            private int _bookNumber = 1;

            public void AddBook()
            {
                Console.Clear();

                int number = CreateBookNumber();

                Console.WriteLine("Напишите название книги.");
                string name = Console.ReadLine();

                Console.WriteLine("Напишите главу или часть этой книги.");
                string chapter = Console.ReadLine();

                Console.WriteLine("Напишите автора этой книги.");
                string author = Console.ReadLine();

                Console.WriteLine("Напишите год выпуска этой книги.");
                string yearOfIssue = Console.ReadLine();

                Book book = new Book(number, name, chapter, author, yearOfIssue);

                _books.Add(book);
            }

            public void DeleteBook()
            {
                Console.Clear();

                Console.WriteLine("Напишите номер книги чтобы удалить её: ");

                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    _books.RemoveAt(userInput - 1);
                }
                else
                {
                    Console.WriteLine("В хранилище нет книги с таким номером. ");
                }
            }

            public void ShowAllBooks()
            {
                Console.Clear();

                foreach (var book in _books)
                {
                    Console.WriteLine(book);
                }
            }

            public void SearchBookByName()
            {
                Console.Clear();
                
                Console.WriteLine("Введите название книги чтобы найти всю информацию: ");
                string userInput = Console.ReadLine();

                var foundBooks = _books.FindAll(book => book.Name.IndexOf(userInput) >= 0);

                if (foundBooks.Count > 0)
                {
                    foreach (var book in foundBooks)
                    {
                        Console.WriteLine(book);
                    }
                }
                else
                {
                    Console.WriteLine("Книга не найдена");
                }
            }

            private int CreateBookNumber()
            {
                return _bookNumber++;
            }
        }
    }
}
