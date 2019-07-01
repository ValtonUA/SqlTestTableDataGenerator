using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.DataLibrary
{
    public class UserTextFileRepository : TextFileRepository, IUserRepository
    {
        public List<string> GetNames()
        {
            return GenerateList(
                "Names.txt",
                new Func<char, bool>(symbol => symbol < 128 && char.IsLetter(symbol)),
                new Func<string, bool>(property => property.Length >= 2 && property.Length <= 20));
        }

        public List<string> GetPatronymics()
        {
            return GenerateList(
                "Patronymics.txt",
                new Func<char, bool>(symbol => symbol < 128 && char.IsLetter(symbol)),
                new Func<string, bool>(property => property.Length >= 2 && property.Length <= 20));
        }

        public List<string> GetSurnames()
        {
            return GenerateList(
                "Surnames.txt",
                new Func<char, bool>(symbol => symbol < 128 && char.IsLetter(symbol)),
                new Func<string, bool>(property => property.Length >= 2 && property.Length <= 20));
        }

        public List<string> GetUniqueLogins()
        {
            return GenerateList(
                "EnglishWords.txt",
                new Func<char, bool>(symbol => symbol < 128 && char.IsLetterOrDigit(symbol)),
                new Func<string, bool>(property => property.Length >= 6 && property.Length <= 20),
                true);
        }
    }
}
