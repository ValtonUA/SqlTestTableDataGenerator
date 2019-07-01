using SqlTestTableDataGenerator.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Test
{
    internal class IUserRepositoryMock : IUserRepository
    {
        public List<string> GetNames()
        {
            return new List<string> { "Sasha", "Petya", "Kolya", "Inna", "Nastya" };
        }

        public List<string> GetPatronymics()
        {
            return new List<string> { "Oleksandrivna", "Petrovych", "Maksimovich", "Antonivna" };
        }

        public List<string> GetSurnames()
        {
            return new List<string> { "Grabovsky", "Petrova", "Dub", "Skovoroda" };
        }

        public List<string> GetUniqueLogins()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    result.Add($"00{i}00{j}");
                }
            }
            return result;
        }
    }
}
