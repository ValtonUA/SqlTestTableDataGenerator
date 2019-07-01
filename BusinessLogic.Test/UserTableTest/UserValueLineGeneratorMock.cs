using SqlTestTableDataGenerator.BusinessLogicLibrary;
using SqlTestTableDataGenerator.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Test
{
    public class UserValueLineGeneratorMock : IValueLineGenerator<User>
    {
        public User GenerateEntityModel()
        {
            return new User();
        }

        public string GenerateValueLine(User entity)
        {
            return "('Value1', 'Value2')";
        }

        public string GetInsertLine()
        {
            return "INSERT INTO dbo.User VALUES ";
        }

        public void Init()
        {

        }
    }
}
