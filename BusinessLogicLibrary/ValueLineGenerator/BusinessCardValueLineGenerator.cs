using SqlTestTableDataGenerator.BusinessLogicLibrary;
using SqlTestTableDataGenerator.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.BusinessLogicLibrary
{
    public class BusinessCardValueLineGenerator : IValueLineGenerator<BusinessCard>
    {
        IBusinessCardRepository repository;
        Random random;

        int cardIdUniqueIndex;
        List<string> titles = new List<string>();

        public BusinessCardValueLineGenerator (IBusinessCardRepository repo)
        {
            repository = repo;
            random = new Random();

            cardIdUniqueIndex = 0;
            titles = repository.GetTitles();
        }

        public BusinessCard GenerateEntityModel()
        {
            BusinessCard result = new BusinessCard();

            result.CardId = cardIdUniqueIndex;
            cardIdUniqueIndex++;

            result.Title = titles[random.Next(0, titles.Count)];

            for (int i = 0; i < random.Next(10, 13); i++)
            {
                result.PhoneNumber += random.Next(0, 10).ToString();
            }

            return result;
        }

        public string GenerateValueLine(BusinessCard entity)
        {
            StringBuilder result = new StringBuilder("(");

            result.Append($"{entity.CardId}, ");
            result.Append($"'{entity.Title}', ");
            result.Append($"'{entity.PhoneNumber}')");

            return result.ToString();
        }

        public string GetInsertLine()
        {
            return "INSERT INTO dbo.BusinessCard VALUES ";
        }

        public void Init()
        {
            cardIdUniqueIndex = 0;
        }
    }
}
