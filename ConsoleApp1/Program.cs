using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnlyVectorTask
{

    public class Program
    {
        static int GetCorrectNumber()
        {
            bool flag;
            int result;

            do
            {
                flag = int.TryParse(Console.ReadLine(), out result);
                if (!flag || result <= 0)
                    Console.WriteLine("Некорректный ввод! Повторите попытку:");
            }
            while (!flag || result <= 0);

            return result;
        }

        static bool GetCorrectPresence()
        {
            string answer;

            do
            {
                answer = Console.ReadLine();
                if(answer != "да" && answer != "нет" && answer != "Да" && answer != "Нет")
                    Console.WriteLine("Некорректный ввод! Повторите попытку:");
            }    
            while (answer != "да" && answer != "нет" && answer != "Да" && answer != "Нет");

            if(answer == "да" || answer == "Да")
                return true;
            else
                return false;
            
        }

        static string GetCorrectString()
        {
            string name;
            int test;

            do
            {
                name = Console.ReadLine();
                if (int.TryParse(name, out test))
                    Console.WriteLine("Некорректный ввод! Повторите попытку:");
            }
            while (int.TryParse(name, out test));

            return name;
        }

        static string[] GetPetNames(int numberOfPets)
        {
            string[] petNames = new string[numberOfPets];

            for (int i = 0; i < numberOfPets; i++)
            {
                Console.WriteLine($"Введите имя питомца номер {i + 1}");
                petNames[i] = GetCorrectString();
            }

            return petNames;
        }

        static string[] GetColors(int numberOfColors)
        {
            string[] colors = new string[numberOfColors];

            for (int i = 0; i < numberOfColors; i++)
            {
                Console.WriteLine($"Введите название цвета номер {i + 1}");
                colors[i] = GetCorrectString();
            }

            return colors;
        }

        static (string, string, int, string[], string[]) GetUserInfo()
        {                                                                                                                   
            (string name, string lastName, int age, string[] petNames, string[] colors) userInfo =                         
                (null, null, 0, null, null);                                                                               
                                                                                                                                  
            Console.WriteLine("Введите ваше имя:");                                                                        
            userInfo.name = GetCorrectString();

            Console.WriteLine("Введите вашу фамилию:");
            userInfo.lastName = GetCorrectString();

            Console.WriteLine("Введите ваш возраст:");
            userInfo.age = GetCorrectNumber();

            Console.WriteLine($"{userInfo.name}, у вас есть питомец? Ответьте: \"да\" или \"нет\"");
            var presencePets = GetCorrectPresence();

            if(presencePets)
            {
                Console.WriteLine("Введите количество ваших питомцев:");
                var numberOfPets = GetCorrectNumber();
                userInfo.petNames = GetPetNames(numberOfPets);
            }

            Console.WriteLine($"{userInfo.name}, Сколько у вас любимых цветов?");
            var numberOfColors = GetCorrectNumber();
            userInfo.colors = GetColors(numberOfColors);

            return userInfo;
        }

        static void ShowUserData((string name, string lastName, int age, string[] petNames, string[] colors) userInfo)
        {
            Console.WriteLine($"Вот краткая информация о вас:\n" +
                $"Ваше имя: {userInfo.name}\n" +
                $"Ваша фамилия: {userInfo.lastName}\n" +
                $"Ваш возраст: {userInfo.age}");

            if (userInfo.petNames != null)
            {
                Console.Write("Имена ваших питомцев: ");
                foreach (var name in userInfo.petNames)
                    Console.Write(name + ", ");
                Console.WriteLine();
            }

            Console.Write("Ваши любимые цвета: ");
            foreach (var color in userInfo.colors)
                Console.Write(color + ", ");
        }

        public static void Main()
        {
            (string name, string lastName, int age, string[] petNames, string[] colors) user = GetUserInfo();
            ShowUserData(user);
        }
    }
}

