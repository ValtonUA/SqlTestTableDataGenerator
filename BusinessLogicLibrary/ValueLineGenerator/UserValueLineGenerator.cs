using SqlTestTableDataGenerator.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.BusinessLogicLibrary
{
    /// <summary>
    /// The <c>UserValueLineGenerator</c> contains implementation of 
    /// <c>IValueLineGenerator</c> interface. It generates value lines
    /// and entity models concrete for dbo.User table and <c>User</c> class.
    /// </summary>
    public class UserValueLineGenerator : IValueLineGenerator<User>
    {
        IUserRepository repository;
        Random random;

        List<string> uniqueLogins;
        int uniqueLoginsIndex;
        List<string> names;
        List<string> surnames;
        List<string> patronymics;


        public UserValueLineGenerator(IUserRepository repo)
        {
            repository = repo;
            random = new Random();

            uniqueLogins = repository.GetUniqueLogins();
            uniqueLoginsIndex = 0;
            names = repository.GetNames();
            surnames = repository.GetSurnames();
            patronymics = repository.GetPatronymics();

        }

        public User GenerateEntityModel()
        {
            User result = new User();
            // Login
            if (uniqueLoginsIndex >= uniqueLogins.Count)
            {
                throw new IndexOutOfRangeException(
                    "File with unique logins doesn`t cover all the required value lines in a script. " +
                    "Extend it or specify a new, more large, file.");
            }
            result.Login = uniqueLogins[uniqueLoginsIndex];
            uniqueLoginsIndex++;
            // Password
            int passwordLength = random.Next(6, 21);
            result.Password = "";
            while (result.Password.Length < passwordLength)
            {
                switch(random.Next(0, 3))
                {
                    case 0: // 0-9
                        result.Password += (char)random.Next(48, 58);
                        break;
                    case 1: // A-Z
                        result.Password += (char)random.Next(65, 91);
                        break;
                    case 2: // a-z
                        result.Password += (char)random.Next(97, 123);
                        break;
                }
            }
            // Email
            result.Email = result.Login + "@";
            switch (random.Next(0, 4))
            {
                case 0: 
                    result.Email += "yandex.ru";
                    break;
                case 1: 
                    result.Email += "gmail.com";
                    break;
                case 2: 
                    result.Email += "mail.ru";
                    break;
                case 3:
                    result.Email += "ukr.net";
                    break;
            }
            // Name
            result.Name = names[random.Next(0, names.Count)];
            // Surname
            result.Surname = surnames[random.Next(0, surnames.Count)];
            // Patronymic
            switch (random.Next(0, 2))
            {
                case 0:
                    result.Patronymic = patronymics[random.Next(0, patronymics.Count)];
                    break;
                case 1:
                    result.Patronymic = "";
                    break;
            }
            // Age
            result.Age = random.Next(18, 100);
            // RegistrationDate
            string date = "";
            int year = random.Next(2015, 2020);
            int month = random.Next(1, 13);
            int day = random.Next(1, 29); // neglect number of days in months

            if (year == 2019 && month > 5)
            {
                month = 6;
                day = 1;
            }

            date = year.ToString();
            if (month < 10) date += $"0{month}";
            else date += $"{month}";
 
            if (day < 10) date += $"0{day}";
            else date += $"{day}";

            result.RegistrationDate = date;

            return result;
        }

        public string GenerateValueLine(User entity)
        {
            StringBuilder result = new StringBuilder("(");
            result.Append($"'{entity.Login}', ");
            result.Append($"'{entity.Password}', ");
            result.Append($"'{entity.Email}', ");
            result.Append($"'{entity.Name}', ");
            result.Append($"'{entity.Surname}', ");
            result.Append($"'{entity.Patronymic}', ");
            result.Append($"{entity.Age}, ");
            result.Append($"'{entity.RegistrationDate}')");

            return result.ToString();
        }

        public void Init()
        {
            uniqueLoginsIndex = 0;
        }

        public string GetInsertLine()
        {
            return "INSERT INTO dbo.User VALUES ";
        }
    }
}
