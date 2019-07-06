using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace http_exchange
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> currentMoney = Money.Currect(); // Метод для определения доступных валют
            Console.WriteLine("Доступные валюты:");
            foreach (string s in currentMoney) // Вывод доступных валют
            {
                Console.WriteLine(s);
            }
            string name = "";
            while (name != "EXIT")   // Пока не введешь команду для выхода, цикл бесконечный по запросу курса.
            {
                string str = Http_Get.Get();
                Console.WriteLine("\nДля запроса даты введите 'DATA'. Для выхода 'EXIT'");
                Console.WriteLine("\nВведите интересующую валюту");
                name = Console.ReadLine(); // Запрос на команду
                int indexStart; // Поиск валюты в тексте (начальный индекс)
                int indexFinal; // Поиск валюты в тексте (конечный индекст)
                char br = ',';  // Ограничитель по поиску
                indexStart = str.IndexOf(name); // Нашел первый индекс (Вообще если запихнуть этот поиск в циклы, может будет более читабельно)
                for (int i = 0; i < currentMoney.Count; i++)
                {
                    if(name == "DATA")
                    {
                        Console.WriteLine(Data.ReturnData()); // Вывод даты
                        break;
                    }
                    else if (name == "EXIT") // Выход из программы
                    {
                        break;
                    }
                    else if (name == "EUR") // Случай базовой валюты
                    {
                        Console.WriteLine("\n ЕUR - Базовая валюта");
                        break;
                    }
                    else if (name == currentMoney[i] && i == currentMoney.Count - 1) // Случай последней валюты в списке
                    {
                        indexFinal = str.IndexOf(br, indexStart + 1);
                        Console.WriteLine(str.Substring(indexStart + 5, indexFinal - indexStart - 6));
                        break;
                    }
                    else if (name == currentMoney[i]) // Все другие валюты
                    {
                        indexFinal = str.IndexOf(br, indexStart + 1);
                        Console.WriteLine(str.Substring(indexStart + 5, indexFinal - indexStart - 5));
                        break;
                    }
                    else if (i == currentMoney.Count - 1) //  Если ввели несуществующую валюту
                    {
                        Console.WriteLine("\n Такой валюты не существует в базе данных");
                    }
                }
            }
            Console.WriteLine("\n Спасибо за использование нашего сервиса!");
        }
    }
}
