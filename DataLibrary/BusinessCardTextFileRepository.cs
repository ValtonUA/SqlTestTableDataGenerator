using SqlTestTableDataGenerator.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.DataLibrary
{
    public class BusinessCardTextFileRepository : TextFileRepository, IBusinessCardRepository
    {
        public List<string> GetTitles()
        {
            return GenerateList(
                "EnglishWords.txt",
                new Func<char, bool>(symbol => symbol < 128 && char.IsLetterOrDigit(symbol)),
                new Func<string, bool>(property => property.Length >= 6 && property.Length <= 30),
                true);
        }
    }
}
