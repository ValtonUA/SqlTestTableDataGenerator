using SqlTestTableDataGenerator.BusinessLogicLibrary;
using SqlTestTableDataGenerator.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Test
{
    public class BusinessCardValueLineGeneratorMock : IValueLineGenerator<BusinessCard>
    {
        public BusinessCard GenerateEntityModel()
        {
            return new BusinessCard();
        }

        public string GenerateValueLine(BusinessCard entity)
        {
            return "('Value1', 'Value2')";
        }

        public string GetInsertLine()
        {
            return "INSERT INTO dbo.BusinessCard VALUES ";
        }

        public void Init()
        {

        }
    }
}
